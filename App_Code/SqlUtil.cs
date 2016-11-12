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
}
