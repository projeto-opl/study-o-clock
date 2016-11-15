using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public static class SqlUtil
{
	public static DataTable QueryToTable(this SqlDataSource sqlds, string selectQuery)
	{
		sqlds.SelectCommand = selectQuery;
		DataView view = (DataView)sqlds.Select(new DataSourceSelectArguments());
		return view.ToTable();
	}

	public static int UpdateFromQuery(this SqlDataSource sqlds, string query)
	{
		sqlds.UpdateCommand = query;
		return sqlds.Update();
	}

	public static int InsertFromQuery(this SqlDataSource sqlds, string query)
	{
		sqlds.InsertCommand = query;
		return sqlds.Insert();
	}
}
