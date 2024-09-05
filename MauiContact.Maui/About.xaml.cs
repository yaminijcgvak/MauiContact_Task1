namespace MauiContact.Maui;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		button.BackgroundColor = Colors.Red;
		button.Text = "Color Changed";
	}

}