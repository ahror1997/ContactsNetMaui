using Bogus;

namespace Contacts.Maui.Models;

public static class ContactRepository
{
    private static List<Contact> _contacts = GenerateFakeContacts(5);

    public static List<Contact> GetContacts()
    {
        return _contacts;
    }

    public static Contact? GetContact(int id)
    {
        return _contacts.FirstOrDefault(c => c.ContactId == id);
    }

    public static void UpdateContact(int contactId, Contact contact)
    {
        if (contactId != contact.ContactId) return;

        var contactToUpdate = GetContact(contactId);
        if (contactToUpdate != null)
        {
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Address = contact.Address;
        }
    }

    private static List<Contact> GenerateFakeContacts(int count)
    {
        Faker<Contact> faker = new Faker<Contact>()
            .RuleFor(c => c.Name, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.Phone, f => f.Person.Phone)
            .RuleFor(c => c.Address, f => f.Address.FullAddress());

        var contacts = faker.Generate(count);

        for (int i = 0; i < contacts.Count; i++)
        {
            contacts[i].ContactId = i + 1;
        }

        return contacts;
    }
}
