using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TennisTable.Classes
{
    /// <summary>
    /// Classe de définition des données
    /// </summary>
    public class CJoueurs : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _joueurId;
        private int _license;
        private string _nom;
        private string _prenom;
        private int _classement;
        private string _mail;
        private int _sexe;
        private int? _club;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "Nom")
                {
                    if (Nom == "" && Nom == null)
                        result = "Le nom ne peut pas être vide";
                    else if (Nom == null || !Regex.IsMatch(Nom, @"^(\p{L}\p{M}*\p{Z}*)+$"))
                        result = "Un nom ne peut contenir que des lettres";
                }
                else if (columnName == "Prenom")
                {
                    if (Prenom == "" && Prenom == null)
                        result = "Le prénom ne peut pas être vide";
                    else if (Prenom == null || !Regex.IsMatch(Prenom, @"^(\p{L}\p{M}*\p{Z}*)+$"))
                        result = "Un prénom ne peut contenir que des lettres";
                }
                else if (columnName == "License")
                {
                    if (Regex.IsMatch(License.ToString(), @"^[0]$"))
                        result = "La license ne peut pas être à 0";
                    else if (String.IsNullOrWhiteSpace(License.ToString()))
                        result = "La license ne peut pas être vide";
                }
                else if (columnName == "Classement")
                {
                    if (Regex.IsMatch(Classement.ToString(), @"^[0]$"))
                        result = "Vous devez avoir un classement";
                }
                else if (columnName == "Mail")
                {
                    if (Mail == "" && Mail == null)
                        result = "Le mail ne peut pas être vide";
                    else if (Mail == null || !Regex.IsMatch(Mail, @"([\w-\.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})"))
                        result = "Votre mail ne semble pas avoir le bon format example@example.com";
                }
                else if (columnName == "Sexe")
                {
                    if (Regex.IsMatch(Sexe.ToString(), @"^[0]$"))
                        result = "Êtes-vous humain ? Ou alors vous avez juste oublié de choisir votre sexe ?";
                }
                return result;
            }
        }

        public CJoueurs()
        { }
        public CJoueurs(int license, string nom, string prenom, int classement, string mail, int sexe, int? club)
        {
            License = license;
            Nom = nom;
            Prenom = prenom;
            Classement = classement;
            Mail = mail;
            Sexe = sexe;
            Club = club;
        }
        public CJoueurs(int joueurId, int license, string nom, string prenom, int classement, string mail, int sexe, int? club)
         : this(license, nom, prenom, classement, mail, sexe, club)
        {
            JoueurId = joueurId;
        }

        public int JoueurId
        {
            get => _joueurId;
            set { _joueurId = value; OnPropertyChanged("JoueurId"); }
        }
        public int License
        {
            get => _license;
            set { _license = value; OnPropertyChanged("License"); }
        }
        public string Nom
        {
            get => _nom;
            set { _nom = value; OnPropertyChanged("Nom"); }
        }
        public string Prenom
        {
            get => _prenom;
            set { _prenom = value; OnPropertyChanged("Prenom"); }
        }
        public int Classement
        {
            get => _classement;
            set { _classement = value; OnPropertyChanged("Classement"); }
        }
        public string Mail
        {
            get => _mail;
            set { _mail = value; OnPropertyChanged("Mail"); }
        }
        public int Sexe
        {
            get => _sexe;
            set { _sexe = value; OnPropertyChanged("Sexe"); }
        }
        public int? Club
        {
            get => _club;
            set { _club = value; OnPropertyChanged("Club"); }
        }
    }
}
