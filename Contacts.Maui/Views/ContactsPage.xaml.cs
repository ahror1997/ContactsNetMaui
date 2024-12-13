using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadContacts();
    }

    private async void addBtn_Clicked(object sender, EventArgs e)
    {
        addContactBtn.IsEnabled = false;
        await Shell.Current.GoToAsync(nameof(AddContactPage));
        addContactBtn.IsEnabled = true;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var item = e.SelectedItem as Contact;
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?id={item?.ContactId}");
        }

        listContacts.SelectedItem = null;
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        this.listContacts.ItemsSource = contacts;
    }
}