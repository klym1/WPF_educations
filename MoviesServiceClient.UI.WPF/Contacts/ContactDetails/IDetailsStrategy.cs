using System.Threading.Tasks;

namespace MoviesServiceClient.WPF.Contacts.ContactDetails
{
    public interface IDetailsStrategy
    {
        Task Load(ContactModel contactModel);
        Task Save(ContactModel contactModel);
        string ButtonName { get; }
    }
}