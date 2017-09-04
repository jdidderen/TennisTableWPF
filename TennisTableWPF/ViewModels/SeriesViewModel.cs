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
    public class SeriesViewModel : ViewModelBase
    {
        #region Propriétés

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

        #endregion
        #region Méthodes - Commandes
        public override bool CreerCommand_CanExecute()
        {
            CreerMessage = "Ajouter une nouvelle série";
            return true;
        }
        public override void CreerCommand_Execute()
        {
            Series.Add(new CSeries());
            SerieSelected = Series[Series.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (SerieSelected == null)
            {
                SauverMessage = "Sauver les données de la série sélectionnée - Aucune série sélectionnée";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données de la série sélectionnée - L'édition n'a pas été activée";
            }
            else if (SerieSelected.Denomination == null)
            {
                SauverMessage = "Sauver les données de la série sélectionnée - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverMessage = "Sauver les données de la série sélectionnée";
                return true;
            }
            return false;
        }
        public override void SauverCommand_Execute()
        {
            base.SauverCommand_Execute();
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
        public override bool ModifierCommand_CanExecute()
        {
            if (SerieSelected == null)
            {
                EditerMessage = "Éditer les données de la série sélectionnée - Aucun série sélectionnée";
            }
            else
            {
                EditerMessage = "Éditer les données de la série sélectionnée";
                return true;
            }
            return false;
        }
        public override void SelectedCommand_Execute()
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
        public override bool SupprimerCommand_CanExecute()
        {
            if (SerieSelected == null)
            {
                SupprimerMessage = "Supprimer la série sélectionnée- Aucune série sélectionnée";
            }
            else
            {
                SupprimerMessage = "Supprimer la série sélectionnée";
                return true;
            }
            return false;
        }
        public override void SupprimerCommand_Execute()
        {
            if (DialogService.ShowMessageBox("Êtes-vous sur de vouloir supprimer cette série ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GSeries.Supprimer(SerieSelected.SerieId);
            ReloadSeries();
        }
        public override void RefreshCommand_Execute()
        {
            ReloadSeries();
        }
        #endregion
    }
}
