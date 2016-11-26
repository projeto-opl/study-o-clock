﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profileHeader : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void Load_infos()
	{
		//
		//Opções que vão aparecer para todos, independente se é o perfil é meu ou não
		//
		//--nome
		lblName.Text = user["name"].ToString();
		//--img
		imgProfilePicture.ImageUrl = FileName.ImgFolder + user["img"].ToString();
		//--bio
		lblBio.Text = "Este usuario nao tem bio";
		if (user["bio"].ToString() != "")
			lblBio.Text = user["bio"].ToString();

		//controla o que aparece se o perfil for meu ou não
		if (myProfile)
		{
		}
		else
		{
			//btnFollow.Visible = true;
			//updateFeedBtn();

			btnAddFriend.Visible = true;
			updateFriendBtn();
		}
	}

	public void showFriends(object sender, EventArgs e)
	{
		Response.Redirect(FileName.FriendList+"?user=" + profileId);
	}

	public void showGroups(object sender,EventArgs e)
	{
		Response.Redirect(FileName.UserGroups+"?u="+profileId);
	}

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