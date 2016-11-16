using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Group : System.Web.UI.Page
{
	bool myProfile = false;
	string profileId;
	DataRow user;

	protected void Page_Load(object sender, EventArgs e)
	{
		//testa pra ver se ta logado, se não tiver, volta pro login
		if(Session["myemail"] == null)
		{
			//build link to go back to this page after login
			string link;
			if (Request.QueryString["user"] != null)
				link = FileName.Login+"?r="+FileName.Profile+"&qsal=1&qs0=user&qv0="+ Request.QueryString["user"];
			else
				link = FileName.Login+"?r="+FileName.Profile;

			Response.Redirect(link);
		}

		//se tiver Qs, seta o id da pagina para ele
		if (Request.QueryString["user"] != null)
			profileId = Request.QueryString["user"];
		else
			profileId = (string)Session["myemail"];

		//se a pagina for a mesma da session, o perfil é seu
		if (profileId == (string)Session["myemail"])
			myProfile = true;

		try
		{
			user = Sqlds1.QueryToTable("SELECT name, img, bio FROM users WHERE email = '" + profileId + "';").Rows[0];
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
		lblName.Text = user["name"].ToString();
		imgProfilePicture.ImageUrl = FileName.ImgFolder + user["img"].ToString();
		lblBio.Text = "Este usuario nao tem bio";
		if (user["bio"].ToString() != "")
			lblBio.Text = user["bio"].ToString();

		//controla o que aparece se o perfil for meu ou não
		if (myProfile)
		{
		}
		else
		{
		}
	}
	public void logout(object sender, EventArgs e)
	{
		this.Logout();
	}

	public void showFriends(object sender, EventArgs e)
	{
		Response.Redirect(FileName.FriendList+"?user=" + profileId);
	}

	public void showGroups(object sender,EventArgs e)
	{
		Response.Redirect(FileName.UserGroups+"?u="+profileId);
	}
}
