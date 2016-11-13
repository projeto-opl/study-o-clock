public static class CommonRoutine
{
	public static void Logout(this System.Web.UI.Page This)
	{
		This.Session.Abandon();
		This.Response.Redirect(FileName.Login);
	}
}
