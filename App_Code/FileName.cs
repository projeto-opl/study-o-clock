using System;

public static class FileName
{
	static string login = "login.aspx",
		   cadastro = "cadastro.aspx",
		   friendList = "userFriends.aspx",
		   profile = "userProfile.aspx",
		   pesqPage = "pesq.aspx",
		   config = "config.aspx",
		   post = "post.aspx",
		   userGroups = "userGroups.aspx",
		   group = "Group.aspx",
		   groupMembers = "",
		   imgFolder = "images/userProfile/";

	public static string Login { get { return login; } }
	public static string Cadastro { get { return cadastro; } }
	public static string FriendList { get { return friendList; } }
	public static string Profile { get { return profile; } }
	public static string PesqPage { get { return pesqPage; } }
	public static string Config { get { return config; } }
	public static string Post { get { return post; } }
	public static string UserGroups { get { return userGroups; } }
	public static string Group { get { return group; } }
	public static string GroupMembers { get { return groupMembers; } }
	public static string ImgFolder { get { return imgFolder; } }
}
