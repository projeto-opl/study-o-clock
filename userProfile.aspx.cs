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
		Session["email"] = "vhoyer@live.com";
		Sqlds1.SelectCommand = "SELECT name FROM users WHERE email = '" + Session["email"] + "';";
		user = sqldsToTable().Rows[0];

		Load_infos();
	}

	public void Load_infos()
	{
		lblName.Text = user["name"].ToString();
		Load_friends();
	}

	public void Load_friends()
	{
		Sqlds1.SelectCommand = "select if(f.id_target = '" + Session["email"] + "', ur.name, ut.name) as 'amigos' " + 
			"from friends f inner join users ur on ur.email = f.id_request inner join users ut on ut.email = f.id_target " + 
			"where status = 'a' and '" + Session["email"] + "' in (f.id_target, f.id_request);";
		DataTable friends = sqldsToTable();
		gdFriends.DataSourceID = "Sqlds1";
	}

	private DataTable sqldsToTable()
	{
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}
}
