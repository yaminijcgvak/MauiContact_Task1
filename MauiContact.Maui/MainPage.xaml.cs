namespace MauiContact.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToAboutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About()); 
        }
    }

}
