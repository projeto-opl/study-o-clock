using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userProfile : System.Web.UI.Page
{
	DataRow user;
	protected void Page_Load(object sender, EventArgs e)
	{
		Session["my]email"] = "vhoyer@live.com";
		Sqlds1.SelectCommand = "SELECT name, img FROM users WHERE email = '" + Session["my]email"] + "';";
		user = sqldsToTable().Rows[0];

		Load_infos();
	}

	public void Load_infos()
	{
		lblName.Text = user["my]name"].ToString();
		imgProfilePicture.ImageUrl = "~/images/" + user["my]img"].ToString();
	}

	private DataTable sqldsToTable()
	{
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}
}
