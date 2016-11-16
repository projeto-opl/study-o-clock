using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
{
	bool myPost = false;
	string postId;
	DataRow post;

	protected void Page_Load(object sender, EventArgs e)
	{
		//testa pra ver se ta logado, se não tiver, volta pro login
		if(Session["myemail"] == null)
		{
			//build link to go back to this page after login
			string link;
			if (Request.QueryString["p"] != null)
				link = FileName.Login+"?r="+FileName.Post+"&qsal=1&qs0=p&qv0="+ Request.QueryString["p"];
			else
				link = FileName.Login+"?r="+FileName.Post;

			Response.Redirect(link);
		}

		//se tiver Qs, seta o id da pagina para ele
		if (Request.QueryString["p"] != null)
			postId = Request.QueryString["p"];

		try
		{
			post = Sqlds1.QueryToTable(
					"SELECT"+
					" u.name,"+
					" u.email,"+
					" g.name,"+
					" p.`date`,"+
					" p.`time`,"+
					" p.content,"+
					" p.can_comments"+
					" FROM"+
					" posts p inner join"+
					" users u on u.email = p.id_users left join"+
					" groups g on g.id = p.id_groups"+
					" WHERE p.id = '"+postId+"';"
					).Rows[0];
		}
		catch (IndexOutOfRangeException)
		{
			Response.Redirect("error/404");
		}

		//se a pagina for a mesma da session, o post é seu
		if ((string)post["email"] == (string)Session["myemail"])
			myPost = true;

		Load_Post();
	}

	public void Load_Post()
	{
		post_title.Text = "<a href='"+FileName.Profile+"?user="+post["email"]+"'>"+ post["name"] + "</a> postou ";
		if (post["name1"].ToString() != "")
			post_title.Text += " no grupo <a href='#'>" + post["name1"] + "</a>";
		post_title.Text += " em " + Convert.ToDateTime(post["date"]).ToString("dd/MM/yyyy") + " " + post["time"];

		post_content.Controls.Add(new LiteralControl((string)post["content"]));

		load_comments();
	}

	public void btnComment_click(object sender, EventArgs e)
	{
		if (txtComment_content.Text == "")
			return;

		//set os padroes da pesquisa
		string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

		//faz a pesquisa propriamente dita
		Sqlds1.InsertFromQuery("INSERT INTO comments(id_posts, id_users, content, `datetime`)"+
				"VALUES('"+postId+"','"+post["email"]+"','"+txtComment_content.Text+"', '"+datetime+"');");
		txtComment_content.Text = "";
		Response.Redirect(Request.Url.ToString(), true);
	}

	//Post stuff /*{{{*/
	//numero maximo de posts por carregamento
	int sanityControl = 30;
	//maximo de commentarios
	int maxComments = 3;
	private void load_comments()
	{
		if (!(bool)post["can_comments"])
			return;

		DataTable dt = Sqlds1.QueryToTable(
				"SELECT"+
				"	u.name,"+
				"	u.email,"+
				"	u.img,"+
				"	c.`datetime`,"+
				"	c.content"+
				"	FROM"+
				"	comments c inner join"+
				"	users u on u.email = c.id_users"+
				"	WHERE c.id_posts = '"+postId+"'"+
				"	ORDER BY c.id DESC;"
				);

		//findcontrol mais cmplicado pq to usando master page
		Control comments_wrapper = Master.FindControl("cph").FindControl("comments_container");
		//essa é a parte onde se colocam os controles dentro de outros
		//e vc não quer ver isso, nem voce, nem eu xD
		//foreach do capiroto {{{
		if (Session["showMore"] == null || !(bool)Session["showMore"])
		{
			Session["postsInPage"] = 0;
		}
		int maxPosts = dt.Rows.Count, //total de posts pelo usuario
			entriesInPage = (int)Session["postsInPage"];
		Session["postsInPage"] = 0;

		foreach(DataRow comment in dt.Rows)
		{
			//passando do saniyControl ele quebra o loop, pra limitar
			//o numero de posts por pagina
			if ((int)Session["postsInPage"] > entriesInPage + sanityControl - 1)
				break;

			//create things
			WebControl commenter_img = new WebControl(HtmlTextWriterTag.Img),
					   commenter_name = new WebControl(HtmlTextWriterTag.H6),
					   commenter_comment = new WebControl(HtmlTextWriterTag.P);

			//config things
			commenter_img.Attributes["src"] = FileName.ImgFolder + comment["img"];
			commenter_name.Controls.Add(new LiteralControl(
						"<a href='"+FileName.Profile+"?user="+comment["email"]+"'>"
						+ comment["name"] +
						"</a> comentou em " + comment["datetime"]));
			commenter_comment.Controls.Add(new LiteralControl(
						(string)comment["content"]));

			//finish adding everthing to its place
			comments_wrapper.Controls.Add(new LiteralControl("<article><div class='profile_img_wrapper pic_xsmall comment-img'>"));
			comments_wrapper.Controls.Add(commenter_img);
			comments_wrapper.Controls.Add(new LiteralControl("</div><div class='comment-text'>"));
			comments_wrapper.Controls.Add(commenter_name);
			comments_wrapper.Controls.Add(commenter_comment);
			comments_wrapper.Controls.Add(new LiteralControl("</div></article>"));

			//updates postinprofile to continuos loading posts
			Session["postsInPage"] = (int)Session["postsInPage"] + 1;
		}
		//}}}
		//se tiver mais posts para mostrar coloca o "show more" na pagina
		if ((int)Session["postsInPage"] < maxPosts)
			comments_wrapper.Controls.Add(CreateShowMore());
		Session["showMore"] = false;
	}

	public void ShowMore(object sender, EventArgs e)
	{
		Session["showMore"] = true;
	}

	private WebControl CreateShowMore()
	{
		WebControl showMore = new WebControl(HtmlTextWriterTag.Div);
		showMore.Attributes["id"] = "showMore";
		showMore.Attributes["onclick"] = "getElementById('btnShowMore').click();";
		showMore.Controls.Add(new LiteralControl("<a>Mostrar mais</a>"));
		return showMore;
	}/*}}}*/
}
