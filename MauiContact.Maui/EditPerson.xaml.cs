using MauiContact.Maui.Modals;
using MauiContact.Maui.Services;

namespace MauiContact.Maui;

public partial class EditPerson : ContentPage
{
    private PersonService _personService = new PersonService();
    private Person _person;

    public EditPerson(Person person)
    {
        InitializeComponent();
        _person = person;
        NameEntry.Text = _person.Name;
        AgeEntry.Text = _person.Age.ToString();
    }

    [Obsolete]
    private async void OnSaveClicked(object sender, EventArgs e)
{
    if (_person != null)
    {
        _person.Name = NameEntry.Text;
        await _personService.UpdateAsync(_person);

        MessagingCenter.Send(this, "PersonUpdated");
         await DisplayAlert("Success", "Person updated successfully!", "OK");

            await Navigation.PopAsync();
    }
}

    [Obsolete]
    private async void OnDeleteClicked(object sender, EventArgs e)
{
    if (_person != null)
    {
        await _personService.DeleteAsync(_person.Id);

        MessagingCenter.Send(this, "PersonDeleted");
            await DisplayAlert("Success", "Person deleted successfully!", "OK");

            await Navigation.PopAsync();
    }
}

}
