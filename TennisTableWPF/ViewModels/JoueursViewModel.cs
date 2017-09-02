using System.Linq;
using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class JoueursViewModel : ViewModelBase
    {
        #region Propriétés
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
            set { _joueurs = value; OnPropertyChanged("Joueurs"); }
            
        }
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
        #endregion
        #region Constructeur
        public JoueursViewModel(IDialogService dialogservice)
        {
            DialogService = dialogservice;
            ClassementsVm = new ClassementsViewModel(dialogservice);
            ClubsVm = new ClubsViewModel(dialogservice);
            SexesVm = new SexesViewModel(dialogservice);
            GJoueurs = new GJoueurs();
        }
        #endregion
        #region Méthodes - Commandes
        public override bool CreerCommand_CanExecute()
        {
            CreerMessage = "Ajouter un nouveau joueur";
            return true;
        }
        public override void CreerCommand_Execute()
        {
            Joueurs.Add(new CJoueurs());
            JoueurSelected = Joueurs[Joueurs.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (JoueurSelected == null)
            {
                SauverMessage = "Sauver les données du joueur sélectionné - Aucun joueur sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données du joueur sélectionné - L'édition n'a pas été activée";
            }
            else if (JoueurSelected.Nom == null && JoueurSelected.Prenom == null && JoueurSelected.License == 0 && JoueurSelected.Classement == 0 && JoueurSelected.Mail == null && JoueurSelected.Sexe == 0)
            {
                SauverMessage = "Sauver les données du joueur sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverMessage = "Sauver les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        public override void SauverCommand_Execute()
        {
            base.SauverCommand_Execute();
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
        public override bool ModifierCommand_CanExecute()
        {
            if (JoueurSelected == null)
            {
                EditerMessage = "Éditer les données du joueur sélectionné - Aucun joueur sélectionné";
            }
            else
            {
                EditerMessage = "Éditer les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        public override void SelectedCommand_Execute()
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
        public override bool SupprimerCommand_CanExecute()
        {
            if (JoueurSelected == null)
            {
                SupprimerMessage = "Supprimer le joueur sélectionné - Aucun joueur sélectionné";
            }
            else
            {
                SupprimerMessage = "Supprimer le joueur sélectionné";
                return true;
            }
            return false;
        }
        public override void SupprimerCommand_Execute()
        {
            if (DialogService.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce joueur ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GJoueurs.Supprimer(JoueurSelected.JoueurId);
            ReloadJoueurs();
        }
        public override void RefreshCommand_Execute()
        {
            ReloadJoueurs();
        }
        #endregion
        #region Méthodes
        public void ListeJoueurs()
        {
            _joueurs = new ObservableCollection<CJoueurs>(GJoueurs.Lire("JoueurId"));
        }
        public void ReloadJoueurs()
        {
            _joueurs.Clear();
            GJoueurs.Lire("JoueurId").ToList().ForEach(_joueurs.Add);
        }
        #endregion
    }
}
