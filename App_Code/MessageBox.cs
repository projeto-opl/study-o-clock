using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class MessageBox
{
	public enum result
	{
		ok = 1, cancel = 0
	}

    /// <summary>
    /// Displays an Message Box with the defined Text and title, current supporting only "okCancel" Buttons
    /// </summary>
    /// <param name="pag">just enter this in here</param>
	/// <param name="id">identifier for uniqueness, nice word xD</param>
    /// <param name="_message">Message shown in message box body</param>
    /// <param name="_title">Title shown in message box head</param>
    /// <param name="_buttons">array, each string is the text for a button, to make methods for the message box, just add in the page.aspx.cs a method name "btn" + id + name of the button + "_Click", first letter of button name is capital</param>
	public static void Show(Page pag, string _id, string _message, string _title, string[] _buttons)
	{
		Control lb = pag.Form.FindControl("lightBox");
		pag.Form.Controls.Remove(lb);


		WebControl lightBox = new WebControl(HtmlTextWriterTag.Div),
				   container = new WebControl(HtmlTextWriterTag.Div),
				   title = new WebControl(HtmlTextWriterTag.Div),
				   content = new WebControl(HtmlTextWriterTag.P),
				   controlBox = new WebControl(HtmlTextWriterTag.Div);

		lightBox.ID = "lightBox";
		container.ID = "container";
		title.ID = "title";
		title.Controls.Add(new LiteralControl(_title));
		content.Controls.Add(new LiteralControl(_message));
		controlBox.CssClass = "controlBox";

		foreach(string btn in _buttons)
		{
			WebControl _btn = new WebControl(HtmlTextWriterTag.Input);
			_btn.ID = "btn" + nameRefctoring(btn);
			_btn.Attributes["type"] = "button";
			_btn.Attributes["value"] = btn;
			_btn.Attributes["onClick"] = "javascript:__doPostBack('btn" + nameRefctoring(_id) + nameRefctoring(btn) + "_Click','')";

			controlBox.Controls.Add(_btn);
		}

		container.Controls.Add(title);
		container.Controls.Add(content);
		container.Controls.Add(controlBox);
		lightBox.Controls.Add(container);
		pag.Form.Controls.Add(lightBox);
	}

	private static string nameRefctoring(string str)
	{
		return str.Remove(1).ToUpper() + str.Substring(1).ToLower();
	}
}
