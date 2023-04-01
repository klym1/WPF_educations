using System;

namespace MoviesServiceClient.WPF.Contacts.ContactList
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}