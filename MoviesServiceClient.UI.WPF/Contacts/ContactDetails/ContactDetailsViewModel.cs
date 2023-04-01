using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DAL;
using Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MoviesServiceClient.WPF.Contacts.ContactList;
using MoviesServiceClient.WPF.Controls;

namespace MoviesServiceClient.WPF.Contacts.ContactDetails
{
    public class ContactDetailsViewModel : IViewModelWithNavigationContext, INotifyPropertyChanged
    {
        private readonly IGenericRepository<Contact> _genericRepository;
        private readonly IDetailsStrategy _detailsStrategy;
        private NavigationContext _navigationContext;
        private bool _isWorking;

        public NavigationContext NavigationContext
        {
            get { return _navigationContext; }
            set
            {
                _navigationContext = value;
                ContactModel.Id = (int) value.Parameters["ContactId"];
            }
        }

        public RelayCommand SaveCommand { get; private set; }

        public string ButtonName
        {
            get { return _detailsStrategy.ButtonName; }
        }

        public ContactDetailsViewModel(IGenericRepository<Contact> genericRepository, IDetailsStrategy detailsStrategy)
        {
            _genericRepository = genericRepository;
            _detailsStrategy = detailsStrategy;
            ContactModel = new ContactModel();
            SaveCommand = new RelayCommand(SaveAction);
        }

        public async Task Load()
        {
            await _detailsStrategy.Load(ContactModel);
        }

        private async void SaveAction()
        {
            IsWorking = true;
            try
            {
                await _detailsStrategy.Save(ContactModel);
                (Registry.ViewModelsRegistry["ContactList"] as ContactListViewModel).Load(); //tofo find better solution
                OnSavingFinished();
            }
            catch (Exception)
            {
            }
            IsWorking = false;
        }

        public event EventHandler SavingFinished;

        public ContactModel ContactModel { get; set; }

        public bool IsWorking
        {
            get { return _isWorking; }
            set
            {
                _isWorking = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnSavingFinished()
        {
            var handler = SavingFinished;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}