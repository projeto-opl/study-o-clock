using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public class MessageBox
{
	/// <summary>
	/// Displays an Message Box with the defined Text and title, current supporting only "okCancel" Buttons
	/// </summary>
	/// <param name="pag">just enter this in here</param>
	/// <param name="id">identifier for uniqueness, nice word xD</param>
	/// <param name="_message">Message shown in message box body</param>
	/// <param name="_title">Title shown in message box head</param>
	/// <param name="_buttons">array, each string is the text for a button, to make methods for the message box, just add in the page.aspx.cs a method name "btn" + id + name of the button + "_Click", first letter of button name is capital</param>
	public static void Show(Page pag, string _message, string _title, Dictionary<string, EventHandler> _buttons)
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

		foreach(KeyValuePair<string,EventHandler> btn in _buttons)
		{
			Button _btn = new Button();
			_btn.ID = "btn" + nameRefactoring(btn.Key);
			_btn.Text = btn.Key;
			_btn.UseSubmitBehavior = false;
			if (btn.Value != null)
				_btn.Click += btn.Value;
			else
				_btn.Click += closeLightBox;

			controlBox.Controls.Add(_btn);
		}

		container.Controls.Add(title);
		container.Controls.Add(content);
		container.Controls.Add(controlBox);
		lightBox.Controls.Add(container);
		pag.Form.Controls.Add(lightBox);
	}

	public static void closeLightBox(object sender, EventArgs e)
	{
		Control thisControl = (sender as Control).Page.Form;
		thisControl.Controls.Remove(thisControl.FindControl("lightBox"));
	}

	private static string nameRefactoring(string str)
	{
		return str.Remove(1).ToUpper() + str.Substring(1).ToLower();
	}
}
