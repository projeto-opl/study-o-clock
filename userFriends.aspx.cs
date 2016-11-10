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
	DataRow curUser;

	protected void Page_Load(object sender, EventArgs e)
	{
		//testa pra ver se ta logado, se não tiver, volta pro login
		if(Session["myemail"] == null)
			Response.Redirect("~/login.aspx");

		// testa se tem querystring user, se não tiver, não faz nada...
		if (Request.QueryString["user"] != null)
			profileId = Request.QueryString["user"];
		else
			profileId = (string)Session["myemail"];

		if (profileId == (string)Session["myemail"])
			myProfile = true;

		Load_friends();
		curUser = sqldsToTable("SELECT name, img, bio FROM users WHERE email = '" + profileId + "';").Rows[0];
	}

	public void Load_friends()
	{
		string command = "select if(f.id_target = '" + profileId + "', ur.name, ut.name) as 'fr_name', "
			+ "if(f.id_target = '" + profileId + "', ur.img, ut.img) as 'fr_img', "
			+ "if(f.id_target = '" + profileId + "', ur.email, ut.email) as 'fr_email'" +
			"from friends f inner join users ur on ur.email = f.id_request inner join users ut on ut.email = f.id_target " +
			"where status = 'a' and '" + profileId + "' in (f.id_target, f.id_request);";
		//sets the query to a Table, witch can be used to list all the friends
		DataTable friends = sqldsToTable(command);
		friendsQtd = friends.Rows.Count;

		//locates the div with id friends_facename
		Control div = FindControl("friends_facename");
		//creates an entry of each friend, entry with img and the name
		foreach(DataRow friend in friends.Rows)
		{
			WebControl entry = new WebControl(HtmlTextWriterTag.Div),
					   pic = new WebControl(HtmlTextWriterTag.Img),
					   a = new WebControl(HtmlTextWriterTag.A),
					   name = new WebControl(HtmlTextWriterTag.H5);

			entry.CssClass = "id_user";
			pic.Attributes["src"] = "images\\" + friend["fr_img"].ToString();
			a.Attributes["href"] = "/userProfile.aspx?user=" + friend["fr_email"];
			name.Controls.Add(new LiteralControl(friend["fr_name"].ToString()));

			entry.Controls.Add(pic);
			entry.Controls.Add(name);
			a.Controls.Add(entry);
			div.Controls.Add(a);
		}
	}

	private DataTable sqldsToTable(string selectQuery)
	{
		Sqlds1.SelectCommand = selectQuery;
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}

	#region encapsulated
	public DataRow CurUser {get { return curUser; } }
	public int FriendsQtd { get { return friendsQtd; } }
	#endregion
}
