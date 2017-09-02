using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class CClassements : PropertiesChanges, IDataErrorInfo
    {
        private int _classementId;
        private string _classement;
        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                return result;
            }
        }
        public CClassements()
        { }
        public CClassements(string classement)
        {
            _classement = classement;
        }
        public CClassements(int classementId, string classement)
         : this(classement)
        {
            _classementId = classementId;
        }

        public int ClassementId
        {
            get => _classementId;
            set { _classementId = value; OnPropertyChanged("ClassementId"); }
        }
        public string Classement
        {
            get => _classement;
            set { _classement = value; OnPropertyChanged("Classement"); }
        }
    }
}
