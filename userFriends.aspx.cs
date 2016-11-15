using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userFriends : System.Web.UI.Page
{
	bool myProfile = false;
	int friendsQtd;
	string profileId;
	DataRow user;

	protected void Page_Load(object sender, EventArgs e)
	{
		//testa pra ver se ta logado, se não tiver, volta pro login
		if(Session["myemail"] == null)
			Response.Redirect(FileName.Login);

		// testa se tem querystring user, se não tiver, não faz nada...
		if (Request.QueryString["user"] != null)
			profileId = Request.QueryString["user"];
		else
			profileId = (string)Session["myemail"];

		if (profileId == (string)Session["myemail"])
			myProfile = true;

		Load_friends();
		try
		{
			user = Sqlds1.QueryToTable("SELECT name, img, bio FROM users WHERE email = '" + profileId + "';").Rows[0];
		}
		catch (IndexOutOfRangeException)
		{
			Response.Redirect("error/404");
		}
		Load_infos();
	}
	public void Load_infos()
	{
		//Opções que vão aparecer para todos, independente se é o perfil é meu ou não
		lblName.Text = user["name"].ToString();
		imgProfilePicture.ImageUrl = FileName.ImgFolder + user["img"].ToString();
		lblBio.Text = "Este usuario nao tem bio";
		if (user["bio"].ToString() != "")
			lblBio.Text = user["bio"].ToString();

		//controla o que aparece se o perfil for meu ou não
		if (!myProfile)
		{
			//btnFollow.Visible = true;
			//updateFeedBtn();

			btnAddFriend.Visible = true;
			updateFriendBtn();
		}
	}

	public void Load_friends()
	{
		string command = "select if(f.id_target = '" + profileId + "', ur.name, ut.name) as 'fr_name', "
			+ "if(f.id_target = '" + profileId + "', ur.img, ut.img) as 'fr_img', "
			+ "if(f.id_target = '" + profileId + "', ur.email, ut.email) as 'fr_email'" +
			"from friends f inner join users ur on ur.email = f.id_request inner join users ut on ut.email = f.id_target " +
			"where status = 'a' and '" + profileId + "' in (f.id_target, f.id_request);";
		//sets the query to a Table, witch can be used to list all the friends
		DataTable friends = Sqlds1.QueryToTable(command);
		friendsQtd = friends.Rows.Count;

		//locates the div with id friends_facename
		Control div = FindControl("friends_facename");
		//creates an entry of each friend, entry with img and the name
		foreach(DataRow friend in friends.Rows)
		{
			//create the objects that will be put in the page
			WebControl entry = new WebControl(HtmlTextWriterTag.Div),
					   pic = new WebControl(HtmlTextWriterTag.Img),
					   a = new WebControl(HtmlTextWriterTag.A),
					   name = new WebControl(HtmlTextWriterTag.H5);

			//set the attributes to the objects
			entry.CssClass = "id_user";
			pic.Attributes["src"] = FileName.ImgFolder + friend["fr_img"].ToString();
			a.Attributes["href"] = FileName.Profile+"?user=" + friend["fr_email"];
			name.Controls.Add(new LiteralControl(friend["fr_name"].ToString()));

			//adds each control to it's parent and so
			entry.Controls.Add(pic);
			entry.Controls.Add(name);
			a.Controls.Add(entry);
			div.Controls.Add(a);
		}
	}

	#region encapsulated
	public DataRow CurUser {get { return user; } }
	public int FriendsQtd { get { return friendsQtd; } }
	#endregion

	// daqui em diante é copiado do userProfile.aspx.cs
	public void logout(object sender, EventArgs e)
	{
		this.Logout();
	}
	public void showFriends(object sender, EventArgs e)
	{
		Response.Redirect(FileName.FriendList+"?user=" + profileId);
	}
	public void btnPesq_Click(object sender, EventArgs e)
	{
		if (txtSearchBox.Text != "")
			Response.Redirect(FileName.PesqPage+"?q="+txtSearchBox.Text);
	}
#region "othersProfile"/*{{{*/
#region "Friend Request"/*{{{*/
	public void friendRequest(object sender, EventArgs e)
	{
		string res = testForFriendship("status");
		if (res == null || res == "d")
		{
			Sqlds1.InsertCommand = "insert into friends(id_request, id_target, date_sent) values "+
				"('"+Session["myemail"]+"', '"+profileId+"', now());";
			Sqlds1.Insert();
			//if (!testForFeed())
			//addFeed(e,e);
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
		DataTable dt = Sqlds1.QueryToTable("select `status` as 'status', id_request "+ 
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
#endregion/*}}}*/
#endregion/*}}}*/
}
