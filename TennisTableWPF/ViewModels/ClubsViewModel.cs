using System.Linq;
using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    class ClubsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _creerClubMessage;
        public string CreerClubMessage { get => _creerClubMessage; set { _creerClubMessage = value; OnPropertyChanged("CreerClubMessage"); } }
        private string _supprimerClubMessage;
        public string SupprimerClubMessage { get => _supprimerClubMessage; set { _supprimerClubMessage = value; OnPropertyChanged("SupprimerClubMessage"); } }
        private string _sauverClubMessage;
        public string SauverClubMessage { get => _sauverClubMessage; set { _sauverClubMessage = value; OnPropertyChanged("SauverClubMessage"); } }
        private string _modifierClubMessage;
        public string ModifierClubMessage { get => _modifierClubMessage; set { _modifierClubMessage = value; OnPropertyChanged("ModifierClubMessage"); } }
        private string _editerClubMessage;
        public string EditerClubMessage { get => _editerClubMessage; set { _editerClubMessage = value; OnPropertyChanged("EditerClubMessage"); } }

        private bool _textBoxStatus;
        public bool TextBoxStatus { get => _textBoxStatus; set { _textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool _sauverButtonStatus;
        public bool SauverButtonStatus { get => _sauverButtonStatus; set { _sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool _supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => _supprimerButtonStatus; set { _supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool _editerButtonStatus;
        public bool EditerButtonStatus { get => _editerButtonStatus; set { _editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }

        private ICommand _creerClubCommand;
        public ICommand CreerClubCommand
        {
            get
            {
                return _creerClubCommand ?? (_creerClubCommand = new RelayCommands(param => CreerClubCommand_Execute(),
                           param => CreerClubCommand_CanExecute()));
            }
        }
        private ICommand _sauverClubCommand;
        public ICommand SauverClubCommand
        {
            get
            {
                return _sauverClubCommand ?? (_sauverClubCommand =
                           new RelayCommands(param => SauverClubCommand_Execute(),
                               param => SauverClubCommand_CanExecute()));
            }
        }
        private ICommand _modifierClubCommand;
        public ICommand ModifierClubCommand
        {
            get
            {
                return _modifierClubCommand ?? (_modifierClubCommand =
                           new RelayCommands(param => ModifierClubCommand_Execute(),
                               param => ModifierClubCommand_CanExecute()));
            }
        }
        private ICommand _clubsSelectedCommand;
        public ICommand ClubsSelectedCommand
        {
            get
            {
                return _clubsSelectedCommand ?? (_clubsSelectedCommand =
                           new RelayCommands(param => ClubsSelectedCommand_Execute(),
                               param => ClubsSelectedCommand_CanExecute()));
            }
        }
        private ICommand _supprimerClubCommand;
        public ICommand SupprimerClubCommand
        {
            get
            {
                return _supprimerClubCommand ?? (_supprimerClubCommand =
                           new RelayCommands(param => SupprimerClubCommand_Execute(),
                               param => SupprimerClubCommand_CanExecute()));
            }
        }

        private ObservableCollection<CClubs> _clubs;
        public ObservableCollection<CClubs> Clubs
        {
            get
            {
                if (_clubs == null)
                {
                    ListeClubs();
                }
                return _clubs;
            }
        }

        private readonly IDialogService _dialogservice;
        public GClubs GClubs;
        private CClubs _clubSelected;
        public CClubs ClubSelected
        {
            get => _clubSelected;
            set
            {
                _clubSelected = value;
                OnPropertyChanged("ClubSelected");
            }
        }

        public ClubsViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            GClubs = new GClubs();
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            SupprimerButtonStatus = false;
        }

        private bool CreerClubCommand_CanExecute()
        {
            CreerClubMessage = "Ajouter un nouveau club";
            return true;
        }
        private void CreerClubCommand_Execute()
        {
            Clubs.Add(new CClubs());
            ClubSelected = Clubs[Clubs.Count - 1];
        }
        private bool SauverClubCommand_CanExecute()
        {
            if (ClubSelected == null)
            {
                SauverClubMessage = "Sauver les données du club sélectionné - Aucun club sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverClubMessage = "Sauver les données du club sélectionné - L'édition n'a pas été activée";
            }
            else if (ClubSelected.Indice == null && ClubSelected.Nom == null && ClubSelected.NomCourt == null && ClubSelected.Adresse == null)
            {
                SauverClubMessage = "Sauver les données du club sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverClubMessage = "Sauver les données du club sélectionné";
                return true;
            }
            return false;
        }
        private void SauverClubCommand_Execute()
        {
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            if (ClubSelected.ClubId == 0)
            {
                GClubs.Ajouter(ClubSelected.Indice, ClubSelected.Nom, ClubSelected.NomCourt, ClubSelected.Adresse);
                ReloadClubs();
            }
            else
            {
                GClubs.Modifier(ClubSelected.ClubId, ClubSelected.Indice, ClubSelected.Nom, ClubSelected.NomCourt, ClubSelected.Adresse);
            }

        }
        private bool ModifierClubCommand_CanExecute()
        {
            if (ClubSelected == null)
            {
                _editerClubMessage = "Éditer les données du club sélectionné - Aucun club sélectionné";
            }
            else
            {
                _editerClubMessage = "Éditer les données du club sélectionné";
                return true;
            }
            return false;
        }
        private void ModifierClubCommand_Execute()
        {
            TextBoxStatus = true;
            SauverButtonStatus = true;
            EditerButtonStatus = false;
        }
        private bool ClubsSelectedCommand_CanExecute()
        {
            return true;
        }
        private void ClubsSelectedCommand_Execute()
        {
            if (ClubSelected != null)
            {
                TextBoxStatus = false;
                SauverButtonStatus = false;
                EditerButtonStatus = true;
            }
            else
            {
                TextBoxStatus = false;
                SauverButtonStatus = false;
                EditerButtonStatus = false;
            }
        }
        private bool SupprimerClubCommand_CanExecute()
        {
            if (ClubSelected == null)
            {
                SauverClubMessage = "Supprimer le club sélectionné - Aucun club sélectionné";
            }
            else
            {
                SauverClubMessage = "Sauver les données du club sélectionné";
                return true;
            }
            return false;
        }
        private void SupprimerClubCommand_Execute()
        {
            if (_dialogservice.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce club ?", "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) == MessageBoxResult.Yes)
            {
                GClubs.Supprimer(ClubSelected.ClubId);
                ReloadClubs();
            }
        }

        public void ListeClubs()
        {
            _clubs = new ObservableCollection<CClubs>(GClubs.Lire("ClubId"));
        }
        public void ReloadClubs()
        {
            _clubs.Clear();
            GClubs.Lire("ClubId").ToList().ForEach(_clubs.Add);
        }
    }
}
