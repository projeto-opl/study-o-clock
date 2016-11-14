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
	}

	public void btnSave_Click(object sender, EventArgs e)
	{
		DataRow newSettings = curSettings.Table.NewRow();
		newSettings.ItemArray = curSettings.ItemArray.Clone() as object[];

		//check if the picture has changed
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
