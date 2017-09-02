using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class MatchsViewModel : ViewModelBase
    {
        #region Propriétés
        private ObservableCollection<CMatchs> _matchs;
        public ObservableCollection<CMatchs> Matchs
        {
            get
            {
                if (_matchs == null)
                {
                    ListeMatchs();
                }
                return _matchs;
            }
            set { _matchs = value; OnPropertyChanged("Matchs"); }

        }
        public GMatchs GMatchs;
        private CMatchs _matchSelected;
        public CMatchs MatchSelected
        {
            get => _matchSelected;
            set
            {
                _matchSelected = value;
                OnPropertyChanged("MatchSelected");
            }
        }
        #endregion
        #region Constructeur
        public MatchsViewModel(IDialogService dialogservice)
        {
            DialogService = dialogservice;
            GMatchs = new GMatchs();
        }
        #endregion
        #region Méthodes - Commandes
        public override bool CreerCommand_CanExecute()
        {
            CreerMessage = "Ajouter un nouveau match";
            return true;
        }
        public override void CreerCommand_Execute()
        {
            Matchs.Add(new CMatchs());
            MatchSelected = Matchs[Matchs.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (MatchSelected == null)
            {
                SauverMessage = "Sauver les données du match sélectionné - Aucun match sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données du match sélectionné - L'édition n'a pas été activée";
            }
            else if (MatchSelected.NumMatch == null && MatchSelected.Date == DateTime.MinValue && MatchSelected.Heure == DateTime.MinValue && MatchSelected.Division == null && MatchSelected.Serie == 0 && MatchSelected.EquipeVisiteur == 0 && MatchSelected.EquipeVisite == 0 && MatchSelected.Score == null)
            {
                SauverMessage = "Sauver les données du match sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverMessage = "Sauver les données du match sélectionné";
                return true;
            }
            return false;
        }
        public override void SauverCommand_Execute()
        {
            base.SauverCommand_Execute();
            if (MatchSelected.MatchId == 0)
            {
                GMatchs.Ajouter(MatchSelected.NumMatch, MatchSelected.Date, MatchSelected.Heure, MatchSelected.Serie, MatchSelected.Division, MatchSelected.EquipeVisiteur, MatchSelected.EquipeVisite, MatchSelected.Score);
                ReloadMatchs();
            }
            else
            {
                GMatchs.Modifier(MatchSelected.MatchId, MatchSelected.NumMatch, MatchSelected.Date, MatchSelected.Heure, MatchSelected.Serie, MatchSelected.Division, MatchSelected.EquipeVisiteur, MatchSelected.EquipeVisite, MatchSelected.Score);
            }
        }
        public override bool ModifierCommand_CanExecute()
        {
            if (MatchSelected == null)
            {
                EditerMessage = "Éditer les données du match sélectionné - Aucun match sélectionné";
            }
            else
            {
                EditerMessage = "Éditer les données du match sélectionné";
                return true;
            }
            return false;
        }
        public override void SelectedCommand_Execute()
        {
            if (MatchSelected != null)
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
            if (MatchSelected == null)
            {
                SupprimerMessage = "Supprimer le match sélectionné - Aucun match sélectionné";
            }
            else
            {
                SupprimerMessage = "Supprimer le match sélectionné";
                return true;
            }
            return false;
        }
        public override void SupprimerCommand_Execute()
        {
            if (DialogService.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce match ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GMatchs.Supprimer(MatchSelected.MatchId);
            ReloadMatchs();
        }
        public override void RefreshCommand_Execute()
        {
            ReloadMatchs();
        }
        #endregion
        #region Méthodes
        public void ListeMatchs()
        {
            _matchs = new ObservableCollection<CMatchs>(GMatchs.Lire("MatchId"));
        }
        public void ReloadMatchs()
        {
            _matchs.Clear();
            GMatchs.Lire("MatchId").ToList().ForEach(_matchs.Add);
        }
        #endregion
    }
}
