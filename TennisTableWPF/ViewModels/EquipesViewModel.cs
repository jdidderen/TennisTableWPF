using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class EquipesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region Status et messages des contrôles
        private string _creerEquipeMessage;
        public string CreerEquipeMessage { get => _creerEquipeMessage; set { _creerEquipeMessage = value; OnPropertyChanged("CreerEquipeMessage"); } }
        private string _supprimerEquipeMessage;
        public string SupprimerEquipeMessage { get => _supprimerEquipeMessage; set { _supprimerEquipeMessage = value; OnPropertyChanged("SupprimerEquipeMessage"); } }
        private string _sauverEquipeMessage;
        public string SauverEquipeMessage { get => _sauverEquipeMessage; set { _sauverEquipeMessage = value; OnPropertyChanged("SauverEquipeMessage"); } }
        private string _modifierEquipeMessage;
        public string ModifierEquipeMessage { get => _modifierEquipeMessage; set { _modifierEquipeMessage = value; OnPropertyChanged("ModifierEquipeMessage"); } }
        private string _editerEquipeMessage;
        public string EditerEquipeMessage { get => _editerEquipeMessage; set { _editerEquipeMessage = value; OnPropertyChanged("EditerEquipeMessage"); } }
        private bool _textBoxStatus;
        public bool TextBoxStatus { get => _textBoxStatus; set { _textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool _listBoxStatus;
        public bool ListeBoxStatus { get => _listBoxStatus; set { _listBoxStatus = value; OnPropertyChanged("ListeBoxStatus"); } }
        private bool _sauverButtonStatus;
        public bool SauverButtonStatus { get => _sauverButtonStatus; set { _sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool _supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => _supprimerButtonStatus; set { _supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool _editerButtonStatus;
        public bool EditerButtonStatus { get => _editerButtonStatus; set { _editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }
        #endregion
        #region Commandes
        private ICommand _creerEquipeCommand;
        public ICommand CreerEquipeCommand
        {
            get
            {
                return _creerEquipeCommand ?? (_creerEquipeCommand =
                           new RelayCommands(param => CreerEquipeCommand_Execute(),
                               param => CreerEquipeCommand_CanExecute()));
            }
        }
        private ICommand _sauverEquipeCommand;
        public ICommand SauverEquipeCommand
        {
            get
            {
                return _sauverEquipeCommand ?? (_sauverEquipeCommand =
                           new RelayCommands(param => SauverEquipeCommand_Execute(),
                               param => SauverEquipeCommand_CanExecute()));
            }
        }
        private ICommand _modifierEquipeCommand;
        public ICommand ModifierEquipeCommand
        {
            get
            {
                return _modifierEquipeCommand ?? (_modifierEquipeCommand =
                           new RelayCommands(param => ModifierEquipeCommand_Execute(),
                               param => ModifierEquipeCommand_CanExecute()));
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
        private ICommand _supprimerEquipeCommand;
        public ICommand SupprimerEquipeCommand
        {
            get
            {
                return _supprimerEquipeCommand ?? (_supprimerEquipeCommand =
                           new RelayCommands(param => SupprimerEquipeCommand_Execute(),
                               param => SupprimerEquipeCommand_CanExecute()));
            }
        }
        private ICommand _refreshEquipeCommand;
        public ICommand RefreshEquipeCommand
        {
            get
            {
                return _refreshEquipeCommand ?? (_refreshEquipeCommand =
                           new RelayCommands(param => RefreshEquipeCommand_Execute(),
                               param => RefreshEquipeCommand_CanExecute()));
            }
        }
        #endregion
        #region Propriétés
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
            set { _equipes = value; OnPropertyChanged("Joueurs"); }
        }
        private readonly IDialogService _dialogservice;
        public ClubsViewModel EClubs { get; set; }
        public JoueursViewModel EJoueurs { get; set; }
        public GEquipes GEquipes;
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
        private CEquipes _equipeSelected;
        public CEquipes EquipeSelected
        {
            get => _equipeSelected;
            set
            {
                _equipeSelected = value;
                OnPropertyChanged("EquipeSelected");
            }
        }
        private CJoueurs _capitaineSelected;
        public CJoueurs CapitaineSelected
        {
            get => _capitaineSelected;
            set
            {
                _capitaineSelected = value;
                OnPropertyChanged("CapitaineSelected");
            }
        }
        public ICollectionView JoueursFiltre => CollectionViewSource.GetDefaultView(EJoueurs.Joueurs);
        private List<CJoueurs> _joueursSelected;
        public List<CJoueurs> JoueurSelected
        {
            get => _joueursSelected;
            set
            {
                _joueursSelected = value;
                OnPropertyChanged("JoueurSelected");
            }
}
        #endregion
        #region Constructeur

        public EquipesViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            EJoueurs = new JoueursViewModel(dialogservice);
            EClubs = new ClubsViewModel(dialogservice);
            GEquipes = new GEquipes();
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            SupprimerButtonStatus = false;
            ListeBoxStatus = false;
            JoueurSelected = new List<CJoueurs>();
            JoueursFiltre.Filter = o =>
            {
                var item = (CJoueurs)o;
                return item.Club == ClubSelected?.ClubId;
            };

        }

        #endregion
        #region Méthodes - Commandes

        private bool CreerEquipeCommand_CanExecute()
        {
            CreerEquipeMessage = "Ajouter une nouvelle equipe";
            return true;
        }
        private void CreerEquipeCommand_Execute()
        {
            Equipes.Add(new CEquipes());
            EquipeSelected = Equipes[Equipes.Count - 1];
        }
        private bool SauverEquipeCommand_CanExecute()
        {
            if (EquipeSelected == null)
            {
                SauverEquipeMessage = "Sauver les données du equipe sélectionné - Aucun equipe sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverEquipeMessage = "Sauver les données du equipe sélectionné - L'édition n'a pas été activée";
            }
            else if (EquipeSelected.NomEquipe == null && JoueurSelected == null && EquipeSelected.Capitaine == 0 && EquipeSelected.Club == 0)
            {
                SauverEquipeMessage = "Sauver les données de l'équipe sélectionnée - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverEquipeMessage = "Sauver les données de l'équipe sélectionnée";
                return true;
            }
            return false;
        }
        private void SauverEquipeCommand_Execute()
        {
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            if (EquipeSelected.EquipeId == 0)
            {
                //GEquipes.Ajouter(EquipeSelected.NomEquipe, EquipeSelected.Capitaine, EquipeSelected.Club);
                ReloadEquipes();
            }
            else
            {
                GEquipes.Modifier(EquipeSelected.EquipeId, EquipeSelected.NomEquipe, EquipeSelected.Joueur1, EquipeSelected.Joueur2, EquipeSelected.Joueur3, EquipeSelected.Joueur4, EquipeSelected.Capitaine, EquipeSelected.Club);
            }

        }
        private bool ModifierEquipeCommand_CanExecute()
        {
            if (EquipeSelected == null)
            {
                _editerEquipeMessage = "Éditer les données du equipe sélectionné - Aucun equipe sélectionné";
            }
            else
            {
                _editerEquipeMessage = "Éditer les données du equipe sélectionné";
                return true;
            }
            return false;
        }
        private void ModifierEquipeCommand_Execute()
        {
            TextBoxStatus = true;
            SauverButtonStatus = true;
            EditerButtonStatus = false;
        }
        private bool EquipesSelectedCommand_CanExecute()
        {
            return true;
        }
        private void EquipesSelectedCommand_Execute()
        {
            if (EquipeSelected != null)
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
        private bool ClubsSelectedCommand_CanExecute()
        {
            return true;
        }
        private void ClubsSelectedCommand_Execute()
        {
            if (ClubSelected != null)
            {
                TextBoxStatus = false;
                ListeBoxStatus = true;
                SauverButtonStatus = false;
                EditerButtonStatus = true;
                JoueursFiltre.Refresh();
            }
            else
            {
                TextBoxStatus = false;
                ListeBoxStatus = false;
                SauverButtonStatus = false;
                EditerButtonStatus = false;
                JoueursFiltre.Refresh();
            }
        }
        private bool SupprimerEquipeCommand_CanExecute()
        {
            if (EquipeSelected == null)
            {
                SauverEquipeMessage = "Supprimer le equipe sélectionné - Aucun equipe sélectionné";
            }
            else
            {
                SauverEquipeMessage = "Sauver les données du equipe sélectionné";
                return true;
            }
            return false;
        }
        private void SupprimerEquipeCommand_Execute()
        {
            if (_dialogservice.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce equipe ?", "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) == MessageBoxResult.Yes)
            {
                GEquipes.Supprimer(EquipeSelected.EquipeId);
                ReloadEquipes();
            }
        }
        private bool RefreshEquipeCommand_CanExecute()
        {
            return true;
        }
        private void RefreshEquipeCommand_Execute()
        {
            ReloadEquipes();
        }

        #endregion
        #region Méthodes

        public void ListeEquipes()
        {
            _equipes = new ObservableCollection<CEquipes>(GEquipes.Lire("EquipeId"));
        }
        public void ReloadEquipes()
        {
            _equipes.Clear();
            GEquipes.Lire("EquipeId").ToList().ForEach(_equipes.Add);
        }

        #endregion
    }
}
