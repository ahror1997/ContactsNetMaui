using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "id")]
public partial class EditContactPage : ContentPage
{
	private Contact? contact;

	public EditContactPage()
	{
		InitializeComponent();
	}

    private async void updateBtn_Clicked(object sender, EventArgs e)
    {
		contact.Name = this.Name.Text;
		contact.Email = this.Email.Text;
		contact.Phone = this.Phone.Text;
		contact.Address = this.Address.Text;

		ContactRepository.UpdateContact(contact.ContactId, contact);

		await Shell.Current.GoToAsync("..");
    }

    private async void cancelBtn_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

	public int ContactId
	{
		set
		{
			contact = ContactRepository.GetContact(value);
			Name.Text = contact?.Name;
			Email.Text = contact?.Email;
			Phone.Text = contact?.Phone;
			Address.Text = contact?.Address;
		}
	}
}