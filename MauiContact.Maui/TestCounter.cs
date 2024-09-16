namespace MauiContact.Maui;
#pragma warning disable CS8622 

public class TestCounter : ContentPage
{
    int count = 0;
    Label lblCounter;
    public TestCounter()
	{
		var scrollview = new ScrollView();
        var stacklayout = new StackLayout();
        scrollview.Content= stacklayout;
        lblCounter = new Label
        {
            Text = "Count :0",
            FontSize = 32,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            
        };
        stacklayout.Children.Add(lblCounter);
        var btncounter = new Button
        {
            Text = "Click to count",
            HorizontalOptions = LayoutOptions.Center,
        };
        stacklayout.Children.Add(btncounter);
        btncounter.Clicked += OnClickEvent;
        this.Content = stacklayout;
	}
    private void OnClickEvent(object sender, EventArgs e)
    {
        count++;
        lblCounter.Text = $"Click Count {count} ";
        SemanticScreenReader.Announce(lblCounter.Text);
    }
}