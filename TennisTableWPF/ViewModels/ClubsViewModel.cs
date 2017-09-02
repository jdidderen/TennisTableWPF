using System.Linq;
using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class ClubsViewModel : ViewModelBase
    {
        #region Propriétés
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
        #endregion
        #region Constructeur
        public ClubsViewModel(IDialogService dialogservice)
        {
            DialogService = dialogservice;
            GClubs = new GClubs();
        }
        #endregion
        #region Méthodes - Commandes
        public override bool CreerCommand_CanExecute()
        {
            CreerMessage = "Ajouter un nouveau club";
            return true;
        }
        public override void CreerCommand_Execute()
        {
            Clubs.Add(new CClubs());
            ClubSelected = Clubs[Clubs.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (ClubSelected == null)
            {
                SauverMessage = "Sauver les données du club sélectionné - Aucun club sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données du club sélectionné - L'édition n'a pas été activée";
            }
            else if (ClubSelected.Nom == null && ClubSelected.Indice == null && ClubSelected.Nom == null && ClubSelected.NomCourt == null && ClubSelected.Adresse == null)
            {
                SauverMessage = "Sauver les données du club sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverMessage = "Sauver les données du club sélectionné";
                return true;
            }
            return false;
        }
        public override void SauverCommand_Execute()
        {
            base.SauverCommand_Execute();
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
        public override bool ModifierCommand_CanExecute()
        {
            if (ClubSelected == null)
            {
                EditerMessage = "Éditer les données du club sélectionné - Aucun club sélectionné";
            }
            else
            {
                EditerMessage = "Éditer les données du club sélectionné";
                return true;
            }
            return false;
        }
        public override void SelectedCommand_Execute()
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
        public override bool SupprimerCommand_CanExecute()
        {
            if (ClubSelected == null)
            {
                SupprimerMessage = "Supprimer le club sélectionné - Aucun club sélectionné";
            }
            else
            {
                SupprimerMessage = "Supprimer le club sélectionné";
                return true;
            }
            return false;
        }
        public override void SupprimerCommand_Execute()
        {
            if (DialogService.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce club ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GClubs.Supprimer(ClubSelected.ClubId);
            ReloadClubs();
        }
        public override void RefreshCommand_Execute()
        {
            ReloadClubs();
        }
        #endregion
        #region Méthodes
        public void ListeClubs()
        {
            _clubs = new ObservableCollection<CClubs>(GClubs.Lire("ClubId"));
        }
        public void ReloadClubs()
        {
            _clubs.Clear();
            GClubs.Lire("ClubId").ToList().ForEach(_clubs.Add);
        }
        #endregion
    }
}
