using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTableWPF.Services;
using TennisTableWPF.Views.Matchs;

namespace TennisTableWPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Implémentation PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Status et messages des contrôles
        private string _creerMessage;
        public string CreerMessage { get => _creerMessage; set { _creerMessage = value; OnPropertyChanged("CreerMessage"); } }
        private string _supprimerMessage;
        public string SupprimerMessage { get => _supprimerMessage; set { _supprimerMessage = value; OnPropertyChanged("SupprimerMessage"); } }
        private string _sauverMessage;
        public string SauverMessage { get => _sauverMessage; set { _sauverMessage = value; OnPropertyChanged("SauverMessage"); } }
        private string _editerMessage;
        public string EditerMessage { get => _editerMessage; set { _editerMessage = value; OnPropertyChanged("EditerMessage"); } }
        private string _resfreshMessage;
        public string RefreshMessage { get => _resfreshMessage; set { _resfreshMessage = value; OnPropertyChanged("RefreshMessage"); } }
        private bool _textBoxStatus;
        public bool TextBoxStatus { get => _textBoxStatus; set { _textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool _listBoxStatus;
        public bool ListBoxStatus{ get => _listBoxStatus; set { _listBoxStatus = value; OnPropertyChanged("ListBoxStatus"); } }
        private bool _sauverButtonStatus;
        public bool SauverButtonStatus { get => _sauverButtonStatus; set { _sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool _supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => _supprimerButtonStatus; set { _supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool _editerButtonStatus;
        public bool EditerButtonStatus { get => _editerButtonStatus; set { _editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }
        #endregion
        #region Commandes
        private ICommand _creerCommand;
        public ICommand CreerCommand
        {
            get
            {
                return _creerCommand ?? (_creerCommand =
                           new RelayCommands(param => CreerCommand_Execute(),
                               param => CreerCommand_CanExecute()));
            }
        }
        private ICommand _sauverCommand;
        public ICommand SauverCommand
        {
            get
            {
                return _sauverCommand ?? (_sauverCommand =
                           new RelayCommands(param => SauverCommand_Execute(),
                               param => SauverCommand_CanExecute()));
            }
        }
        private ICommand _modifierCommand;
        public ICommand ModifierCommand
        {
            get
            {
                return _modifierCommand ?? (_modifierCommand =
                           new RelayCommands(param => ModifierCommand_Execute(),
                               param => ModifierCommand_CanExecute()));
            }
        }
        private ICommand _supprimerCommand;
        public ICommand SupprimerCommand
        {
            get
            {
                return _supprimerCommand ?? (_supprimerCommand =
                           new RelayCommands(param => SupprimerCommand_Execute(),
                               param => SupprimerCommand_CanExecute()));
            }
        }
        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand =
                           new RelayCommands(param => RefreshCommand_Execute(),
                               param => RefreshCommand_CanExecute()));
            }
        }
        private ICommand _selectedCommand;
        public ICommand SelectedCommand
        {
            get
            {
                return _selectedCommand ?? (_selectedCommand =
                           new RelayCommands(param => SelectedCommand_Execute(),
                               param => SelectedCommand_CanExecute()));
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
        private ICommand _toggleChangedCommand;
        public ICommand ToggleChangedCommand
        {
            get
            {
                return _toggleChangedCommand ?? (_toggleChangedCommand =
                           new RelayCommands(param => ToggleChangedCommand_Execute(),
                               param => ToggleChangedCommand_CanExecute()));
            }
        }
        private ICommand _equipesSelectedCommand;
        public ICommand EquipesSelectedCommand
        {
            get
            {
                return _equipesSelectedCommand ?? (_equipesSelectedCommand =
                           new RelayCommands(param => EquipesSelectedCommand_Execute(),
                               param => EquipesSelectedCommand_CanExecute()));
            }
        }
        #endregion
        #region Appel des modèles
        public GSexes GSexes;
        public GEquipes GEquipes;
        public GClubs GClubs;
        public GSeries GSeries;
        public GClassements GClassements;
        public GMatchs GMatchs;
        public GJoueurs GJoueurs;
        public GMatchsView GMatchsView;
        #endregion
        #region ObservableCollection
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
            set { _sexes = value; OnPropertyChanged("Sexes"); }
        }
        private ObservableCollection<CEquipes> _equipes;
        public ObservableCollection<CEquipes> Equipes
        {
            get
            {
                if (_equipes == null)
                {
                    ListeEquipes();
                }
                return _equipes;
            }
            set { _equipes = value; OnPropertyChanged("Equipes"); }
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
            set { _clubs = value; OnPropertyChanged("Clubs"); }
        }
        private ObservableCollection<CSeries> _series;
        public ObservableCollection<CSeries> Series
        {
            get
            {
                if (_series == null)
                {
                    ListeSeries();
                }
                return _series;
            }
            set { _series = value; OnPropertyChanged("Series"); }
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
            set { _classements = value; OnPropertyChanged("Classements"); }
        }
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
        #endregion
        #region Propriétés
        public DialogService DialogService;
        #endregion
        #region Constructeur
        public ViewModelBase()
        {
            GJoueurs = new GJoueurs();
            GMatchsView = new GMatchsView();
            GClassements = new GClassements();
            GClubs = new GClubs();
            GEquipes = new GEquipes();
            GMatchs = new GMatchs();
            GSeries = new GSeries();
            GSexes = new GSexes();
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            SupprimerButtonStatus = false;
            ListBoxStatus = false;
        }
        #endregion
        #region Méthodes - Commandes
        public virtual bool CreerCommand_CanExecute()
        {
            return true;
        }
        public virtual void CreerCommand_Execute()
        {
        }
        public virtual bool SauverCommand_CanExecute()
        {
            return false;
        }
        public virtual void SauverCommand_Execute()
        {
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
        }
        public virtual bool ModifierCommand_CanExecute()
        {
            return false;
        }
        public virtual void ModifierCommand_Execute()
        {
            TextBoxStatus = true;
            SauverButtonStatus = true;
            EditerButtonStatus = false;
        }
        public virtual bool SelectedCommand_CanExecute()
        {
            return true;
        }
        public virtual void SelectedCommand_Execute()
        {
        }
        public virtual bool SupprimerCommand_CanExecute()
        {
            return false;
        }
        public virtual void SupprimerCommand_Execute()
        {
        }
        public virtual bool RefreshCommand_CanExecute()
        {
            RefreshMessage = "Recharger les données de la liste - Attention les données en cours d'édition sont perdues";
            return true;
        }
        public virtual void RefreshCommand_Execute()
        {

        }
        public virtual bool ClubsSelectedCommand_CanExecute()
        {
            return true;
        }
        public virtual void ClubsSelectedCommand_Execute()
        {
        }
        public virtual bool EquipesSelectedCommand_CanExecute()
        {
            return true;
        }
        public virtual void EquipesSelectedCommand_Execute()
        {
        }
        public virtual bool ToggleChangedCommand_CanExecute()
        {
            return true;
        }
        public virtual void ToggleChangedCommand_Execute()
        {
        }
        #endregion
        #region Méthodes
        public void ListeMatchs()
        {
            MatchsView = new ObservableCollection<CMatchsView>(GMatchsView.Lire("MatchsView"));
        }
        public void ListeJoueurs()
        {
            _joueurs = new ObservableCollection<CJoueurs>(GJoueurs.Lire("JoueurId"));
        }
        public void ListeClassements()
        {
            _classements = new ObservableCollection<CClassements>(GClassements.Lire("ClassementId"));
        }
        public void ListeSeries()
        {
            _series = new ObservableCollection<CSeries>(GSeries.Lire("SerieId"));
        }
        public void ListeClubs()
        {
            _clubs = new ObservableCollection<CClubs>(GClubs.Lire("ClubId"));
        }
        public void ListeEquipes()
        {
            _equipes = new ObservableCollection<CEquipes>(GEquipes.Lire("EquipeId"));
        }
        public void ListeSexes()
        {
            _sexes = new ObservableCollection<CSexes>(GSexes.Lire("SexeId"));
        }
        public void Reload()
        {
            Equipes.Clear();
            GEquipes.Lire("EquipeId").ToList().ForEach(_equipes.Add);
            Clubs.Clear();
            GClubs.Lire("ClubId").ToList().ForEach(_clubs.Add);
            Series.Clear();
            GSeries.Lire("SerieId").ToList().ForEach(_series.Add);
            Classements.Clear();
            GClassements.Lire("ClassementId").ToList().ForEach(_classements.Add);
            MatchsView.Clear();
            GMatchsView.Lire("MatchsView").ToList().ForEach(MatchsView.Add);
            Joueurs.Clear();
            GJoueurs.Lire("JoueurId").ToList().ForEach(_joueurs.Add);
            Sexes.Clear();
            GSexes.Lire("SexeId").ToList().ForEach(_sexes.Add);
        }
        #endregion
    }
}
