using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userProfile : System.Web.UI.Page
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
		load_posts();

		//controla o que aparece se o perfil for meu ou não
		if (myProfile)
		{
			post_control.Visible = true;
		}
		else
		{
			//btnFollow.Visible = true;
			//updateFeedBtn();

			btnAddFriend.Visible = true;
			updateFriendBtn();
		}
	}
#region "commonProfile"/*{{{*/
	public void logout(object sender, EventArgs e)
	{
		this.Logout();
	}

	public void showFriends(object sender, EventArgs e)
	{
		Response.Redirect(FileName.FriendList+"?user=" + profileId);
	}

	public void btnPesq_Click(object sender, EventArgs e)
	{
		if (txtSearchBox.Text != "")
			Response.Redirect(FileName.PesqPage+"?q="+txtSearchBox.Text);
	}

	//Post stuff /*{{{*/
	//numero maximo de posts por carregamento
	int sanityControl = 10;
	//maximo de commentarios
	int maxComments = 3;
	private void load_posts()
	{
		DataTable dt = Sqlds1.QueryToTable(
				"Select p.id, u.name, p.id_groups, p.content, p.`date`, p.`time`, p.can_comments "+
				"FROM posts p INNER JOIN users u ON u.email = p.id_users WHERE p.id_users = '"+profileId+"' ORDER BY p.id DESC");

		Control posts_wrapper = FindControl("posts_wrapper");
		//essa é a parte onde se colocam os controles dentro de outros
		//e vc não quer ver isso, nem voce, nem eu xD
		//foreach do capiroto {{{
		if (Session["showMore"] == null || !(bool)Session["showMore"])
		{
			Session["postsInPage"] = 0;
		}
		int maxPosts = dt.Rows.Count, //total de posts pelo usuario
			postinpage = (int)Session["postsInPage"];
		Session["postsInPage"] = 0;
		foreach (DataRow Post in dt.Rows)
		{
			//passando do saniyControl ele quebra o loop, pra limitar
			//o numero de posts por pagina
			if ((int)Session["postsInPage"] > postinpage + sanityControl - 1)
				break;

			//cria os componentes
			WebControl post = new WebControl(HtmlTextWriterTag.Div),
					   link = new WebControl(HtmlTextWriterTag.A),
					   post_title = new WebControl(HtmlTextWriterTag.H5),
					   post_body = new WebControl(HtmlTextWriterTag.P),
					   comments_wrapper = new WebControl(HtmlTextWriterTag.Div),
					   hr = new WebControl(HtmlTextWriterTag.Hr);

			post.CssClass = "post";
			link.Attributes["href"] = FileName.Post + "?p=" + Post["id"];
			link.Controls.Add(new LiteralControl("Ver o post inteiro"));
			post_title.Controls.Add(new LiteralControl(
						Post["name"] +
						" postou em " + Convert.ToDateTime(Post["date"]).ToString("dd/MM/yyyy") + 
						" " + Post["time"]
						));
			post_body.Controls.Add(new LiteralControl((string)Post["content"]));
			comments_wrapper.CssClass = "comments_wrapper";

			if ((bool)Post["can_comments"])
			{
				//query dos commentarios
				DataTable comments = Sqlds1.QueryToTable(
						"SELECT"+
						"	u.name,"+
						"	u.email,"+
						"	u.img,"+
						"	c.`datetime`,"+
						"	c.content"+
						"	FROM"+
						"	comments c inner join"+
						"	users u on u.email = c.id_users"+
						"	WHERE c.id_posts = '"+Post["id"]+"'"+
						"	ORDER BY c.id DESC"+
						"	LIMIT "+maxComments+";"
						);

				foreach(DataRow comment in comments.Rows)
				{
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
					comments_wrapper.Controls.Add(new LiteralControl("<div><div class='profile_img_wrapper pic_xsmall comment-img'>"));
					comments_wrapper.Controls.Add(commenter_img);
					comments_wrapper.Controls.Add(new LiteralControl("</div><div class='comment-text'>"));
					comments_wrapper.Controls.Add(commenter_name);
					comments_wrapper.Controls.Add(commenter_comment);
					comments_wrapper.Controls.Add(new LiteralControl("</div></div><hr />"));
				}
			}

			//finish by adding everything to its place
			post.Controls.Add(post_title);
			post.Controls.Add(post_body);
			post.Controls.Add(link);
			post.Controls.Add(hr);
			post.Controls.Add(comments_wrapper);
			posts_wrapper.Controls.Add(post);

			//updates postinprofile to continuos loading posts
			Session["postsInPage"] = (int)Session["postsInPage"] + 1;
		}
		//}}}
		//se tiver mais posts para mostrar coloca o "show more" na pagina
		if ((int)Session["postsInPage"] < maxPosts)
			posts_wrapper.Controls.Add(CreateShowMore());
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
#endregion/*}}}*/
#region "myProfile"/*{{{*/
	public void btnPost_Click(object sender, EventArgs e)
	{
		if (txtPost_content.Text == "")
			return;

		//
		//Falta colocar os comentarios
		//
		//set os padroes da pesquisa
		string content = txtPost_content.Text,
			   id_users = (string)Session["myemail"],
			   date = DateTime.Now.ToString("yyyy-MM-dd"),
			   time = DateTime.Now.ToString("HH:mm:ss"),
			   can_comments = "1";

			   //faz a pesquisa propriamente dita
			   Sqlds1.InsertFromQuery(
					   "INSERT INTO posts(id_users, content, `date`, `time`, can_comments) " +
					   "VALUES('"+id_users+"', '"+content+"', '"+date+"','"+time+"', '"+can_comments+"')"
					   );
			   txtPost_content.Text = "";
			   Response.Redirect(Request.Url.ToString(), true);
	}
#endregion/*}}}*/
#region "othersProfile"/*{{{*/
#region "Friend Request"/*{{{*/
	public void friendRequest(object sender, EventArgs e)
	{
		string res = testForFriendship("status");
		if (res == null || res == "d")
		{
			Sqlds1.InsertCommand = "insert into friends(id_request, id_target, date_sent) values "+
				"('"+Session["myemail"]+"', '"+profileId+"', now());";
			Sqlds1.Insert();
			//if (!testForFeed())
			//addFeed(e,e);
			//Send Notification
		}
		else if (res == "p")
		{
			if (testForFriendship("id_request") == (string)Session["myemail"])
			{
				//opens lightbox asking if want to send another notification
			}
			else
			{
				Sqlds1.UpdateCommand = "UPDATE friends SET `status` = 'a', date_anwser = NOW() WHERE '"+
					Session["myemail"]+"' in (id_target, id_request) AND '"+
					profileId+"' in (id_target, id_request) ORDER BY id DESC LIMIT 1;";
				Sqlds1.Update();
			}
		}
		else if (res == "a")
		{
			//opens lightbox asking if want to cancel friendship
			Sqlds1.UpdateCommand = "UPDATE friends SET `status` = 'd' WHERE '"+
				Session["myemail"]+"' in (id_target, id_request) AND '"+
				profileId+"' in (id_target, id_request)";
			Sqlds1.Update();
		}
		updateFriendBtn();
	}

	public string testForFriendship(string column)
	{
		DataTable dt = Sqlds1.QueryToTable("select `status` as 'status', id_request "+ 
				"from friends "+
				"where '"+Session["myemail"]+"' in (id_target, id_request) AND '"+profileId+"' in (id_target, id_request) ORDER BY id DESC;");

		if(dt.Rows.Count == 0)
			return null;
		else
			return dt.Rows[0][column].ToString();
	}

	public void updateFriendBtn()
	{
		string res = testForFriendship("status");
		if(res == null || res == "d")
		{
			btnAddFriend.Text = "Adicionar amigo?";
		}
		else if (res == "p")
		{
			if (testForFriendship("id_request") == (string)Session["myemail"])
			{
				btnAddFriend.Text = "Solicitacao enviada";
			}
			else
			{
				btnAddFriend.Text = "Aceitar Solicitacao?";
			}
		}
		else if (res == "a")
		{
			btnAddFriend.Text = "Desfazer amizade?";
		}
	}
#endregion/*}}}*/
#endregion/*}}}*/
#region "encapsulated"/*{{{*/
	public DataRow CurUser { get { return user; } }
#endregion/*}}}*/
}
#region "commended/feed"/*{{{*/
	/*
	 *tem que adicionar o botão no .aspx pq o asp não sabe o que é comentario
	 */
#region "Feed"/*{{{*/
	//public void addFeed(object sender, EventArgs e)
	//{
	//if(!testForFeed())
	//{
	//Sqlds1.InsertCommand = "insert into feeds(id_me, id_following) values ('"+Session["myemail"]+"', '"+profileId+"');";
	//Sqlds1.Insert();
	//}
	//else
	//{
	//Sqlds1.DeleteCommand = "DELETE FROM feeds WHERE id_me = '"+Session["myemail"]+"' AND id_following = '"+profileId+"';";
	//Sqlds1.Delete();
	//}
	//updateFeedBtn();
	//}

	//public bool testForFeed()
	//{
	//DataTable dt = Sqlds1.QueryToTable("SELECT id_me, id_following FROM feeds WHERE id_me = '"+Session["myemail"]+"' AND id_following = '"+profileId+"';");

	//if (dt.Rows.Count == 0)
	//return false;
	//else
	//return true;
	//}

	//public void updateFeedBtn()
	//{
	//if(!testForFeed())
	//btnFollow.Text = "Seguir essa pessoa?";
	//else
	//btnFollow.Text = "Deixar de seguir?";
	//}
#endregion/*}}}*/
#endregion/*}}}*/
