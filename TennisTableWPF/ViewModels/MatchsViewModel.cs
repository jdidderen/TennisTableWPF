using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class MatchsViewModel : ViewModelBase
    {
        #region Propriétés
        private ObservableCollection<CMatchsView> _matchsView;
        public ObservableCollection<CMatchsView> MatchsView
        {
            get
            {
                if (_matchsView == null)
                {
                    ListeMatchs();
                }
                return _matchsView;
            }
            set { _matchsView = value; OnPropertyChanged("MatchsView"); }

        }
        public GMatchsView GMatchsView;
        public GMatchs GMatchs;
        private CMatchsView _matchViewSelected;
        public CMatchsView MatchViewSelected
        {
            get => _matchViewSelected;
            set
            {
                _matchViewSelected = value;
                OnPropertyChanged("MatchViewSelected");
            }
        }
        #endregion
        #region Constructeur
        public MatchsViewModel(IDialogService dialogservice)
        {
            DialogService = dialogservice;
            GMatchsView = new GMatchsView();
            GMatchs = new GMatchs();
            EquipesVm = new EquipesViewModel(DialogService);
            SeriesVm = new SeriesViewModel(DialogService);
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
            MatchsView.Add(new CMatchsView());
            MatchsView[MatchsView.Count - 1].Date = new DateTime();
            MatchsView[MatchsView.Count - 1].Date = DateTime.Today;
            MatchsView[MatchsView.Count - 1].Heure = new DateTime();
            MatchsView[MatchsView.Count - 1].Heure = DateTime.Now;
            MatchViewSelected = MatchsView[MatchsView.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (MatchViewSelected == null)
            {
                SauverMessage = "Sauver les données du match sélectionné - Aucun match sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données du match sélectionné - L'édition n'a pas été activée";
            }
            else if (MatchViewSelected.NumMatch == null && MatchViewSelected.Date == DateTime.MinValue && MatchViewSelected.Heure == DateTime.MinValue && MatchViewSelected.Division == null && MatchViewSelected.Serie == null && MatchViewSelected.EquipeVisiteurId == 0 && MatchViewSelected.EquipeVisiteId == 0 && MatchViewSelected.Score == null)
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
            if (MatchViewSelected.MatchId == 0)
            {
                GMatchs.Ajouter(MatchViewSelected.NumMatch, MatchViewSelected.Date, MatchViewSelected.Heure, MatchViewSelected.SerieId, MatchViewSelected.Division, MatchViewSelected.EquipeVisiteurId, MatchViewSelected.EquipeVisiteId, MatchViewSelected.Score);
                ReloadMatchs();
            }
            else
            {
                GMatchs.Modifier(MatchViewSelected.MatchId, MatchViewSelected.NumMatch, MatchViewSelected.Date, MatchViewSelected.Heure, MatchViewSelected.SerieId, MatchViewSelected.Division, MatchViewSelected.EquipeVisiteurId, MatchViewSelected.EquipeVisiteId, MatchViewSelected.Score);
            }
        }
        public override bool ModifierCommand_CanExecute()
        {
            if (MatchViewSelected == null)
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
            if (MatchViewSelected != null)
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
            if (MatchViewSelected == null)
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
                    "Confirmation de suppresion", Services.MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                Services.MessageBoxResult.Yes) return;
            GMatchs.Supprimer(MatchViewSelected.MatchId);
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
            MatchsView = new ObservableCollection<CMatchsView>(GMatchsView.Lire("MatchsView"));
        }
        public void ReloadMatchs()
        {
            MatchsView.Clear();
            GMatchsView.Lire("MatchsView").ToList().ForEach(MatchsView.Add);
        }
        #endregion
    }
}
