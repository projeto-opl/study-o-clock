using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nav : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void logout(object sender, EventArgs e)
	{
		Session.Abandon();
		Response.Redirect(FileName.Login);
	}

	public void btnPesq_Click(object sender, EventArgs e)
	{
		if (txtSearchBox.Text != "")
			Response.Redirect(FileName.PesqPage+"?q="+txtSearchBox.Text);
	}
}
