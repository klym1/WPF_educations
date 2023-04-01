using System.Threading.Tasks;
using DAL;
using Domain;

namespace MoviesServiceClient.WPF.Contacts.ContactDetails
{
    public class AddDetailsStrategy : IDetailsStrategy
    {
        private readonly IGenericRepository<Contact> _genericRepository;

        public AddDetailsStrategy(IGenericRepository<Contact> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Task Load(ContactModel contactModel)
        {
            return Task.FromResult(0);
        }

        public async Task Save(ContactModel contactModel)
        {
            await _genericRepository.CreateNewEntityAsync(new Contact
            {
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Email = contactModel.Email
            });
        }

        public string ButtonName
        {
            get { return "Add"; }
        }
    }
}