using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

public partial class Cadastro : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public static string SHA256Generator(string strInput)
	{
		SHA256 sha256 = new SHA256CryptoServiceProvider();

		//provide the string in byte format to the ComputeHash method. 
		//This method returns the SHA-256 hash code in byte array
		byte[] arrHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(strInput));

		// use a Stringbuilder to append the bytes from the array to create a SHA-256 hash code string.
		StringBuilder sbHash = new StringBuilder();

		// Loop through byte array of the hashed code and format each byte as a hexadecimal code.
		for (int i = 0; i < arrHash.Length; i++)
		{
			sbHash.Append(arrHash[i].ToString("x2"));
		}

		// Return the hexadecimal SHA-256 hash code string.
		return sbHash.ToString();
	}

	protected void btnReg_Click(object sender, EventArgs e)
	{
		if(txtName.Text == string.Empty || txtEmail.Text == string.Empty ||
				txtConf.Text == string.Empty || txtPass.Text == string.Empty ||
				txtConfPass.Text == string.Empty)
		{
			if (txtName.Text == string.Empty)
				txtName.CssClass = "emptyTextInput";
			if (txtEmail.Text == string.Empty)
				txtEmail.CssClass = "emptyTextInput";
			if (txtPass.Text == string.Empty)
				txtPass.CssClass = "emptyTextInput";
			if (txtConf.Text == string.Empty)
				txtConf.CssClass = "emptyTextInput";
			if (txtConfPass.Text == string.Empty)
				txtConfPass.CssClass = "emptyTextInput";

		}
		else
		{
			if(txtEmail.Text != txtConf.Text || txtPass.Text != txtConfPass.Text)
			{
				if(txtEmail.Text != txtConf.Text)
					lblDif.Text = "* Os e-mails não coincidem";
				if(txtPass.Text != txtConfPass.Text)
					lblDif.Text = "* As senhas não coincidem";
			}
			else
			{
				string code = SHA256Generator(txtEmail.Text).Substring(0,5);
				string mensagem;

				mensagem = "<p>Olá " + txtName.Text + ",</p>" +
					"<p>Aqui é da Opl Inc., gostariamos de lhe dar boas vindas a nossa rede social! Confirme abaixo suas informações:</p>\n" +
					"<div style='border: solid 1px #ddd; padding:5px 5px; background-color:#eee'>" +
					"<p>Sua senha: " + txtPass.Text + "</p>" +
					"</div>" +
					"<p>Se você fez mesmo esse cadastro, use o codigo abaixo para ativar sua conta:</p>" +
					"<div style='border: solid 1px #ddd; padding:5px 5px; background-color:#eee'>" +
					"<p>Código de ativação: <span style='text-decoration: none; font-weight: bold;'>" + code + "</span></p>" +
					"</div>" +
					"<p>Aqui a gente coloca um footer legal xD</p>";

				MailMessage conf = new MailMessage();
				SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
				System.Net.NetworkCredential cred = new System.Net.NetworkCredential("no.reply.opl@gmail.com", "rinf123456opl");
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = cred;
				smtp.EnableSsl = true;

				conf.Body = mensagem;
				conf.IsBodyHtml = true;
				conf.To.Add(txtEmail.Text);
				conf.Subject = "Ativação da conta - Study o'Clock";
				conf.From = new MailAddress("no.reply.opl@gmail.com");

				//precisa validar o email
				//precisa checar se o email existe
				try
				{
					smtp.Send(conf);
					SqlRinf.Insert();

				    Page.ClientScript.RegisterStartupScript(this.GetType(),"text","nextRegPage(2)",true);
				}
				catch (Exception err)
				{
					//handle it
					//lista de erros:
					//- email já cadastrado
				}
			}
		}
	}

	public void btnLogin_Click(object sender, EventArgs e)
	{
		//call a Login function: to be created
	}
}
