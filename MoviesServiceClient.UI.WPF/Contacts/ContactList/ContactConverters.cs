using Domain;

namespace MoviesServiceClient.WPF.Contacts.ContactList
{
    public static class ContactConverters
    {
        public static ContactModel ToModel(Contact it)
        {
            return new ContactModel
            {
                Id = it.Id,
                FirstName = it.FirstName,
                LastName = it.LastName
            };
        }
    }
}