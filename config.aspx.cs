using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class config : System.Web.UI.Page
{
	DataRow curSettings;
	string profileId = "";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["myemail"] == null)
			Response.Redirect(FileName.Login+"?r="+FileName.Config);
		else
			profileId = (string)Session["myemail"];

		curSettings = Sqlds1.QueryToTable(
			"SELECT"+
			" img,"+
			" name,"+
			" pass,"+
			" bio"+
			" FROM users"+
			" WHERE email = '"+profileId+"';"
			).Rows[0];

		//load info
		Load_infos();
	}

	public void Load_infos()
	{
		//load img
		profile_img.Attributes["src"] = FileName.ImgFolder + (string)curSettings["img"];
	}

	///<summary>
	///Salva as novas configurações
	///</summary>
	public void btnSave_Click(object sender, EventArgs e)
	{
		//cria uma linha para salvar as alterações baseada no esquema da tabela do 'curSetting'
		DataRow newSettings = curSettings.Table.NewRow();
		//clona os valores das colunas
		newSettings.ItemArray = curSettings.ItemArray.Clone() as object[];

		//check if the picture has changed {{{
		if (picture_change.HasFile)
		{
			//cria o caminho do arquivo
			string filename = picture_change.FileName;
			filename = Path.GetFileName(filename);
			filename = FileName.ImgFolder + filename;

			//check if file exists
			if (System.IO.File.Exists(Server.MapPath(filename)))
			{
				int count = 1;
				string addtoFileName = count.ToString();
				//keeps trying till it finds a 'free' name
				while (System.IO.File.Exists(
							Path.AppendToFileNameNotExt(filename, addtoFileName)
							))
				{
					addtoFileName = count.ToString();
					count++;
				}
				filename = Path.AppendToFileNameNotExt(filename, addtoFileName);
			}

			//saves file to the server
			picture_change.SaveAs(Server.MapPath(filename));
			newSettings["img"] = Path.GetFileName(filename);
		}
		//}}}
		//assign txtbox value to the newSettings {{{

		//
		// Name
		//
		if (txtName.Text != "")
			newSettings["name"] = txtName.Text;

		//
		// password
		//
		bool test1 = (new TextBox[] { txtPass1, txtPass2}.All(x => x.Text != "")),
			 test2 = txtPass1.Text == txtPass2.Text;
		if (test1 && test2)
		{
			newSettings["pass"] = txtPass1.Text;
		}
		else if (!test2)
		{
			txtPass1.Style.Add("border-color", "red !important");
			txtPass2.Style.Add("border-color", "red !important");
			lblPassError.Text = "As senhas inseridas não coincidem.";
			return; //para a execução do methodo para não salvar se a senha estiver errada
		}

		//
		// bio
		//
		if (txtBio.Text != "")
			newSettings["bio"] = txtBio.Text;
		//}}}

		//compare to see if there is diferences
		//if does: updates db
		if (!curSettings.ItemArray.SequenceEqual(newSettings.ItemArray))
		{
			string updateCommand =
				"UPDATE users SET" +
				" img = '" + newSettings["img"] + "'," +
				" name = '" + newSettings["name"] + "'," +
				" pass = '" + newSettings["pass"] + "'," +
				" bio = '" + newSettings["bio"] + "' " +
				"WHERE email = '" + profileId + "';";

			Sqlds1.UpdateFromQuery(updateCommand);
		}
		//depois que terminar a edução/clicar em salvar, volta para a Profile
		Response.Redirect(FileName.Profile);
	}
}
