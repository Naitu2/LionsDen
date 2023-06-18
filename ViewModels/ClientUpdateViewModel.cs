using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Service;
using LionsDen.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace LionsDen.ViewModels
{
    class ClientUpdateViewModel : BaseViewModel
    {
        private Client updatedClient;
        public ICommand ReturnNavigateCommand { get; }
        private ICommand _deleteClientCommand;
        public ICommand DeleteClientCommand
        {
            get { return _deleteClientCommand ?? (_deleteClientCommand = new RelayCommand(ExecuteDeleteClientCommand)); }
        }
        private ICommand _updateClientCommand;
        public ICommand UpdateClientCommand
        {
            get { return _updateClientCommand ?? (_updateClientCommand = new RelayCommand(ExecuteUpdateClientCommand)); }
        }
        public ClientUpdateViewModel(NavigationStore navigationStore, Client clickedClient)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new ClientInformationViewModel(navigationStore));
            _txtFirstName = clickedClient.FirstName;
            _txtLastName = clickedClient.LastName;
            _cmbGender = clickedClient.Gender;
            _dpDateOfBirth = clickedClient.DateOfBirth;
            _txtAddress = clickedClient.Address;
            _txtPhoneNumber = clickedClient.PhoneNumber;
            _txtEmail = clickedClient.Email;
            _txtHeight = clickedClient.Height.ToString();
            _txtWeight = clickedClient.Weight.ToString();
            _txtBodyFat = clickedClient.FatPercentage.ToString();
            _cmbMembDur = clickedClient.MembershipDuration;

            updatedClient = clickedClient;
        }
        public ObservableCollection<string> GenderOptions { get; } = new ObservableCollection<string>
        {
         "Male",
         "Female",
         "Other"
        };
        public ObservableCollection<string> MembDurOptions { get; } = new ObservableCollection<string>
        {
         "1 month",
         "3 months",
         "6 months",
         "12 months"
        };

        private string _txtFirstName;
        public string TxtFirstName
        {
            get { return _txtFirstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    FirstNameBorderColor = Brushes.Yellow;
                }
                OnPropertyChanged(nameof(FirstNameBorderColor));
                OnPropertyChanged(nameof(TxtFirstName));
                _txtFirstName = value;
            }
        }
        private string _txtLastName;
        public string TxtLastName
        {
            get { return _txtLastName; }
            set
            {
                _txtLastName = value;
                if (!string.IsNullOrEmpty(value))
                {
                    LastNameBorderColor = Brushes.Yellow;
                }
                OnPropertyChanged(nameof(TxtLastName));
                OnPropertyChanged(nameof(LastNameBorderColor));
            }
        }
        private string _cmbGender;
        public string CmbGender
        {
            get { return _cmbGender; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    GenderBorderColor = Brushes.Yellow;
                }
                _cmbGender = value;
                OnPropertyChanged(nameof(CmbGender));
                OnPropertyChanged(nameof(GenderBorderColor));
            }
        }
        private DateTime? _dpDateOfBirth;
        public DateTime? DpDateOfBirth
        {
            get { return _dpDateOfBirth; }
            set
            {
                if (!Validation.IsValidDateOfBirth(value))
                {
                    DateOfBirthVisibility = Visibility.Visible;
                    DateOfBirthBorderColor = Brushes.Red;
                }
                else
                {
                    DateOfBirthVisibility = Visibility.Collapsed;
                    DateOfBirthBorderColor = Brushes.Yellow;
                }
                _dpDateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirthVisibility));
                OnPropertyChanged(nameof(DateOfBirthBorderColor));
            }
        }
        private string _txtAddress;
        public string TxtAddress
        {
            get { return _txtAddress; }
            set
            {
                _txtAddress = value;
                if (!string.IsNullOrEmpty(value))
                {
                    AddressBorderColor = Brushes.Yellow;
                }
                OnPropertyChanged(nameof(TxtAddress));
                OnPropertyChanged(nameof(AddressBorderColor));
            }
        }

        private string _txtPhoneNumber;
        public string TxtPhoneNumber
        {
            get { return _txtPhoneNumber; }
            set
            {
                if (!Validation.IsValidPhoneNumber(value))
                {
                    PhoneNumberVisibility = Visibility.Visible;
                    PhoneNumberBorderColor = Brushes.Red;
                }
                else
                {
                    PhoneNumberVisibility = Visibility.Collapsed;
                    PhoneNumberBorderColor = Brushes.Yellow;
                }
                _txtPhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumberVisibility));
                OnPropertyChanged(nameof(PhoneNumberBorderColor));
            }
        }
        private string _txtEmail;
        public string TxtEmail
        {
            get { return _txtEmail; }
            set
            {
                if (!Validation.IsValidEmail(value))
                {
                    EmailVisibility = Visibility.Visible;
                    EmailBorderColor = Brushes.Red;
                }
                else
                {
                    EmailVisibility = Visibility.Collapsed;
                    EmailBorderColor = Brushes.Yellow;
                }
                _txtEmail = value;
                OnPropertyChanged(nameof(EmailVisibility));
                OnPropertyChanged(nameof(EmailBorderColor));
            }
        }
        private string _txtHeight;
        public string TxtHeight
        {
            get { return _txtHeight; }
            set
            {
                if (!Validation.IsValidDouble(value))
                {
                    HeightVisibility = Visibility.Visible;
                    HeightBorderColor = Brushes.Red;
                }
                else
                {
                    HeightVisibility = Visibility.Collapsed;
                    HeightBorderColor = Brushes.Yellow;
                }
                _txtHeight = value;
                OnPropertyChanged(nameof(HeightVisibility));
                OnPropertyChanged(nameof(HeightBorderColor));
            }
        }
        private string _txtWeight;
        public string TxtWeight
        {
            get { return _txtWeight; }
            set
            {
                if (!Validation.IsValidDouble(value))
                {
                    WeightVisibility = Visibility.Visible;
                    WeightBorderColor = Brushes.Red;
                }
                else
                {
                    WeightVisibility = Visibility.Collapsed;
                    WeightBorderColor = Brushes.Yellow;
                }
                _txtWeight = value;
                OnPropertyChanged(nameof(WeightVisibility));
                OnPropertyChanged(nameof(WeightBorderColor));
            }
        }
        private string _txtBodyFat;
        public string TxtBodyFat
        {
            get { return _txtBodyFat; }
            set
            {
                if (!Validation.IsValidPercents(value))
                {
                    BodyFatVisibility = Visibility.Visible;
                    BodyFatBorderColor = Brushes.Red;
                }
                else
                {
                    BodyFatVisibility = Visibility.Collapsed;
                    BodyFatBorderColor = Brushes.Yellow;
                }
                _txtBodyFat = value;
                OnPropertyChanged(nameof(BodyFatVisibility));
                OnPropertyChanged(nameof(BodyFatBorderColor));
            }
        }
        private string _cmbMembDur;
        public string CmbMembDur
        {
            get { return _cmbMembDur; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MembDurBorderColor = Brushes.Yellow;
                }
                _cmbMembDur = value?.Split(':').LastOrDefault()?.Trim();
                OnPropertyChanged(nameof(CmbMembDur));
                OnPropertyChanged(nameof(MembDurBorderColor));
            }
        }

        public Brush FirstNameBorderColor { get; set; } = Brushes.Yellow;
        public Brush LastNameBorderColor { get; set; } = Brushes.Yellow;
        public Brush GenderBorderColor { get; set; } = Brushes.Yellow;
        public Brush DateOfBirthBorderColor { get; set; } = Brushes.Yellow;
        public Brush AddressBorderColor { get; set; } = Brushes.Yellow;
        public Brush PhoneNumberBorderColor { get; set; } = Brushes.Yellow;
        public Brush EmailBorderColor { get; set; } = Brushes.Yellow;
        public Brush HeightBorderColor { get; set; } = Brushes.Yellow;
        public Brush WeightBorderColor { get; set; } = Brushes.Yellow;
        public Brush BodyFatBorderColor { get; set; } = Brushes.Yellow;
        public Brush MembDurBorderColor { get; set; } = Brushes.Yellow;


        public Visibility DateOfBirthVisibility { get; set; } = Visibility.Collapsed;
        public Visibility PhoneNumberVisibility { get; set; } = Visibility.Collapsed;
        public Visibility EmailVisibility { get; set; } = Visibility.Collapsed;
        public Visibility HeightVisibility { get; set; } = Visibility.Collapsed;
        public Visibility WeightVisibility { get; set; } = Visibility.Collapsed;
        public Visibility BodyFatVisibility { get; set; } = Visibility.Collapsed;

        private void ExecuteDeleteClientCommand(object parameter)
        {
            MemberStore.ClientList.Remove(updatedClient);
            FileExplorer.DeleteMemberData(updatedClient);
            ReturnNavigateCommand.Execute(parameter);
        }
        private void ExecuteUpdateClientCommand(object parameter)
        {
            if (string.IsNullOrEmpty(TxtFirstName))
            {
                FirstNameBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(TxtLastName))
            {
                LastNameBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(CmbGender))
            {
                GenderBorderColor = Brushes.Red;
            }
            if (DpDateOfBirth == null)
            {
                DateOfBirthBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(TxtAddress))
            {
                AddressBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(TxtPhoneNumber))
            {
                PhoneNumberBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(TxtEmail))
            {
                EmailBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(TxtHeight))
            {
                HeightBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(TxtWeight))
            {
                WeightBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(TxtBodyFat))
            {
                BodyFatBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(CmbMembDur))
            {
                MembDurBorderColor = Brushes.Red;
            }

            OnPropertyChanged(nameof(FirstNameBorderColor));
            OnPropertyChanged(nameof(LastNameBorderColor));
            OnPropertyChanged(nameof(GenderBorderColor));
            OnPropertyChanged(nameof(DateOfBirthBorderColor));
            OnPropertyChanged(nameof(AddressBorderColor));
            OnPropertyChanged(nameof(PhoneNumberBorderColor));
            OnPropertyChanged(nameof(EmailBorderColor));
            OnPropertyChanged(nameof(HeightBorderColor));
            OnPropertyChanged(nameof(WeightBorderColor));
            OnPropertyChanged(nameof(BodyFatBorderColor));
            OnPropertyChanged(nameof(MembDurBorderColor));

            if (FirstNameBorderColor == Brushes.Red ||
                LastNameBorderColor == Brushes.Red || GenderBorderColor == Brushes.Red ||
                DateOfBirthBorderColor == Brushes.Red || AddressBorderColor == Brushes.Red ||
                PhoneNumberBorderColor == Brushes.Red || EmailBorderColor == Brushes.Red ||
                HeightBorderColor == Brushes.Red || WeightBorderColor == Brushes.Red ||
                BodyFatBorderColor == Brushes.Red || MembDurBorderColor == Brushes.Red)
            {
                MessageBox.Show("All the fields have to be filled accordingly!");
            }
            else
            {
                updatedClient.FirstName = _txtFirstName;
                updatedClient.LastName = _txtLastName;
                updatedClient.Gender = _cmbGender;
                updatedClient.DateOfBirth = _dpDateOfBirth;
                updatedClient.Address = _txtAddress;
                updatedClient.PhoneNumber = _txtPhoneNumber;
                updatedClient.Email = _txtEmail;
                updatedClient.Height = double.Parse(_txtHeight);
                updatedClient.Weight = double.Parse(_txtWeight);
                updatedClient.FatPercentage = int.Parse(_txtBodyFat);
                updatedClient.MembershipDuration = _cmbMembDur;

                Match MembDurNumber = Regex.Match(CmbMembDur, @"\d+");
                updatedClient.MembershipExpirationDate = updatedClient.DateOfRegistration.AddMonths(int.Parse(MembDurNumber.Value));

                updatedClient.AssignedTraining = Client.GetAssignedTraining(updatedClient);
                FileExplorer.UpdateMemberData(updatedClient);
            }
        }

    }
}
