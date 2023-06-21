using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Service;
using LionsDen.Stores;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Validation = LionsDen.Service.Validation;

namespace LionsDen.ViewModels
{
    class ClientRegistrationViewModel : BaseViewModel
    {
        public ICommand ReturnNavigateCommand { get; }
        public ClientRegistrationViewModel(NavigationStore navigationStore)
        {
            ReturnNavigateCommand = new NavigateCommand<ChooseMemberViewModel>(navigationStore, () => new ChooseMemberViewModel(navigationStore));
        }

        private string _txtTaxId = "123456789";
        public string TxtTaxId
        {
            get { return _txtTaxId; }
            set
            {
                if (!Validation.IsValidTaxId(value))
                {
                    TaxIdVisibility = Visibility.Visible;
                    TaxIdBorderColor = Brushes.Red;
                }
                else
                {
                    TaxIdVisibility = Visibility.Collapsed;
                    TaxIdBorderColor = Brushes.Yellow;
                }
                _txtTaxId = value;
                OnPropertyChanged(nameof(TaxIdVisibility));
                OnPropertyChanged(nameof(TaxIdBorderColor));
            }
        }
        private string _txtFirstName = "Vitalik";
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
        private string _txtLastName = "Sadovski";
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
                _cmbGender = value?.Split(':').LastOrDefault()?.Trim();
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
        private string _txtAddress = "Kfar";
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

        private string _txtPhoneNumber = "0535553366";
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
        private string _txtEmail = "mail@qwe.ru";
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
        private string _txtHeight = "1";
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
        private string _txtWeight = "2";
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
        private string _txtBodyFat = "15";
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

        public Brush TaxIdBorderColor { get; set; } = Brushes.Yellow;
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


        public Visibility TaxIdVisibility { get; set; } = Visibility.Collapsed;
        public Visibility DateOfBirthVisibility { get; set; } = Visibility.Collapsed;
        public Visibility PhoneNumberVisibility { get; set; } = Visibility.Collapsed;
        public Visibility EmailVisibility { get; set; } = Visibility.Collapsed;
        public Visibility HeightVisibility { get; set; } = Visibility.Collapsed;
        public Visibility WeightVisibility { get; set; } = Visibility.Collapsed;
        public Visibility BodyFatVisibility { get; set; } = Visibility.Collapsed;

        private ICommand _cleanAllCommand;
        public ICommand CleanAllCommand
        {
            get { return _cleanAllCommand ?? (_cleanAllCommand = new RelayCommand(ExecuteCleanAllCommand)); }
        }
        private ICommand _registrateCommand;
        public ICommand RegistrateCommand
        {
            get { return _registrateCommand ?? (_registrateCommand = new RelayCommand(ExecuteRegistrateCommand)); }
        }
        private void ExecuteCleanAllCommand(object parameter)
        {
            TxtTaxId = "";
            TxtFirstName = "";
            TxtLastName = "";
            CmbGender = null;
            _dpDateOfBirth = null;
            TxtAddress = "";
            TxtPhoneNumber = "";
            TxtEmail = "";
            TxtHeight = "";
            TxtWeight = "";
            TxtBodyFat = "";
            CmbMembDur = null;

            OnPropertyChanged(nameof(TxtTaxId));
            OnPropertyChanged(nameof(TxtFirstName));
            OnPropertyChanged(nameof(TxtLastName));
            OnPropertyChanged(nameof(CmbGender));
            OnPropertyChanged(nameof(DpDateOfBirth));
            OnPropertyChanged(nameof(TxtAddress));
            OnPropertyChanged(nameof(TxtPhoneNumber));
            OnPropertyChanged(nameof(TxtEmail));
            OnPropertyChanged(nameof(TxtHeight));
            OnPropertyChanged(nameof(TxtWeight));
            OnPropertyChanged(nameof(TxtBodyFat));
            OnPropertyChanged(nameof(CmbMembDur));

            TaxIdVisibility = Visibility.Collapsed;
            PhoneNumberVisibility = Visibility.Collapsed;
            EmailVisibility = Visibility.Collapsed;
            HeightVisibility = Visibility.Collapsed;
            WeightVisibility = Visibility.Collapsed;
            BodyFatVisibility = Visibility.Collapsed;
            DateOfBirthVisibility = Visibility.Collapsed;

            OnPropertyChanged(nameof(TaxIdVisibility));
            OnPropertyChanged(nameof(PhoneNumberVisibility));
            OnPropertyChanged(nameof(EmailVisibility));
            OnPropertyChanged(nameof(HeightVisibility));
            OnPropertyChanged(nameof(WeightVisibility));
            OnPropertyChanged(nameof(BodyFatVisibility));
            OnPropertyChanged(nameof(DateOfBirthVisibility));

            TaxIdBorderColor = Brushes.Yellow;
            PhoneNumberBorderColor = Brushes.Yellow;
            EmailBorderColor = Brushes.Yellow;
            HeightBorderColor = Brushes.Yellow;
            WeightBorderColor = Brushes.Yellow;
            BodyFatBorderColor = Brushes.Yellow;
            DateOfBirthBorderColor = Brushes.Yellow;

            OnPropertyChanged(nameof(TaxIdBorderColor));
            OnPropertyChanged(nameof(PhoneNumberBorderColor));
            OnPropertyChanged(nameof(EmailBorderColor));
            OnPropertyChanged(nameof(HeightBorderColor));
            OnPropertyChanged(nameof(WeightBorderColor));
            OnPropertyChanged(nameof(BodyFatBorderColor));
            OnPropertyChanged(nameof(DateOfBirthBorderColor));
        }
        private void ExecuteRegistrateCommand(object parameter)
        {
            if (string.IsNullOrEmpty(TxtTaxId))
            {
                TaxIdBorderColor = Brushes.Red;
            }
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

            OnPropertyChanged(nameof(TaxIdBorderColor));
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

            if (TaxIdBorderColor == Brushes.Red || FirstNameBorderColor == Brushes.Red ||
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
                Client RegistratedClient = new Client();
                RegistratedClient.TaxId = TxtTaxId;
                RegistratedClient.FirstName = TxtFirstName;
                RegistratedClient.LastName = TxtLastName;
                RegistratedClient.Gender = CmbGender;
                RegistratedClient.DateOfBirth = DpDateOfBirth;
                RegistratedClient.Address = TxtAddress;
                RegistratedClient.PhoneNumber = TxtPhoneNumber;
                RegistratedClient.Email = TxtEmail;
                RegistratedClient.Height = double.Parse(TxtHeight);
                RegistratedClient.Weight = double.Parse(TxtWeight);
                RegistratedClient.FatPercentage = int.Parse(TxtBodyFat);

                RegistratedClient.MembershipDuration = CmbMembDur;
                Match MembDurNumber = Regex.Match(CmbMembDur, @"\d+");
                RegistratedClient.MembershipExpirationDate = DateTime.Now.AddMonths(int.Parse(MembDurNumber.Value));

                RegistratedClient.AssignedTraining = Client.GetAssignedTraining(RegistratedClient);
                if (FileExplorer.RegistrateMemberSuccessfully(RegistratedClient))
                {
                    MemberStore.ClientList.Add(RegistratedClient);
                    ExecuteCleanAllCommand(parameter);
                }
            }
        }
    }
}
