using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTable;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTable.Acces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace TennisTableWPF.ViewModels
{
    class JoueursViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region ToolTip Messages
        public string CreerJoueurMessage { get; set; }
        public string SupprimerJoueurMessage { get; set; }
        public string ModifierJoueurMessage { get; set; }
        public string EditerJoueurMessage { get; set; }
        #endregion
        #region Commandes
        private ICommand _creerJoueurCommand;
        public ICommand CreerJoueurCommand
        {
            get
            {
                if (_creerJoueurCommand == null)
                {
                    _creerJoueurCommand = new RelayCommands(param => this.CreerJoueurCommand_Execute(param), param => this.CreerJoueurCommand_CanExecute(param));
                }
                return _creerJoueurCommand;
            }
        }
        private ICommand _sauverJoueurCommand;
        public ICommand SauverJoueurCommand
        {
            get
            {
                if (_sauverJoueurCommand == null)
                {
                    _sauverJoueurCommand = new RelayCommands(param => this.SauverJoueurCommand_Execute(param), param => this.SauverJoueurCommand_CanExecute(param));
                }
                return _sauverJoueurCommand;
            }
        }
        #endregion
        #region ObservableCollections
        private ObservableCollection<C_Joueurs> _joueurs;
        public ObservableCollection<C_Joueurs> Joueurs
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
        #endregion
        #region Données 
        public ClassementsViewModel J_Classements { get; set; }
        public ClubsViewModel J_Clubs { get; set; }
        public SexesViewModel J_Sexes { get; set; }
        private C_Joueurs _joueurSelected;
        public C_Joueurs JoueurSelected
        {
            get { return _joueurSelected; }
            set
            {
                _joueurSelected = value;
                OnPropertyChanged("JoueurSelected");
            }
        }
        #endregion
        #region Constructeur
        public JoueursViewModel()
        {
            this.J_Classements = new ClassementsViewModel();
            this.J_Clubs = new ClubsViewModel();
            this.J_Sexes = new SexesViewModel();
        }
        #endregion
        #region Méthodes - Commandes
        private bool CreerJoueurCommand_CanExecute(object param)
        {
            CreerJoueurMessage = "Ajouter un nouveau joueur";
            return true;
        }
        private void CreerJoueurCommand_Execute(object param)
        {
            Joueurs.Add(new C_Joueurs());
            JoueurSelected = Joueurs[Joueurs.Count() - 1];
        }
        private bool SauverJoueurCommand_CanExecute(object param)
        {
            CreerJoueurMessage = "Ajouter un nouveau joueur";
            return true;
        }
        private void SauverJoueurCommand_Execute(object param)
        {
            Joueurs.Add(new C_Joueurs());
            JoueurSelected = Joueurs[Joueurs.Count() - 1];
        }
        #endregion
        #region Méthodes - Données
        public void ListeJoueurs()
        {
            _joueurs = new ObservableCollection<C_Joueurs>(new G_Joueurs().Lire("JoueurId"));
        }
        #endregion
    }
}
