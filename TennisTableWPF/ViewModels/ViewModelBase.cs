using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TennisTableWPF.Services;

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
        #endregion
        #region Propriétés
        public IDialogService DialogService { get; set; }
        public ClassementsViewModel ClassementsVm { get; set; }
        public ClubsViewModel ClubsVm { get; set; }
        public SexesViewModel SexesVm { get; set; }
        public JoueursViewModel JoueursVm { get; set; }
        public SeriesViewModel SeriesVm { get; set; }
        public MatchsViewModel MatchsVm { get; set; }
        public EquipesViewModel EquipesVm { get; set; }
        #endregion
        #region Constructeur
        public ViewModelBase()
        {
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
        #endregion
    }
}
