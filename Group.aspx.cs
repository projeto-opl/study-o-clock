using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Group : System.Web.UI.Page
{
	bool isAdm = false;
	string groupId;
	DataRow user;

	protected void Page_Load(object sender, EventArgs e)
	{
		//testa pra ver se ta logado, se não tiver, volta pro login
		if(Session["myemail"] == null)
		{
			//build link to go back to this page after login
			string link;
			if (Request.QueryString["g"] != null)
				link = FileName.Login+"?r="+FileName.Group+"&qsal=1&qs0=g&qv0="+ Request.QueryString["g"];
			else
				link = FileName.Login+"?r="+FileName.Group;

			Response.Redirect(link);
		}

		//se tiver Qs, seta o id da pagina para ele
		if (Request.QueryString["g"] != null)
			groupId = Request.QueryString["g"];
		else
			groupId = (string)Session["myemail"];

		try
		{
			string command = "select gr.name, rel.is_adm, gr.id from groups gr inner join rel_groups rel on gr.id = rel.id_groups inner join users us on rel.id_users = us.email"+
				" where gr.id = '"+groupId+"' and us.email = '"+Session["myemail"]+"';";
			user = Sqlds1.QueryToTable(command).Rows[0];
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
		lblGroup.Text = user["name"].ToString();
		imgProfilePicture.ImageUrl = "images/group.png";

		//controla o que aparece se o perfil for meu ou não
		if ((bool)user["is_adm"])
		{
			btnEdit.Visible = true;
		}
	}
	private void Mudar_nome()
	{
		string command = "Update groups gr SET gr.name = '" + txtEdit.Text + "' where gr.id = 2;";
		Sqlds1.UpdateCommand = command;
		Sqlds1.Update();
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
