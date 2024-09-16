using MauiContact.Maui.Modals;
using MauiContact.Maui.Services;
using System.Collections.ObjectModel;

namespace MauiContact.Maui;

public partial class PeopleListPage : ContentPage
{
    private PersonService _personService = new PersonService();
    private ObservableCollection<Person>? _people;

    [Obsolete]
    public PeopleListPage()
    {
        InitializeComponent();
        LoadPeople();

        // Subscribe to messaging for addition, update, and deletion
        MessagingCenter.Subscribe<AddPerson>(this, "PersonAdded", (sender) => {
            LoadPeople();
        });

        MessagingCenter.Subscribe<EditPerson>(this, "PersonUpdated", (sender) => {
            LoadPeople();
        });

        MessagingCenter.Subscribe<EditPerson>(this, "PersonDeleted", (sender) => {
            LoadPeople();
        });
    }

    private async void LoadPeople()
    {
        var peopleList = await _personService.GetAllAsync();
        _people = new ObservableCollection<Person>(peopleList);
        PeopleListView.ItemsSource = _people;
    }

    private async void OnAddPersonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPerson());
        LoadPeople();
    }

    private async void OnPersonTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Person person)
        {
            await Navigation.PushAsync(new EditPerson(person));
            LoadPeople();
        }
    }
}
