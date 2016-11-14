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

		string query = "SELECT img, name, pass, sex, bio, birthdate "+
			"FROM users WHERE email = '"+profileId+"';";
		curSettings = Sqlds1.QueryToTable(query).Rows[0];
		//load info
		Load_infos();
	}

	public void Load_infos()
	{
		//load img
		profile_img.Attributes["src"] = FileName.ImgFolder + (string)curSettings["img"];
		//txtName.Text = (string)curSettings["name"]; <- isso tava bugando tudo ... apesar de não fazer sentido... mas ok
		//txtBio.Text = (string)curSettings["bio"];
	}

	public void btnSave_Click(object sender, EventArgs e)
	{
		DataRow newSettings = curSettings.Table.NewRow();
		newSettings.ItemArray = curSettings.ItemArray.Clone() as object[];

		//check if the picture has changed {{{
		if (picture_change.HasFile)
		{
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
		//--Name
		newSettings["name"] = txtName.Text;
		//--password
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
			return;
		}
		//--bio
		newSettings["bio"] = txtBio.Text;
		//}}}

		//compare to see if there is diferences
		//if does: updates db
		if (!curSettings.ItemArray.SequenceEqual(newSettings.ItemArray))
		{
			string updateCommand = "UPDATE users SET" +
				" img = '" + newSettings["img"] + "'," +
				" name = '" + newSettings["name"] + "'," +
				" pass = '" + newSettings["pass"] + "'," +
				" sex = '" + newSettings["sex"] + "'," +
				" bio = '" + newSettings["bio"] + "'," +
				" birthdate = '" + Convert.ToDateTime(newSettings["birthdate"]).ToString("yyyy-MM-dd") + "' " +
				"WHERE email = '" + profileId + "';";
			Sqlds1.UpdateFromQuery(updateCommand);
		}
		Response.Redirect(FileName.Profile);
	}

	public void logout(object sender, EventArgs e)
	{
		this.Logout();
	}
}
