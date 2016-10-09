using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userProfile : System.Web.UI.Page
{
	string profileId;
	DataRow user;

	protected void Page_Load(object sender, EventArgs e)
	{
		//testa pra ver se ta logado, se não tiver, volta pro login
		if(Session["myemail"] == null)
			Response.Redirect("~/loginTest.aspx");

		// testa se tem querystring user, se não tiver, não faz nada...
		if (Request.QueryString["user"] != null)
			profileId = Request.QueryString["user"];
		
		user = sqldsToTable("SELECT name, img, bio FROM users WHERE email = '" + profileId + "';").Rows[0];
		
		Load_infos();
	}

	public void Load_infos()
	{
		lblName.Text = user["name"].ToString();
		imgProfilePicture.ImageUrl = "~/images/" + user["img"].ToString();
		lblBio.Text = "Este usuário não tem bio";
		if (user["bio"].ToString() != "")
			lblBio.Text = user["bio"].ToString();
		//----------
		updateFeedBtn();
		updateFriendBtn();
	}

	private DataTable sqldsToTable(string selectQuery)
	{
		Sqlds1.SelectCommand = selectQuery;
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}
#region "Feed"
	public void addFeed(object sender, EventArgs e)
	{
		if(!testForFeed())
		{
			Sqlds1.InsertCommand = "insert into feeds(id_me, id_following) values ('"+Session["myemail"]+"', '"+profileId+"');";
			Sqlds1.Insert();
		}
		else
		{
			Sqlds1.DeleteCommand = "DELETE FROM feeds WHERE id_me = '"+Session["myemail"]+"' AND id_following = '"+profileId+"';";
			Sqlds1.Delete();
		}
		updateFeedBtn();
	}

	public bool testForFeed()
	{
		DataTable dt = sqldsToTable("SELECT id_me, id_following FROM feeds WHERE id_me = '"+Session["myemail"]+"' AND id_following = '"+profileId+"';");
		
		if (dt.Rows.Count == 0)
			return false;
		else
			return true;
	}

	public void updateFeedBtn()
	{
		if(!testForFeed())
			btnFollow.Text = "Seguir essa pessoa?";
		else
			btnFollow.Text = "Deixar de seguir?";
	}
#endregion
#region "Friend Request"
	public void friendRequest(object sender, EventArgs e)
	{
		string res = testForFriendship("status");
		if (res == null || res == "d")
		{
			Sqlds1.InsertCommand = "insert into friends(id_request, id_target, date_sent) values "+
					"('"+Session["myemail"]+"', '"+profileId+"', now());";
			Sqlds1.Insert();
			//Send Notification
		}
		else if (res == "p")
		{
			if (testForFriendship("id_request") == (string)Session["myemail"])
			{
				//opens lightbox asking if want to send another notification
			}
			else
			{
				Sqlds1.UpdateCommand = "UPDATE friends SET `status` = 'a', date_anwser = NOW() WHERE '"+
					Session["myemail"]+"' in (id_target, id_request) AND '"+
					profileId+"' in (id_target, id_request) ORDER BY id DESC LIMIT 1;";
				Sqlds1.Update();
			}
		}
		else if (res == "a")
		{
			//opens lightbox asking if want to cancel friendship
			Sqlds1.UpdateCommand = "UPDATE friends SET `status` = 'd' WHERE '"+
				Session["myemail"]+"' in (id_target, id_request) AND '"+
				profileId+"' in (id_target, id_request)";
			Sqlds1.Update();
		}
		updateFriendBtn();
	}

	public string testForFriendship(string column)
	{
		DataTable dt = sqldsToTable("select `status` as 'status', id_request "+ 
				"from friends "+
				"where '"+Session["myemail"]+"' in (id_target, id_request) AND '"+profileId+"' in (id_target, id_request) ORDER BY id DESC;");

		if(dt.Rows.Count == 0)
			return null;
		else
			return dt.Rows[0][column].ToString();
	}

	public void updateFriendBtn()
	{
		string res = testForFriendship("status");
		if(res == null || res == "d")
		{
			btnAddFriend.Text = "Adicionar amigo?";
		}
		else if (res == "p")
		{
			if (testForFriendship("id_request") == (string)Session["myemail"])
			{
				btnAddFriend.Text = "Solicitacao enviada";
			}
			else
			{
				btnAddFriend.Text = "Aceitar Solicitacao?";
			}
		}
		else if (res == "a")
		{
			btnAddFriend.Text = "Desfazer amizade?";
		}
	}
#endregion
#region
#endregion
}
