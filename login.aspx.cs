using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
	}

	public void makeLogin(object sender, EventArgs e)
	{
		if (txtEmail.Text != "" && txtPass.Text != "")
		{
			txtEmail.Style["border-color"] = "none";
			txtPass.Style["border-color"] = "none";

			DataTable dt = sqldsToTable("SELECT validated FROM users WHERE email = '"+txtEmail.Text+"' AND pass = '"+txtPass.Text+"'");
			if (dt.Rows.Count != 0)
			{
				//
				// Login Aqui
				//
				if ((bool)dt.Rows[0]["validated"])
				{
					Session["myemail"] = txtEmail.Text;
					if (Request.QueryString["r"] != null)
					{
						//se tiver redirect -> vai pra la
						redirect(Request.QueryString["r"]);
					}
					else
					{
						//endereço padrão -> depois login
						Response.Redirect(FileName.Profile+"?user="+txtEmail.Text);
					}
				}
				else if (Request.QueryString["r"] == "cadastro.aspx")
				{
					//faz o redirect funcionar mesmo se a conta não estiver validada
					redirect(Request.QueryString["r"]);
				}
				else
				{
					//se não tiver ativada, não tier redirect mas existir
					lblError.Text = "Conta nao ativada.";
				}
			}
			else
			{
				//refaz a query pra ver se o email não esta cadastrado ou só digitaram a senha errada
				dt = sqldsToTable("SELECT validated FROM users WHERE email = '"+txtEmail.Text+"';");
				if (dt.Rows.Count == 0)
					lblError.Text = "Email não cadastrado.";
				else
					lblError.Text = "Senha incorreta.";
				txtPass.Text = "";
			}
		}
		else
		{
			txtEmail.Style["border-color"] = "red";
			txtPass.Style["border-color"] = "red";
			lblError.Text = "Os Campos em vermelho sao obrigatorios.";
		}
	}

	private DataTable sqldsToTable(string selectQuery)
	{
		Sqlds1.SelectCommand = selectQuery;
		DataView view = (DataView)Sqlds1.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}

	private void redirect(string link)
	{
		//metodo do redirect
		//se não tiverem QueryStrings para pensar, vai direto
		if (Request.QueryString["qsal"] == null || Request.QueryString["qsal"] == "0")
			Response.Redirect(link);

		//se tiver QueryString, refaz o link do jeito certo e segue o link
		int arrLenght = Convert.ToInt32(Request.QueryString["qsal"]);
		string qss = "?" + Request.QueryString["qs0"] + "=" + Request.QueryString["qv0"];
		for (int i = 1; i > arrLenght; i++)
		{
			qss += "&" + Request.QueryString["qs" + i] + "=" + Request.QueryString["qv" + i];
		}
		Response.Redirect(link + qss);
	}
}
