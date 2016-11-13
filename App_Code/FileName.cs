using System;

public static class FileName
{
	static string login = "login.aspx",
		   cadastro = "cadastro.aspx",
		   friendList = "userFriends.aspx",
		   profile = "userProfile.aspx",
		   pesqPage = "pesq.aspx",
		   imgFolder = "images/";

	public static string Login { get { return login; } }
	public static string Cadastro { get { return cadastro; } }
	public static string FriendList { get { return friendList; } }
	public static string Profile { get { return profile; } }
	public static string PesqPage { get { return pesqPage; } }
	public static string ImgFolder { get { return imgFolder; } }
}
