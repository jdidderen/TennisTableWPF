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
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    class JoueursViewModel : INotifyPropertyChanged
    {
        #region Interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region ToolTip Messages
        private string creerJoueurMessage;
        public string CreerJoueurMessage { get => creerJoueurMessage; set { creerJoueurMessage = value; OnPropertyChanged("CreerJoueurMessage"); } }
        private string supprimerJoueurMessage;
        public string SupprimerJoueurMessage { get => supprimerJoueurMessage; set { supprimerJoueurMessage = value; OnPropertyChanged("SupprimerJoueurMessage"); } }
        private string sauverJoueurMessage;
        public string SauverJoueurMessage { get => sauverJoueurMessage; set { sauverJoueurMessage = value; OnPropertyChanged("SauverJoueurMessage"); } }
        private string modifierJoueurMessage;
        public string ModifierJoueurMessage { get => modifierJoueurMessage; set { modifierJoueurMessage = value; OnPropertyChanged("ModifierJoueurMessage"); } }
        private string editerJoueurMessage;
        public string EditerJoueurMessage { get => editerJoueurMessage; set { editerJoueurMessage = value; OnPropertyChanged("EditerJoueurMessage"); } }
        #endregion
        #region Controls Status
        private bool textBoxStatus;
        public bool TextBoxStatus { get => textBoxStatus; set { textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool sauverButtonStatus;
        public bool SauverButtonStatus { get => sauverButtonStatus; set { sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => supprimerButtonStatus; set { supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool editerButtonStatus;
        public bool EditerButtonStatus { get => editerButtonStatus; set { editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }
        #endregion
        #region Commandes
        private ICommand creerJoueurCommand;
        public ICommand CreerJoueurCommand
        {
            get
            {
                if (creerJoueurCommand == null)
                {
                    creerJoueurCommand = new RelayCommands(param => this.CreerJoueurCommand_Execute(param), param => this.CreerJoueurCommand_CanExecute(param));
                }
                return creerJoueurCommand;
            }
        }
        private ICommand sauverJoueurCommand;
        public ICommand SauverJoueurCommand
        {
            get
            {
                if (sauverJoueurCommand == null)
                {
                    sauverJoueurCommand = new RelayCommands(param => this.SauverJoueurCommand_Execute(param), param => this.SauverJoueurCommand_CanExecute(param));
                }
                return sauverJoueurCommand;
            }
        }
        private ICommand modifierJoueurCommand;
        public ICommand ModifierJoueurCommand
        {
            get
            {
                if (modifierJoueurCommand == null)
                {
                    modifierJoueurCommand = new RelayCommands(param => this.ModifierJoueurCommand_Execute(param), param => this.ModifierJoueurCommand_CanExecute(param));
                }
                return modifierJoueurCommand;
            }
        }
        private ICommand joueursSelectedCommand;
        public ICommand JoueursSelectedCommand
        {
            get
            {
                if (joueursSelectedCommand == null)
                {
                    joueursSelectedCommand = new RelayCommands(param => this.JoueursSelectedCommand_Execute(param), param => this.JoueursSelectedCommand_CanExecute(param));
                }
                return joueursSelectedCommand;
            }
        }
        private ICommand supprimerJoueurCommand;
        public ICommand SupprimerJoueurCommand
        {
            get
            {
                if (supprimerJoueurCommand == null)
                {
                    supprimerJoueurCommand = new RelayCommands(param => this.SupprimerJoueurCommand_Execute(param), param => this.SupprimerJoueurCommand_CanExecute(param));
                }
                return supprimerJoueurCommand;
            }
        }
        #endregion
        #region ObservableCollections
        private ObservableCollection<C_Joueurs> joueurs;
        public ObservableCollection<C_Joueurs> Joueurs
        {
            get
            {
                if (joueurs == null)
                {
                    ListeJoueurs();
                }
                return joueurs;
            }
        }
        #endregion
        #region Données 
        private IDialogService _dialogservice;
        public ClassementsViewModel J_Classements { get; set; }
        public ClubsViewModel J_Clubs { get; set; }
        public SexesViewModel J_Sexes { get; set; }
        public G_Joueurs GJoueurs;
        private C_Joueurs joueurSelected;  
        public C_Joueurs JoueurSelected
        {
            get { return joueurSelected; }
            set
            {
                joueurSelected = value;
                OnPropertyChanged("JoueurSelected");
            }
        }
        #endregion
        #region Constructeur
        public JoueursViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            this.J_Classements = new ClassementsViewModel();
            this.J_Clubs = new ClubsViewModel();
            this.J_Sexes = new SexesViewModel();
            this.GJoueurs = new G_Joueurs();
            this.TextBoxStatus = false;
            this.SauverButtonStatus = false;
            this.EditerButtonStatus = true;
            this.SupprimerButtonStatus = false;
        }
        #endregion
        #region Méthodes - Commandes
        private bool CreerJoueurCommand_CanExecute(object param)
        {
            this.CreerJoueurMessage = "Ajouter un nouveau joueur";
            return true;
        }
        private void CreerJoueurCommand_Execute(object param)
        {
            this.Joueurs.Add(new C_Joueurs());
            this.JoueurSelected = this.Joueurs[this.Joueurs.Count() - 1];
        }
        private bool SauverJoueurCommand_CanExecute(object param)
        {
            if (this.JoueurSelected == null)
            {
                this.SauverJoueurMessage = "Sauver les données du joueur sélectionné - Aucun joueur sélectionné";
            }
            else if (this.EditerButtonStatus == true)
            {
                this.SauverJoueurMessage = "Sauver les données du joueur sélectionné - L'édition n'a pas été activée";
            }
            else if (this.JoueurSelected.Nom == null && this.JoueurSelected.Prenom == null && this.JoueurSelected.License == 0 && this.JoueurSelected.Classement == 0 && this.JoueurSelected.Mail == null && this.JoueurSelected.Sexe == 0)
            {
                this.SauverJoueurMessage = "Sauver les données du joueur sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                this.SauverJoueurMessage = "Sauver les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        private void SauverJoueurCommand_Execute(object param)
        {
            this.TextBoxStatus = false;
            this.SauverButtonStatus = false;
            this.EditerButtonStatus = true;
            if(this.JoueurSelected.JoueurId == 0)
            {
                GJoueurs.Ajouter(this.JoueurSelected.License, this.JoueurSelected.Nom, this.JoueurSelected.Prenom, this.JoueurSelected.Classement, this.JoueurSelected.Mail, this.JoueurSelected.Sexe, this.JoueurSelected.Club);
                ReloadJoueurs();
            }
            else
            {
                GJoueurs.Modifier(this.JoueurSelected.JoueurId, this.JoueurSelected.License, this.JoueurSelected.Nom, this.JoueurSelected.Prenom, this.JoueurSelected.Classement, this.JoueurSelected.Mail, this.JoueurSelected.Sexe, this.JoueurSelected.Club);
            }
            
        }
        private bool ModifierJoueurCommand_CanExecute(object param)
        {
            if (this.JoueurSelected == null)
            {
                this.editerJoueurMessage = "Éditer les données du joueur sélectionné - Aucun joueur sélectionné";
            }
            else
            {
                this.editerJoueurMessage = "Éditer les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        private void ModifierJoueurCommand_Execute(object param)
        {
            this.TextBoxStatus = true;
            this.SauverButtonStatus = true;
            this.EditerButtonStatus = false;
        }
        private bool JoueursSelectedCommand_CanExecute(object param)
        {
            return true;
        }
        private void JoueursSelectedCommand_Execute(object param)
        {
            if (this.JoueurSelected != null)
            {
                this.TextBoxStatus = false;
                this.SauverButtonStatus = false;
                this.EditerButtonStatus = true;
            }
            else
            {
                this.TextBoxStatus = false;
                this.SauverButtonStatus = false;
                this.EditerButtonStatus = false;
            }
        }
        private bool SupprimerJoueurCommand_CanExecute(object param)
        {
            if (JoueurSelected == null)
            {
                this.SauverJoueurMessage = "Supprimer le joueur sélectionné - Aucun joueur sélectionné";
            }
            else
            {
                this.SauverJoueurMessage = "Sauver les données du joueur sélectionné";
                return true;
            }
            return false;
        }
        private void SupprimerJoueurCommand_Execute(object param)
        {
            if(_dialogservice.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce joueur ?", "Confirmation de suppresion", MessageBoxButton.YesNo, Services.MessageBoxIcon.Exclamation) == MessageBoxResult.Yes)
            {
                GJoueurs.Supprimer(this.JoueurSelected.JoueurId);
                ReloadJoueurs();
            }
        }
        #endregion
        #region Méthodes - Données
        public void ListeJoueurs()
        {
            this.joueurs = new ObservableCollection<C_Joueurs>(GJoueurs.Lire("JoueurId"));
        }
        public void ReloadJoueurs()
        {
            this.joueurs.Clear();
            GJoueurs.Lire("JoueurId").ToList().ForEach(this.joueurs.Add);
        }
        #endregion
    }
}
