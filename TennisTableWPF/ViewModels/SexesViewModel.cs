using System.Linq;
using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    class SexesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _creerSexeMessage;
        public string CreerSexeMessage { get => _creerSexeMessage; set { _creerSexeMessage = value; OnPropertyChanged("CreerSexeMessage"); } }
        private string _supprimerSexeMessage;
        public string SupprimerSexeMessage { get => _supprimerSexeMessage; set { _supprimerSexeMessage = value; OnPropertyChanged("SupprimerSexeMessage"); } }
        private string _sauverSexeMessage;
        public string SauverSexeMessage { get => _sauverSexeMessage; set { _sauverSexeMessage = value; OnPropertyChanged("SauverSexeMessage"); } }
        private string _modifierSexeMessage;
        public string ModifierSexeMessage { get => _modifierSexeMessage; set { _modifierSexeMessage = value; OnPropertyChanged("ModifierSexeMessage"); } }
        private string _editerSexeMessage;
        public string EditerSexeMessage { get => _editerSexeMessage; set { _editerSexeMessage = value; OnPropertyChanged("EditerSexeMessage"); } }

        private bool _textBoxStatus;
        public bool TextBoxStatus { get => _textBoxStatus; set { _textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool _sauverButtonStatus;
        public bool SauverButtonStatus { get => _sauverButtonStatus; set { _sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool _supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => _supprimerButtonStatus; set { _supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool _editerButtonStatus;
        public bool EditerButtonStatus { get => _editerButtonStatus; set { _editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }

        private ICommand _creerSexeCommand;
        public ICommand CreerSexeCommand
        {
            get
            {
                return _creerSexeCommand ?? (_creerSexeCommand = new RelayCommands(param => CreerSexeCommand_Execute(),
                           param => CreerSexeCommand_CanExecute()));
            }
        }
        private ICommand _sauverSexeCommand;
        public ICommand SauverSexeCommand
        {
            get
            {
                return _sauverSexeCommand ?? (_sauverSexeCommand =
                           new RelayCommands(param => SauverSexeCommand_Execute(),
                               param => SauverSexeCommand_CanExecute()));
            }
        }
        private ICommand _modifierSexeCommand;
        public ICommand ModifierSexeCommand
        {
            get
            {
                return _modifierSexeCommand ?? (_modifierSexeCommand =
                           new RelayCommands(param => ModifierSexeCommand_Execute(),
                               param => ModifierSexeCommand_CanExecute()));
            }
        }
        private ICommand _sexesSelectedCommand;
        public ICommand SexesSelectedCommand
        {
            get
            {
                return _sexesSelectedCommand ?? (_sexesSelectedCommand =
                           new RelayCommands(param => SexesSelectedCommand_Execute(),
                               param => SexesSelectedCommand_CanExecute()));
            }
        }
        private ICommand _supprimerSexeCommand;
        public ICommand SupprimerSexeCommand
        {
            get
            {
                return _supprimerSexeCommand ?? (_supprimerSexeCommand =
                           new RelayCommands(param => SupprimerSexeCommand_Execute(),
                               param => SupprimerSexeCommand_CanExecute()));
            }
        }

        private ObservableCollection<CSexes> _sexes;
        public ObservableCollection<CSexes> Sexes
        {
            get
            {
                if (_sexes == null)
                {
                    ListeSexes();
                }
                return _sexes;
            }
        }

        private readonly IDialogService _dialogservice;
        public ClassementsViewModel JClassements { get; set; }
        public ClubsViewModel JClubs { get; set; }
        public SexesViewModel JSexes { get; set; }
        public GSexes GSexes;
        private CSexes _sexeSelected;
        public CSexes SexeSelected
        {
            get => _sexeSelected;
            set
            {
                _sexeSelected = value;
                OnPropertyChanged("SexeSelected");
            }
        }

        public SexesViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            GSexes = new GSexes();
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            SupprimerButtonStatus = false;
        }

        private bool CreerSexeCommand_CanExecute()
        {
            CreerSexeMessage = "Ajouter un nouveau sexe";
            return true;
        }
        private void CreerSexeCommand_Execute()
        {
            Sexes.Add(new CSexes());
            SexeSelected = Sexes[Sexes.Count - 1];
        }
        private bool SauverSexeCommand_CanExecute()
        {
            if (SexeSelected == null)
            {
                SauverSexeMessage = "Sauver les données du sexe sélectionné - Aucun sexe sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverSexeMessage = "Sauver les données du sexe sélectionné - L'édition n'a pas été activée";
            }
            else if (SexeSelected.Denomination == null)
            {
                SauverSexeMessage = "Sauver les données du sexe sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverSexeMessage = "Sauver les données du sexe sélectionné";
                return true;
            }
            return false;
        }
        private void SauverSexeCommand_Execute()
        {
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            if (SexeSelected.SexeId == 0)
            {
                GSexes.Ajouter(SexeSelected.Denomination);
                ReloadSexes();
            }
            else
            {
                GSexes.Modifier(SexeSelected.SexeId, SexeSelected.Denomination);
            }

        }
        private bool ModifierSexeCommand_CanExecute()
        {
            if (SexeSelected == null)
            {
                _editerSexeMessage = "Éditer les données du sexe sélectionné - Aucun sexe sélectionné";
            }
            else
            {
                _editerSexeMessage = "Éditer les données du sexe sélectionné";
                return true;
            }
            return false;
        }
        private void ModifierSexeCommand_Execute()
        {
            TextBoxStatus = true;
            SauverButtonStatus = true;
            EditerButtonStatus = false;
        }
        private bool SexesSelectedCommand_CanExecute()
        {
            return true;
        }
        private void SexesSelectedCommand_Execute()
        {
            if (SexeSelected != null)
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
        private bool SupprimerSexeCommand_CanExecute()
        {
            if (SexeSelected == null)
            {
                SauverSexeMessage = "Supprimer le sexe sélectionné - Aucun sexe sélectionné";
            }
            else
            {
                SauverSexeMessage = "Sauver les données du sexe sélectionné";
                return true;
            }
            return false;
        }
        private void SupprimerSexeCommand_Execute()
        {
            if (_dialogservice.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce sexe ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GSexes.Supprimer(SexeSelected.SexeId);
            ReloadSexes();
        }

        public void ListeSexes()
        {
            _sexes = new ObservableCollection<CSexes>(GSexes.Lire("SexeId"));
        }
        public void ReloadSexes()
        {
            _sexes.Clear();
            GSexes.Lire("SexeId").ToList().ForEach(_sexes.Add);
        }
    }
}
