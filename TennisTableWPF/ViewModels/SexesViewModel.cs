using System.Linq;
using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class SexesViewModel : ViewModelBase
    {
        #region Propriétés
        private CSexes _sexeSelected;
        public CSexes SexeSelected
        {
            get => _sexeSelected;
            set
            {
                _sexeSelected = value;
                OnPropertyChanged("SexeSelected");
            }
        }
        #endregion
        #region Méthodes - Commandes
        public override bool CreerCommand_CanExecute()
        {
            CreerMessage = "Ajouter un nouveau sexe";
            return true;
        }
        public override void CreerCommand_Execute()
        {
            Sexes.Add(new CSexes());
            SexeSelected = Sexes[Sexes.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (SexeSelected == null)
            {
                SauverMessage = "Sauver les données du sexe sélectionné - Aucun sexe sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données du sexe sélectionné - L'édition n'a pas été activée";
            }
            else if (SexeSelected.Denomination == null)
            {
                SauverMessage = "Sauver les données du sexe sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverMessage = "Sauver les données du sexe sélectionné";
                return true;
            }
            return false;
        }
        public override void SauverCommand_Execute()
        {
            base.SauverCommand_Execute();
            if (SexeSelected.SexeId == 0)
            {
                GSexes.Ajouter(SexeSelected.Denomination);
                Reload();
            }
            else
            {
                GSexes.Modifier(SexeSelected.SexeId, SexeSelected.Denomination);
            }
        }
        public override bool ModifierCommand_CanExecute()
        {
            if (SexeSelected == null)
            {
                EditerMessage = "Éditer les données du sexe sélectionné - Aucun sexe sélectionné";
            }
            else
            {
                EditerMessage = "Éditer les données du sexe sélectionné";
                return true;
            }
            return false;
        }
        public override void SelectedCommand_Execute()
        {
            if (SexeSelected != null)
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
            if (SexeSelected == null)
            {
                SupprimerMessage = "Supprimer le sexe sélectionné - Aucun sexe sélectionné";
            }
            else
            {
                SupprimerMessage = "Supprimer le sexe sélectionné";
                return true;
            }
            return false;
        }
        public override void SupprimerCommand_Execute()
        {
            if (DialogService.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce sexe ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GSexes.Supprimer(SexeSelected.SexeId);
            Reload();
        }
        public override void RefreshCommand_Execute()
        {
            Reload();
        }
        #endregion
        #region Méthodes

        #endregion
    }
}
