using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class ClassementsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _creerClassementMessage;
        public string CreerClassementMessage { get => _creerClassementMessage; set { _creerClassementMessage = value; OnPropertyChanged("CreerClassementMessage"); } }
        private string _supprimerClassementMessage;
        public string SupprimerClassementMessage { get => _supprimerClassementMessage; set { _supprimerClassementMessage = value; OnPropertyChanged("SupprimerClassementMessage"); } }
        private string _sauverClassementMessage;
        public string SauverClassementMessage { get => _sauverClassementMessage; set { _sauverClassementMessage = value; OnPropertyChanged("SauverClassementMessage"); } }
        private string _modifierClassementMessage;
        public string ModifierClassementMessage { get => _modifierClassementMessage; set { _modifierClassementMessage = value; OnPropertyChanged("ModifierClassementMessage"); } }
        private string _editerClassementMessage;
        public string EditerClassementMessage { get => _editerClassementMessage; set { _editerClassementMessage = value; OnPropertyChanged("EditerClassementMessage"); } }
        private bool _textBoxStatus;
        public bool TextBoxStatus { get => _textBoxStatus; set { _textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool _sauverButtonStatus;
        public bool SauverButtonStatus { get => _sauverButtonStatus; set { _sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool _supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => _supprimerButtonStatus; set { _supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool _editerButtonStatus;
        public bool EditerButtonStatus { get => _editerButtonStatus; set { _editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }
        private ICommand _creerClassementCommand;
        public ICommand CreerClassementCommand
        {
            get
            {
                return _creerClassementCommand ?? (_creerClassementCommand = new RelayCommands(param => CreerClassementCommand_Execute(),
                           param => CreerClassementCommand_CanExecute()));
            }
        }
        private ICommand _sauverClassementCommand;
        public ICommand SauverClassementCommand
        {
            get
            {
                return _sauverClassementCommand ?? (_sauverClassementCommand =
                           new RelayCommands(param => SauverClassementCommand_Execute(),
                               param => SauverClassementCommand_CanExecute()));
            }
        }
        private ICommand _modifierClassementCommand;
        public ICommand ModifierClassementCommand
        {
            get
            {
                return _modifierClassementCommand ?? (_modifierClassementCommand =
                           new RelayCommands(param => ModifierClassementCommand_Execute(),
                               param => ModifierClassementCommand_CanExecute()));
            }
        }
        private ICommand _classementsSelectedCommand;
        public ICommand ClassementsSelectedCommand
        {
            get
            {
                return _classementsSelectedCommand ?? (_classementsSelectedCommand =
                           new RelayCommands(param => ClassementsSelectedCommand_Execute(),
                               param => ClassementsSelectedCommand_CanExecute()));
            }
        }
        private ICommand _supprimerClassementCommand;
        public ICommand SupprimerClassementCommand
        {
            get
            {
                return _supprimerClassementCommand ?? (_supprimerClassementCommand =
                           new RelayCommands(param => SupprimerClassementCommand_Execute(),
                               param => SupprimerClassementCommand_CanExecute()));
            }
        }
        private ObservableCollection<CClassements> _classements;
        public ObservableCollection<CClassements> Classements
        {
            get
            {
                if (_classements == null)
                {
                    ListeClassements();
                }
                return _classements;
            }
        }
        private readonly IDialogService _dialogservice;
        public GClassements GClassements;
        private CClassements _classementSelected;
        public CClassements ClassementSelected
        {
            get => _classementSelected;
            set
            {
                _classementSelected = value;
                OnPropertyChanged("ClassementSelected");
            }
        }
        public ClassementsViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            GClassements = new GClassements();
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            SupprimerButtonStatus = false;
        }
        private bool CreerClassementCommand_CanExecute()
        {
            CreerClassementMessage = "Ajouter un nouveau classement";
            return true;
        }
        private void CreerClassementCommand_Execute()
        {
            Classements.Add(new CClassements());
            ClassementSelected = Classements[Classements.Count - 1];
        }
        private bool SauverClassementCommand_CanExecute()
        {
            if (ClassementSelected == null)
            {
                SauverClassementMessage = "Sauver les données du classement sélectionné - Aucun classement sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverClassementMessage = "Sauver les données du classement sélectionné - L'édition n'a pas été activée";
            }
            else if (ClassementSelected.Classement == null)
            {
                SauverClassementMessage = "Sauver les données du classement sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverClassementMessage = "Sauver les données du classement sélectionné";
                return true;
            }
            return false;
        }
        private void SauverClassementCommand_Execute()
        {
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            if (ClassementSelected.ClassementId == 0)
            {
                GClassements.Ajouter(ClassementSelected.Classement);
                ReloadClassements();
            }
            else
            {
                GClassements.Modifier(ClassementSelected.ClassementId, ClassementSelected.Classement);
            }

        }
        private bool ModifierClassementCommand_CanExecute()
        {
            if (ClassementSelected == null)
            {
                _editerClassementMessage = "Éditer les données du classement sélectionné - Aucun classement sélectionné";
            }
            else
            {
                _editerClassementMessage = "Éditer les données du classement sélectionné";
                return true;
            }
            return false;
        }
        private void ModifierClassementCommand_Execute()
        {
            TextBoxStatus = true;
            SauverButtonStatus = true;
            EditerButtonStatus = false;
        }
        private bool ClassementsSelectedCommand_CanExecute()
        {
            return true;
        }
        private void ClassementsSelectedCommand_Execute()
        {
            if (ClassementSelected != null)
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
        private bool SupprimerClassementCommand_CanExecute()
        {
            if (ClassementSelected == null)
            {
                SauverClassementMessage = "Supprimer le classement sélectionné - Aucun classement sélectionné";
            }
            else
            {
                SauverClassementMessage = "Sauver les données du classement sélectionné";
                return true;
            }
            return false;
        }
        private void SupprimerClassementCommand_Execute()
        {
            if (_dialogservice.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce classement ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GClassements.Supprimer(ClassementSelected.ClassementId);
            ReloadClassements();
        }
        public void ListeClassements()
        {
            _classements = new ObservableCollection<CClassements>(GClassements.Lire("ClassementId"));
        }
        public void ReloadClassements()
        {
            _classements.Clear();
            GClassements.Lire("ClassementId").ToList().ForEach(_classements.Add);
        }
    }
}
