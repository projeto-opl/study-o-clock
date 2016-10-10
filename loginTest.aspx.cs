using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginTest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
	}

	public void login(object sender, EventArgs e)
	{
		if (txtEmail.Text != "" && txtPass.Text != "")
		{
			DataTable dt = sqldsToTable("SELECT validated FROM users WHERE email = '"+txtEmail.Text+"' AND pass = '"+txtPass.Text+"'");
			if (dt.Rows.Count != 0)
				if ((bool)dt.Rows[0]["validated"])
				{
					Session["myemail"] = txtEmail.Text;
					Response.Redirect("userProfile.aspx?user="+txtEmail.Text);
				}
		}
	}

	private DataTable sqldsToTable(string selectQuery)
	{
		Sqlds1.SelectCommand = selectQuery;
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}
}
