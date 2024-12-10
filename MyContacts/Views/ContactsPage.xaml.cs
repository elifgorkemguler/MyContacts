using MyContacts.Model;

namespace MyContacts.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var contactsRepository = new ContactsRepository();
        ContactsList.ItemsSource = contactsRepository.GetContacts();
    }

    private async void AddContactButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void ContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is ContactInfo selectedContact)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?id={selectedContact.Id}");
        }
        ContactsList.SelectedItem = null;
    }
}
