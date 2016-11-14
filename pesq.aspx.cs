using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pesq : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		/*
		 * se tiver session,
		 *   carregar uma parte tipo, myprofile, e etc
		 * se não tiver session,
		 *   carrega só a parte da pesquisa, botão logar
		 */
		if (Session["myemail"] != null)
			Load_infos();

		if (Request.QueryString["q"] != null)
			Load_results(Request.QueryString["q"]);
	}

	public void Load_infos()
	{
		//ainda falta fazer...
	}

	public void Load_results(string query)
	{
		//The Select query for performing the search, could be improved
		DataTable dt = Sqlds1.QueryToTable
			(
			 "SELECT name, img, bio, email FROM users "+
			 "WHERE (email LIKE '%"+query+"%') OR "+
			 "(name LIKE '%"+query+"%');"
			);

		//finds the control where we'll be putting the result stuff
		Control container = FindControl("results_container");
		if (dt.Rows.Count != 0)
			foreach(DataRow result in dt.Rows)
			{
				//create the objects that will be put in the page
				WebControl entry = new WebControl(HtmlTextWriterTag.Div),
						   res_text = new WebControl(HtmlTextWriterTag.Div),
						   pic = new WebControl(HtmlTextWriterTag.Img),
						   anchor1 = new WebControl(HtmlTextWriterTag.A),
						   anchor2 = new WebControl(HtmlTextWriterTag.A),
						   name = new WebControl(HtmlTextWriterTag.H5),
						   res_bio = new WebControl(HtmlTextWriterTag.Span);

				//set the attributes to the objects
				entry.CssClass = "result_entry";
				pic.Attributes["src"] = FileName.ImgFolder + result["img"].ToString();
				string ahref = FileName.Profile+"?user="+result["email"].ToString();
				anchor1.Attributes["href"] = ahref;
				anchor1.Attributes["class"] = "profile_img_wrapper";
				anchor2.Attributes["href"] = ahref;
				name.Controls.Add(new LiteralControl(result["name"].ToString()));
				res_bio.Controls.Add(new LiteralControl(result["bio"].ToString()));

				//adds each control to it's parent and so
				anchor1.Controls.Add(pic);

				anchor2.Controls.Add(name);
				res_text.Controls.Add(anchor2);
				res_text.Controls.Add(res_bio);

				entry.Controls.Add(anchor1);
				entry.Controls.Add(res_text);

				container.Controls.Add(entry);
			}
		else
		{
			container.Controls.Add(new LiteralControl("Nenhum resultado encontrado."));
		}
	}
}
