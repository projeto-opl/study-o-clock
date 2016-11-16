using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class Group : System.Web.UI.Page
{

	bool myProfile = false;
	string profileId, groupId;
	DataRow user;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["myemail"] == null)
			Response.Redirect("Login.aspx");
		if (Request.QueryString["user"] != null)
			profileId = Request.QueryString["user"];
		else
			profileId = (string)Session["myemail"];

		if (profileId == (string)Session["myemail"])
			myProfile = true;
		Carregar_os_Coiso();
	}
	string id_group;
	private void Carregar_os_Coiso()
	{
		string command = "select gr.name, rel.is_adm, gr.id from groups gr inner join rel_groups rel on gr.id = rel.id_groups inner join users us on rel.id_users = us.email where gr.id = 2 and us.email = 'vhoyer@live.com';";//+profileId+"';";
		DataTable Group = sqlds1.QueryToTable(command);
		lblGroup.Text = Group.Rows[0][0].ToString();
		string is_adm = Group.Rows[0][1].ToString();
		if (is_adm == "0") btnEdit.Visible = false;
		id_group = Group.Rows[0][2].ToString();
	}

	private void Mudar_nome()
	{
		string command = "Update groups gr SET gr.name = '" + txtEdit.Text + "' where gr.id = 2;";
		sqlds1.UpdateCommand = command;
		sqlds1.Update();
	}

	protected void btnMembros_Click(object sender, EventArgs e)
	{
		Response.Redirect("Members.aspx");
	}

	protected void btnEdit_Click(object sender, EventArgs e)
	{
		if(!txtEdit.Visible)
		{
			lblGroup.Text = "";
			txtEdit.Visible = true;
			btnEdit.Text = "Finalizar";
		} else
		{
			Mudar_nome();
			lblGroup.Text = txtEdit.Text;
			txtEdit.Text = null;
			txtEdit.Visible = false;
			btnEdit.Text = "Editar";
		}

	}
}
