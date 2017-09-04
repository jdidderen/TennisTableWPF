using TennisTable.Classes;
using TennisTable.Gestion;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TennisTableWPF.Services;

namespace TennisTableWPF.ViewModels
{
    public class ClassementsViewModel : ViewModelBase
    {
        #region Propriétés

        private CClassements _classementSelected;
        public CClassements ClassementSelected
        {
            get => _classementSelected;
            set
            {
                _classementSelected = value;
                OnPropertyChanged("ClassementSelected");
            }
        }

        #endregion
        #region Méthodes - Commandes
        public override bool CreerCommand_CanExecute()
        {
            CreerMessage = "Ajouter un nouveau classement";
            return true;
        }
        public override void CreerCommand_Execute()
        {
            Classements.Add(new CClassements());
            ClassementSelected = Classements[Classements.Count - 1];
        }
        public override bool SauverCommand_CanExecute()
        {
            if (ClassementSelected == null)
            {
                SauverMessage = "Sauver les données du classement sélectionné - Aucun classement sélectionné";
            }
            else if (EditerButtonStatus)
            {
                SauverMessage = "Sauver les données du classement sélectionné - L'édition n'a pas été activée";
            }
            else if (ClassementSelected.Classement == null)
            {
                SauverMessage = "Sauver les données du classement sélectionné - Certains champs obligatoires sont vides";
            }
            else
            {
                SauverMessage = "Sauver les données du classement sélectionné";
                return true;
            }
            return false;
        }
        public override void SauverCommand_Execute()
        {
            base.SauverCommand_Execute();
            if (ClassementSelected.ClassementId == 0)
            {
                GClassements.Ajouter(ClassementSelected.Classement);
                ReloadClassements();
            }
            else
            {
                GClassements.Modifier(ClassementSelected.ClassementId, ClassementSelected.Classement);
            }
        }
        public override bool ModifierCommand_CanExecute()
        {
            if (ClassementSelected == null)
            {
                EditerMessage = "Éditer les données du classement sélectionné - Aucun classement sélectionné";
            }
            else
            {
                EditerMessage = "Éditer les données du classement sélectionné";
                return true;
            }
            return false;
        }
        public override void SelectedCommand_Execute()
        {
            if (ClassementSelected != null)
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
            if (ClassementSelected == null)
            {
                SupprimerMessage = "Supprimer le classement sélectionné - Aucun classement sélectionné";
            }
            else
            {
                SupprimerMessage = "Supprimer le classement sélectionné";
                return true;
            }
            return false;
        }
        public override void SupprimerCommand_Execute()
        {
            if (DialogService.ShowMessageBox("Êtes-vous sur de vouloir supprimer ce classement ?",
                    "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxIcon.Exclamation) !=
                MessageBoxResult.Yes) return;
            GClassements.Supprimer(ClassementSelected.ClassementId);
            ReloadClassements();
        }
        public override bool RefreshCommand_CanExecute()
        {
            RefreshMessage = "Recharger les données de la liste - Attention les données en cours d'édition sont perdues";
            return base.RefreshCommand_CanExecute();
        }
        public override void RefreshCommand_Execute()
        {
            ReloadClassements();
        }
        #endregion
    }
}
