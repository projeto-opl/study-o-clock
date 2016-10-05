using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userFriends : System.Web.UI.Page
{
	DataRow user;
	protected void Page_Load(object sender, EventArgs e)
	{
		Session["myemail"] = "vhoyer@live.com";
		Sqlds1.SelectCommand = "SELECT name, img FROM users WHERE email = '" + Session["myemail"] + "';";
		user = sqldsToTable().Rows[0];

		Load_friends();
	}

	public void Load_friends()
	{
		Sqlds1.SelectCommand = "select if(f.id_target = '" + Session["myemail"] + "', ur.name, ut.name) as 'fr_name', if(f.id_target = '" + Session["myemail"] + "', ur.img, ut.img) as 'fr_img'" + 
			"from friends f inner join users ur on ur.email = f.id_request inner join users ut on ut.email = f.id_target " + 
			"where status = 'a' and '" + Session["myemail"] + "' in (f.id_target, f.id_request);";
		//sets the query to a Table, witch can be used to list all the friends
		DataTable friends = sqldsToTable();

		//locates the div with id friends_facename
		Control div = FindControl("friends_facename");
		//creates an entry of each friend, entry with img and the name
		foreach(DataRow friend in friends.Rows)
		{
			WebControl entry = new WebControl(HtmlTextWriterTag.Div),
					   pic = new WebControl(HtmlTextWriterTag.Img),
					   name = new WebControl(HtmlTextWriterTag.Span);

			entry.CssClass = "friends-entry";
			pic.CssClass = "friends-pic";
			name.CssClass = "friends-name";
			pic.Attributes["src"] = "images\\" + friend["fr_img"].ToString();
			name.Controls.Add(new LiteralControl(friend["fr_name"].ToString()));

			entry.Controls.Add(pic);
			entry.Controls.Add(name);
			div.Controls.Add(entry);
		}
	}

	private DataTable sqldsToTable()
	{
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}
}
