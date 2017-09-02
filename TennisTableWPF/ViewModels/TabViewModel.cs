using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TennisTableWPF.Services;
using TennisTableWPF.Services.Tabs;
using TennisTableWPF.Views;

namespace TennisTableWPF.ViewModels
{
    public class TabViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<TabsModel> _tabs;
        public ObservableCollection<TabsModel> Tabs
        {
            get => _tabs;
            set
            {
                _tabs = value;
                OnPropertyChanged("Tabs");
            }
        }
        private TabsModel _tabsSelected;
        public TabsModel TabsSelected
        {
            get => _tabsSelected;
            set
            {
                _tabsSelected = value;
                OnPropertyChanged("TabsSelected");
            }
        }
        private readonly IDialogService _dialogservice;
        public TabViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            Tabs = new ObservableCollection<TabsModel>();
        }
        private ICommand _addToTabJoueursViewCommand;
        public ICommand AddToTabJoueursViewCommand
        {
            get
            {
                return _addToTabJoueursViewCommand ?? (_addToTabJoueursViewCommand =
                           new RelayCommands(param => AddToTabJoueursViewCommand_Execute(),
                               param => AddToTabJoueursViewCommand_CanExecute()));
            }
        }
        private ICommand _addToTabMatchsViewCommand;
        public ICommand AddToTabMatchsViewCommand
        {
            get
            {
                return _addToTabMatchsViewCommand ?? (_addToTabMatchsViewCommand =
                           new RelayCommands(param => AddToTabMatchsViewCommand_Execute(),
                               param => AddToTabMatchsViewCommand_CanExecute()));
            }
        }
        private ICommand _addToTabEquipesViewCommand;
        public ICommand AddToTabEquipesViewCommand
        {
            get
            {
                return _addToTabEquipesViewCommand ?? (_addToTabEquipesViewCommand =
                           new RelayCommands(param => AddToTabEquipesViewCommand_Execute(),
                               param => AddToTabEquipesViewCommand_CanExecute()));
            }
        }
        private ICommand _addToTabStaticDatasViewCommand;
        public ICommand AddToTabStaticDatasViewCommand
        {
            get
            {
                return _addToTabStaticDatasViewCommand ?? (_addToTabStaticDatasViewCommand =
                           new RelayCommands(param => AddToTabStaticDatasViewCommand_Execute(),
                               param => AddToTabStaticDatasViewCommand_CanExecute()));
            }
        }
        private ICommand _addToTabClubsViewCommand;
        public ICommand AddToTabClubsViewCommand
        {
            get
            {
                return _addToTabClubsViewCommand ?? (_addToTabClubsViewCommand =
                           new RelayCommands(param => AddToTabClubsViewCommand_Execute(),
                               param => AddToTabClubsViewCommand_CanExecute()));
            }
        }
        private ICommand _closeTabViewCommand;
        public ICommand CloseTabViewCommand
        {
            get
            {
                return _closeTabViewCommand ?? (_closeTabViewCommand =
                           new RelayCommands(param => CloseTabViewCommand_Execute(),
                               param => CloseTabViewCommand_CanExecute()));
            }
        }
        private bool CloseTabViewCommand_CanExecute()
        {
            return TabsSelected != null;
        }
        private void CloseTabViewCommand_Execute()
        {
            Tabs.Remove(TabsSelected);
            if (TabsSelected == null) return;
            TabsSelected = Tabs.First();
        }
        private bool AddToTabJoueursViewCommand_CanExecute()
        {
            return true;
        }
        private void AddToTabJoueursViewCommand_Execute()
        {
            Tabs.Add(new TabsModel {CurrentMyTabContentViewModel = new JoueursTabContentViewModel(),Header = "Liste des joueurs"});
            TabsSelected = Tabs[Tabs.Count - 1];
        }
        private bool AddToTabClubsViewCommand_CanExecute()
        {
            return true;
        }
        private void AddToTabClubsViewCommand_Execute()
        {
            Tabs.Add(new TabsModel { CurrentMyTabContentViewModel = new ClubsTabContentViewModel(), Header = "Liste des clubs" });
            TabsSelected = Tabs[Tabs.Count - 1];
        }
        private bool AddToTabMatchsViewCommand_CanExecute()
        {
            return true;
        }
        private void AddToTabMatchsViewCommand_Execute()
        {
            Tabs.Add(new TabsModel { CurrentMyTabContentViewModel = new MatchsTabContentViewModel(), Header = "Liste des matchs" });
            TabsSelected = Tabs[Tabs.Count - 1];
        }
        private bool AddToTabEquipesViewCommand_CanExecute()
        {
            return true;
        }
        private void AddToTabEquipesViewCommand_Execute()
        {
            Tabs.Add(new TabsModel { CurrentMyTabContentViewModel = new EquipesTabContentViewModel(), Header = "Liste des équipes" });
            TabsSelected = Tabs[Tabs.Count - 1];
        }
        private bool AddToTabStaticDatasViewCommand_CanExecute()
        {
            return true;
        }
        private void AddToTabStaticDatasViewCommand_Execute()
        {
            Tabs.Add(new TabsModel { CurrentMyTabContentViewModel = new StaticDatasTabContentViewModel(), Header = "Données statiques" });
            TabsSelected = Tabs[Tabs.Count - 1];
        }
    }
}
