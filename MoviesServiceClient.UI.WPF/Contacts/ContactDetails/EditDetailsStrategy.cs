using System.Threading.Tasks;
using DAL;
using Domain;

namespace MoviesServiceClient.WPF.Contacts.ContactDetails
{
    public class EditDetailsStrategy : IDetailsStrategy
    {
        private readonly IGenericRepository<Contact> _genericRepository;

        public EditDetailsStrategy(IGenericRepository<Contact> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Load(ContactModel contactModel)
        {
            if (contactModel.Id > 0)
            {
                var entity = await _genericRepository.LoadEntityAsync(contactModel.Id);

                contactModel.FirstName = entity.FirstName;
                contactModel.LastName = entity.LastName;
                contactModel.Email = entity.Email;
            }
        }

        public async Task Save(ContactModel contactModel)
        {
            if (contactModel.Id > 0)
            {
                var oldEntity = await _genericRepository.LoadEntityAsync(contactModel.Id);

                await Task.Delay(500);

                oldEntity.FirstName = contactModel.FirstName;
                oldEntity.LastName = contactModel.LastName;
                oldEntity.Email = contactModel.Email;

                await _genericRepository.SaveEntityAsync(oldEntity);
            }
        }

        public string ButtonName
        {
            get { return "Save"; }
        }
    }
}