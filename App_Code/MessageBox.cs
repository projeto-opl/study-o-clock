using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class MessageBox
{
	public enum result
	{
		ok = 1, cancel = 0
	}
	public enum btns
	{
		OkCancel = 1
	}

    /// <summary>
    /// Displays an Message Box with the defined Text and title, current supporting only "okCancel" Buttons
    /// </summary>
    /// <param name="pag">just enter this in here</param>
    /// <param name="_message">Message shown in message box body</param>
    /// <param name="_title">Title shown in message box head</param>
    /// <param name="_buttons">Buttuns pattern for user interaction, to make methods for the message box, just add in the page.aspx.cs a method name "btn" + name of the button + "_Click", first letter of button name is capital</param>
	public static void Show(Page pag, string _message, string _title, btns _buttons)
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

		if ((int)_buttons == 1)
		{
			Button btnOk = new Button(),
				   btnCancel = new Button();
			btnOk.Attributes["type"] = "button";
			btnOk.Text = "ok";
			btnOk.Attributes["onClick"] = "btnOk_Click";
			btnCancel.Attributes["type"] = "button";
			btnCancel.Text = "cancel";
			btnCancel.Attributes["onClick"] = "btnCancel_Click";

			controlBox.Controls.Add(btnOk);
			controlBox.Controls.Add(btnCancel);
		}

		container.Controls.Add(title);
		container.Controls.Add(content);
		container.Controls.Add(controlBox);
		lightBox.Controls.Add(container);
		pag.Form.Controls.Add(lightBox);
	}
}
