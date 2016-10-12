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
	string profileId;

	protected void Page_Load(object sender, EventArgs e)
	{
		//testa pra ver se ta logado, se não tiver, volta pro login
		if(Session["myemail"] == null)
			Response.Redirect("~/loginTest.aspx");

		// testa se tem querystring user, se não tiver, não faz nada...
		if (Request.QueryString["user"] != null)
			profileId = Request.QueryString["user"];
		else
			profileId = (string)Session["myemail"];

		if (profileId == (string)Session["myemail"])
			myProfile = true;
		
		Load_friends();
	}

	public void Load_friends()
	{
		Sqlds1.SelectCommand = "select if(f.id_target = '" + profileId + "', ur.name, ut.name) as 'fr_name', " 
			+ "if(f.id_target = '" + profileId + "', ur.img, ut.img) as 'fr_img', " 
			+ "if(f.id_target = '" + profileId + "', ur.email, ut.email) as 'fr_email'" + 
			"from friends f inner join users ur on ur.email = f.id_request inner join users ut on ut.email = f.id_target " + 
			"where status = 'a' and '" + profileId + "' in (f.id_target, f.id_request);";
		//sets the query to a Table, witch can be used to list all the friends
		DataTable friends = sqldsToTable();

		//locates the div with id friends_facename
		Control div = FindControl("friends_facename");
		//creates an entry of each friend, entry with img and the name
		foreach(DataRow friend in friends.Rows)
		{
			WebControl entry = new WebControl(HtmlTextWriterTag.Div),
					   pic = new WebControl(HtmlTextWriterTag.Img),
					   a = new WebControl(HtmlTextWriterTag.A),
					   name = new WebControl(HtmlTextWriterTag.Span);

			entry.CssClass = "friends-entry";
			pic.CssClass = "friends-pic";
			a.CssClass = "friends_entry";
			name.CssClass = "friends-name";
			pic.Attributes["src"] = "images\\" + friend["fr_img"].ToString();
			a.Attributes["href"] = "/userProfile.aspx?user=" + friend["fr_email"];
			name.Controls.Add(new LiteralControl(friend["fr_name"].ToString()));

			entry.Controls.Add(pic);
			entry.Controls.Add(name);
			a.Controls.Add(entry);
			div.Controls.Add(a);
		}
	}

	private DataTable sqldsToTable()
	{
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}
}
