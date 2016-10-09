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
		Session["myemail"] = "vhoyer@live.com";
		profileId = (string)Session["myemail"];
		
		if (Request.QueryString["user"] != null)
			profileId = Request.QueryString["user"];
		
		user = sqldsToTable("SELECT name, img FROM users WHERE email = '" + profileId + "';").Rows[0];
		
		Load_infos();
	}

	public void Load_infos()
	{
		lblName.Text = user["name"].ToString();
		imgProfilePicture.ImageUrl = "~/images/" + user["img"].ToString();
		//----------
		updateFeedBtn();
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
}
