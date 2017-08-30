#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
#endregion

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class C_Joueurs : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Données membres
        private int _JoueurId;
        private int _License;
        private string _Nom;
        private string _Prenom;
        private int _Classement;
        private string _Mail;
        private int _Sexe;
        private int? _Club;
        #endregion
        #region Interfaces
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Validation des données
        public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "Nom")
                {
                    if (this.Nom == "" && this.Nom == null)
                        result = "Le nom ne peut pas être vide";
                    else if (this.Nom == null || !Regex.IsMatch(this.Nom, @"^(\p{L}\p{M}*)+$"))
                        result = "Un nom ne peut contenir que des lettres";
                }
                else if (columnName == "Prenom")
                {
                    if (this.Prenom == "" && this.Prenom == null)
                        result = "Le prénom ne peut pas être vide";
                    else if (this.Prenom == null || !Regex.IsMatch(this.Prenom, @"^(\p{L}\p{M}*)+$"))
                        result = "Un prénom ne peut contenir que des lettres";
                }
                else if (columnName == "License")
                {
                    if (Regex.IsMatch(this.License.ToString(), @"^[0]$"))
                        result = "La license ne peut pas être à 0";
                    else if (String.IsNullOrWhiteSpace(this.License.ToString()))
                        result = "La license ne peut pas être vide";
                }
                else if (columnName == "Classement")
                {
                    if (Regex.IsMatch(this.Classement.ToString(), @"^[0]$"))
                        result = "Vous devez avoir un classement";
                }
                else if (columnName == "Mail")
                {
                    if (this.Mail == "" && this.Mail == null)
                        result = "Le mail ne peut pas être vide";
                    else if (this.Mail == null || !Regex.IsMatch(this.Mail, @"([\w-\.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})"))
                        result = "Votre mail ne semble pas avoir le bon format example@example.com";
                }
                else if (columnName == "Sexe")
                {
                    if (Regex.IsMatch(this.Sexe.ToString(), @"^[0]$"))
                        result = "Êtes-vous humain ? Ou alors vous avez juste oublié de choisir votre sexe ?";
                }
                return result;
            }
        }
        #endregion
        #region Constructeurs
        public C_Joueurs()
        { }
        public C_Joueurs(int License_, string Nom_, string Prenom_, int Classement_, string Mail_, int Sexe_, int? Club_)
        {
            License = License_;
            Nom = Nom_;
            Prenom = Prenom_;
            Classement = Classement_;
            Mail = Mail_;
            Sexe = Sexe_;
            Club = Club_;
        }
        public C_Joueurs(int JoueurId_, int License_, string Nom_, string Prenom_, int Classement_, string Mail_, int Sexe_, int? Club_)
         : this(License_, Nom_, Prenom_, Classement_, Mail_, Sexe_, Club_)
        {
            JoueurId = JoueurId_;
        }
        #endregion
        #region Accesseurs
        public int JoueurId
        {
            get { return _JoueurId; }
            set { _JoueurId = value; OnPropertyChanged("JoueurId"); }
        }
        public int License
        {
            get { return _License; }
            set { _License = value; OnPropertyChanged("License"); }
        }
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; OnPropertyChanged("Nom"); }
        }
        public string Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value; OnPropertyChanged("Prenom"); }
        }
        public int Classement
        {
            get { return _Classement; }
            set { _Classement = value; OnPropertyChanged("Classement"); }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; OnPropertyChanged("Mail"); }
        }
        public int Sexe
        {
            get { return _Sexe; }
            set { _Sexe = value; OnPropertyChanged("Sexe"); }
        }
        public int? Club
        {
            get { return _Club; }
            set { _Club = value; OnPropertyChanged("Club"); }
        }
        #endregion
    }
}
