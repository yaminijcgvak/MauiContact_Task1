using MauiContact.Maui.Modals;
using MauiContact.Maui.Services;

namespace MauiContact.Maui;

public partial class AddPerson : ContentPage
{
    private PersonService _personService = new PersonService();

    public AddPerson()
    {
        InitializeComponent();
    }

    [Obsolete]
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(NameEntry.Text) && int.TryParse(AgeEntry.Text, out int age))
        {
            var person = new Person
            {
                Name = NameEntry.Text,
                Age = age
            };
            await _personService.AddAsync(person);

            MessagingCenter.Send(this, "PersonAdded");
            await DisplayAlert("Success", "Person added successfully!", "OK");

            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please enter a valid age.", "OK");
        }
    }


}
