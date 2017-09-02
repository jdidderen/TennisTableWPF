using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TennisTable.Classes;
using TennisTable.Gestion;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class SeriesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _creerSerieMessage;
        public string CreerSerieMessage { get => _creerSerieMessage; set { _creerSerieMessage = value; OnPropertyChanged("CreerSerieMessage"); } }
        private string _supprimerSerieMessage;
        public string SupprimerSerieMessage { get => _supprimerSerieMessage; set { _supprimerSerieMessage = value; OnPropertyChanged("SupprimerSerieMessage"); } }
        private string _sauverSerieMessage;
        public string SauverSerieMessage { get => _sauverSerieMessage; set { _sauverSerieMessage = value; OnPropertyChanged("SauverSerieMessage"); } }
        private string _modifierSerieMessage;
        public string ModifierSerieMessage { get => _modifierSerieMessage; set { _modifierSerieMessage = value; OnPropertyChanged("ModifierSerieMessage"); } }
        private string _editerSerieMessage;
        public string EditerSerieMessage { get => _editerSerieMessage; set { _editerSerieMessage = value; OnPropertyChanged("EditerSerieMessage"); } }
        private bool _textBoxStatus;
        public bool TextBoxStatus { get => _textBoxStatus; set { _textBoxStatus = value; OnPropertyChanged("TextBoxStatus"); } }
        private bool _sauverButtonStatus;
        public bool SauverButtonStatus { get => _sauverButtonStatus; set { _sauverButtonStatus = value; OnPropertyChanged("SauverButtonStatus"); } }
        private bool _supprimerButtonStatus;
        public bool SupprimerButtonStatus { get => _supprimerButtonStatus; set { _supprimerButtonStatus = value; OnPropertyChanged("SupprimerButtonStatus"); } }
        private bool _editerButtonStatus;
        public bool EditerButtonStatus { get => _editerButtonStatus; set { _editerButtonStatus = value; OnPropertyChanged("EditerButtonStatus"); } }
        private ICommand _creerSerieCommand;
        public ICommand CreerSerieCommand
        {
            get
            {
                return _creerSerieCommand ?? (_creerSerieCommand = new RelayCommands(param => CreerSerieCommand_Execute(),
                           param => CreerSerieCommand_CanExecute()));
            }
        }
        private ICommand _sauverSerieCommand;
        public ICommand SauverSerieCommand
        {
            get
            {
                return _sauverSerieCommand ?? (_sauverSerieCommand =
                           new RelayCommands(param => SauverSerieCommand_Execute(),
                               param => SauverSerieCommand_CanExecute()));
            }
        }
        private ICommand _modifierSerieCommand;
        public ICommand ModifierSerieCommand
        {
            get
            {
                return _modifierSerieCommand ?? (_modifierSerieCommand =
                           new RelayCommands(param => ModifierSerieCommand_Execute(),
                               param => ModifierSerieCommand_CanExecute()));
            }
        }
        private ICommand _seriesSelectedCommand;
        public ICommand SeriesSelectedCommand
        {
            get
            {
                return _seriesSelectedCommand ?? (_seriesSelectedCommand =
                           new RelayCommands(param => SeriesSelectedCommand_Execute(),
                               param => SeriesSelectedCommand_CanExecute()));
            }
        }
        private ICommand _supprimerSerieCommand;
        public ICommand SupprimerSerieCommand
        {
            get
            {
                return _supprimerSerieCommand ?? (_supprimerSerieCommand =
                           new RelayCommands(param => SupprimerSerieCommand_Execute(),
                               param => SupprimerSerieCommand_CanExecute()));
            }
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
        }
        private readonly IDialogService _dialogservice;
        public ClassementsViewModel JClassements { get; set; }
        public ClubsViewModel JClubs { get; set; }
        public SeriesViewModel JSeries { get; set; }
        public GSeries GSeries;
        private CSeries _serieSelected;
        public CSeries SerieSelected
        {
            get => _serieSelected;
            set
            {
                _serieSelected = value;
                OnPropertyChanged("SerieSelected");
            }
        }
        public SeriesViewModel(IDialogService dialogservice)
        {
            _dialogservice = dialogservice;
            GSeries = new GSeries();
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            SupprimerButtonStatus = false;
        }
        private bool CreerSerieCommand_CanExecute()
        {
            CreerSerieMessage = "Ajouter un nouveau serie";
            return true;
        }
        private void CreerSerieCommand_Execute()
        {
            Series.Add(new CSeries());
            SerieSelected = Series[Series.Count - 1];
        }
        private bool SauverSerieCommand_CanExecute()
        {
            if (SerieSelected == null)
            {
                SauverSerieMessage = "Sauver les données du serie sélectionné - Aucun serie sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverSerieMessage = "Sauver les données du serie sélectionné - L'édition n'a pas été activée";
            }
            else if (SerieSelected.Denomination == null)
            {
                SauverSerieMessage = "Sauver les données du serie sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverSerieMessage = "Sauver les données du serie sélectionné";
                return true;
            }
            return false;
        }
        private void SauverSerieCommand_Execute()
        {
            TextBoxStatus = false;
            SauverButtonStatus = false;
            EditerButtonStatus = true;
            if (SerieSelected.SerieId == 0)
            {
                GSeries.Ajouter(SerieSelected.Denomination);
                ReloadSeries();
            }
            else
            {
                GSeries.Modifier(SerieSelected.SerieId, SerieSelected.Denomination);
            }

        }
        private bool ModifierSerieCommand_CanExecute()
        {
            if (SerieSelected == null)
            {
                _editerSerieMessage = "Éditer les données du serie sélectionné - Aucun serie sélectionné";
            }
            else
            {
                _editerSerieMessage = "Éditer les données du serie sélectionné";
                return true;
            }
            return false;
        }
        private void ModifierSerieCommand_Execute()
        {
            TextBoxStatus = true;
            SauverButtonStatus = true;
            EditerButtonStatus = false;
        }
        private bool SeriesSelectedCommand_CanExecute()
        {
            return true;
        }
        private void SeriesSelectedCommand_Execute()
        {
            if (SerieSelected != null)
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
        private bool SupprimerSerieCommand_CanExecute()
        {
            if (SerieSelected == null)
            {
                SauverSerieMessage = "Supprimer le serie sélectionné - Aucun serie sélectionné";
            }
            else
            {
                SauverSerieMessage = "Sauver les données du serie sélectionné";
                return true;
            }
            return false;
        }
        private void SupprimerSerieCommand_Execute()
        {
            if (_dialogservice.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce serie ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GSeries.Supprimer(SerieSelected.SerieId);
            ReloadSeries();
        }
        public void ListeSeries()
        {
            _series = new ObservableCollection<CSeries>(GSeries.Lire("SerieId"));
        }
        public void ReloadSeries()
        {
            _series.Clear();
            GSeries.Lire("SerieId").ToList().ForEach(_series.Add);
        }
    }
}
