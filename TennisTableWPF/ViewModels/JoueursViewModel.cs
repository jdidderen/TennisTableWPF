using System.Linq;
using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class JoueursViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _creerJoueurMessage;
        public string CreerJoueurMessage { get => _creerJoueurMessage; set { _creerJoueurMessage = value; OnPropertyChanged("CreerJoueurMessage"); } }
        private string _supprimerJoueurMessage;
        public string SupprimerJoueurMessage { get => _supprimerJoueurMessage; set { _supprimerJoueurMessage = value; OnPropertyChanged("SupprimerJoueurMessage"); } }
        private string _sauverJoueurMessage;
        public string SauverJoueurMessage { get => _sauverJoueurMessage; set { _sauverJoueurMessage = value; OnPropertyChanged("SauverJoueurMessage"); } }
        private string _modifierJoueurMessage;
        public string ModifierJoueurMessage { get => _modifierJoueurMessage; set { _modifierJoueurMessage = value; OnPropertyChanged("ModifierJoueurMessage"); } }
        private string _editerJoueurMessage;
        public string EditerJoueurMessage { get => _editerJoueurMessage; set { _editerJoueurMessage = value; OnPropertyChanged("EditerJoueurMessage"); } }

        private bool _textBoxStatus;
        public bool TextBoxStatus { get => _textBoxStatus; set { _textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool _sauverButtonStatus;
        public bool SauverButtonStatus { get => _sauverButtonStatus; set { _sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool _supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => _supprimerButtonStatus; set { _supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool _editerButtonStatus;
        public bool EditerButtonStatus { get => _editerButtonStatus; set { _editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }

        private ICommand _creerJoueurCommand;
        public ICommand CreerJoueurCommand
        {
            get
            {
                return _creerJoueurCommand ?? (_creerJoueurCommand =
                           new RelayCommands(param => CreerJoueurCommand_Execute(),
                               param => CreerJoueurCommand_CanExecute()));
            }
        }
        private ICommand _sauverJoueurCommand;
        public ICommand SauverJoueurCommand
        {
            get
            {
                return _sauverJoueurCommand ?? (_sauverJoueurCommand =
                           new RelayCommands(param => SauverJoueurCommand_Execute(),
                               param => SauverJoueurCommand_CanExecute()));
            }
        }
        private ICommand _modifierJoueurCommand;
        public ICommand ModifierJoueurCommand
        {
            get
            {
                return _modifierJoueurCommand ?? (_modifierJoueurCommand =
                           new RelayCommands(param => ModifierJoueurCommand_Execute(),
                               param => ModifierJoueurCommand_CanExecute()));
            }
        }
        private ICommand _joueursSelectedCommand;
        public ICommand JoueursSelectedCommand
        {
            get
            {
                return _joueursSelectedCommand ?? (_joueursSelectedCommand =
                           new RelayCommands(param => JoueursSelectedCommand_Execute(),
                               param => JoueursSelectedCommand_CanExecute()));
            }
        }
        private ICommand _supprimerJoueurCommand;
        public ICommand SupprimerJoueurCommand
        {
            get
            {
                return _supprimerJoueurCommand ?? (_supprimerJoueurCommand =
                           new RelayCommands(param => SupprimerJoueurCommand_Execute(),
                               param => SupprimerJoueurCommand_CanExecute()));
            }
        }

        private ObservableCollection<CJoueurs> _joueurs;
        public ObservableCollection<CJoueurs> Joueurs
        {
            get
            {
                if (_joueurs == null)
                {
                    ListeJoueurs();
                }
                return _joueurs;
            }
        }

        private readonly IDialogService _dialogservice;
        public ClassementsViewModel JClassements { get; set; }
        public ClubsViewModel JClubs { get; set; }
        public SexesViewModel JSexes { get; set; }
        public GJoueurs GJoueurs;
        private CJoueurs _joueurSelected;
        public CJoueurs JoueurSelected
        {
            get => _joueurSelected;
            set
            {
                _joueurSelected = value;
                OnPropertyChanged("JoueurSelected");
            }
        }

        public JoueursViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            JClassements = new ClassementsViewModel();
            JClubs = new ClubsViewModel(dialogservice);
            JSexes = new SexesViewModel(dialogservice);
            GJoueurs = new GJoueurs();
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            SupprimerButtonStatus = false;
        }

        private bool CreerJoueurCommand_CanExecute()
        {
            CreerJoueurMessage = "Ajouter un nouveau joueur";
            return true;
        }
        private void CreerJoueurCommand_Execute()
        {
            Joueurs.Add(new CJoueurs());
            JoueurSelected = Joueurs[Joueurs.Count - 1];
        }
        private bool SauverJoueurCommand_CanExecute()
        {
            if (JoueurSelected == null)
            {
                SauverJoueurMessage = "Sauver les données du joueur sélectionné - Aucun joueur sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverJoueurMessage = "Sauver les données du joueur sélectionné - L'édition n'a pas été activée";
            }
            else if (JoueurSelected.Nom == null && JoueurSelected.Prenom == null && JoueurSelected.License == 0 && JoueurSelected.Classement == 0 && JoueurSelected.Mail == null && JoueurSelected.Sexe == 0)
            {
                SauverJoueurMessage = "Sauver les données du joueur sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverJoueurMessage = "Sauver les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        private void SauverJoueurCommand_Execute()
        {
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            if (JoueurSelected.JoueurId == 0)
            {
                GJoueurs.Ajouter(JoueurSelected.License, JoueurSelected.Nom, JoueurSelected.Prenom, JoueurSelected.Classement, JoueurSelected.Mail, JoueurSelected.Sexe, JoueurSelected.Club);
                ReloadJoueurs();
            }
            else
            {
                GJoueurs.Modifier(JoueurSelected.JoueurId, JoueurSelected.License, JoueurSelected.Nom, JoueurSelected.Prenom, JoueurSelected.Classement, JoueurSelected.Mail, JoueurSelected.Sexe, JoueurSelected.Club);
            }

        }
        private bool ModifierJoueurCommand_CanExecute()
        {
            if (JoueurSelected == null)
            {
                _editerJoueurMessage = "Éditer les données du joueur sélectionné - Aucun joueur sélectionné";
            }
            else
            {
                _editerJoueurMessage = "Éditer les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        private void ModifierJoueurCommand_Execute()
        {
            TextBoxStatus = true;
            SauverButtonStatus = true;
            EditerButtonStatus = false;
        }
        private bool JoueursSelectedCommand_CanExecute()
        {
            return true;
        }
        private void JoueursSelectedCommand_Execute()
        {
            if (JoueurSelected != null)
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
        private bool SupprimerJoueurCommand_CanExecute()
        {
            if (JoueurSelected == null)
            {
                SauverJoueurMessage = "Supprimer le joueur sélectionné - Aucun joueur sélectionné";
            }
            else
            {
                SauverJoueurMessage = "Sauver les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        private void SupprimerJoueurCommand_Execute()
        {
            if (_dialogservice.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce joueur ?", "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) == MessageBoxResult.Yes)
            {
                GJoueurs.Supprimer(JoueurSelected.JoueurId);
                ReloadJoueurs();
            }
        }

        public void ListeJoueurs()
        {
            _joueurs = new ObservableCollection<CJoueurs>(GJoueurs.Lire("JoueurId"));
        }
        public void ReloadJoueurs()
        {
            _joueurs.Clear();
            GJoueurs.Lire("JoueurId").ToList().ForEach(_joueurs.Add);
        }
    }
}
