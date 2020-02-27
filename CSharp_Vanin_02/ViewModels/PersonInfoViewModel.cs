using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CSharp_Vanin_02.Models;
using CSharp_Vanin_02.Tools;
using CSharp_Vanin_02.Tools.Managers;

namespace CSharp_Vanin_02.ViewModels
{
    class PersonInfoViewModel: BaseViewModel, ILoaderOwner
    {
        #region Fields
        private Person _person;
        private RelayCommand<object> _proceedCommand;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate = DateTime.Today;

        private string _personInfo;

        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }
        private Person Person
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public string PersonInfo
        {
            get => _personInfo;
            private set
            {
                _personInfo = value;
                OnPropertyChanged();
            }
        }
        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(
                    ShowPersonInfo, o => CanExecuteCommand());
            }
        }
        #endregion
        
        private async void ShowPersonInfo(object obj)
            {
                LoaderManager.Instance.ShowLoader();
                await Task.Run(() =>
                {
                    try
                    {
                        PersonInfo = "";
                        Person = new Person(_name,_surname,_email,_birthDate);
                        Thread.Sleep(3000);
                        PersonInfo = $"Person: {Person.Name} {Person.Surname}\n" +
                                  $"Email: {Person.Email}\n" +
                                  $"BirthDate: {Person.BirthDate:dd/MM/yyyy}\n" +
                                  $"Western Zodiac: {Person.WesternZodiac}\n" +
                                  $"Chinese Zodiac: {Person.ChineseZodiac}\n" +
                                  $"IsBirthday: {Person.IsBirthday}\n" +
                                  $"IsAdult: {Person.IsAdult}";
                        if (Person.IsBirthday) MessageBox.Show("Happy Birthday!");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
                LoaderManager.Instance.HideLoader();
        }

        private bool CanExecuteCommand()
        {
            return (!string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname) &&
                    !string.IsNullOrWhiteSpace(_email));
        }

        #region Constructor
        internal PersonInfoViewModel()
        {
            Date = DateTime.Today;
            LoaderManager.Instance.Initialize(this);
        }
        
        #endregion
       
    }
}
