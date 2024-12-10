using MyContacts.Model;

namespace MyContacts.Views;

[QueryProperty(nameof(ContactId), "id")]
public partial class EditContactPage : ContentPage
{
    public string ContactId { get; set; }
    private ContactInfo _contact;

    public EditContactPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (int.TryParse(ContactId, out var id))
        {
            ContactsRepository repository = new ContactsRepository();
            _contact = repository.GetContact(id);

            if (_contact != null)
            {
                NameEntry.Text = _contact.NameSurname;
                PhoneEntry.Text = _contact.PhoneNumber;
                EmailEntry.Text = _contact.Email;
            }
        }
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_contact != null)
        {
            _contact.NameSurname = NameEntry.Text;
            _contact.PhoneNumber = PhoneEntry.Text;
            _contact.Email = EmailEntry.Text;

            ContactsRepository repository = new ContactsRepository();
            repository.UpdateContact(_contact);

            await Shell.Current.GoToAsync("..");
        }
    }
}
