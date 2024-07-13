namespace LoginApp.Maui.UserControls;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
		if(App.user != null)
		{
			lblText.Text = "Logged in as: ";
			lblEmail.Text = App.user.Email;
		}
	}
}