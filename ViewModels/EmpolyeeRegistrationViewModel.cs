using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Service;
using LionsDen.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LionsDen.ViewModels
{
    class EmployeeRegistrationViewModel : BaseViewModel
    {
        public ICommand ReturnNavigateCommand { get; }
        public EmployeeRegistrationViewModel(NavigationStore navigationStore)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new ChooseMemberViewModel(navigationStore));
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
                _dpDateOfBirth = value;
                if (value != null)
                {
                    DateOfBirthBorderColor = Brushes.Yellow;
                }
                OnPropertyChanged(nameof(DpDateOfBirth));
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
        private string _txtEmail = "mail@qwe.ua";
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
        private string _cmbJobTitle;
        public string CmbJobTitle
        {
            get { return _cmbJobTitle; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    JobTitleBorderColor = Brushes.Yellow;
                }
                _cmbJobTitle = value?.Split(':').LastOrDefault()?.Trim();
                if (value == "System.Windows.Controls.ComboBoxItem: Coach")
                {
                    SpecTrainingVisibility = Visibility.Visible;
                }
                else
                {
                    SpecTrainingVisibility = Visibility.Collapsed;
                }
                OnPropertyChanged(nameof(CmbJobTitle));
                OnPropertyChanged(nameof(JobTitleBorderColor));
                OnPropertyChanged(nameof(SpecTrainingVisibility));
            }
        }
        private string _cmbYearsOfExp;

        public string CmbYearsOfExp
        {
            get { return _cmbYearsOfExp; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    YearsOfExpBorderColor = Brushes.Yellow;
                }
                _cmbYearsOfExp = value?.Split(':').LastOrDefault()?.Trim();
                OnPropertyChanged(nameof(CmbYearsOfExp));
                OnPropertyChanged(nameof(YearsOfExpBorderColor));
            }
        }
        private string _cmbWorkDays;
        public string CmbWorkDays
        {
            get { return _cmbWorkDays; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    WorkDaysBorderColor = Brushes.Yellow;
                }
                _cmbWorkDays = value?.Split(':').LastOrDefault()?.Trim();
                OnPropertyChanged(nameof(CmbWorkDays));
                OnPropertyChanged(nameof(WorkDaysBorderColor));
            }
        }

        private string _cmbSpecTraining;
        public string CmbSpecTraining
        {
            get { return _cmbSpecTraining; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    SpecTrainingBorderColor = Brushes.Yellow;
                }
                _cmbSpecTraining = value?.Split(':').LastOrDefault()?.Trim();
                OnPropertyChanged(nameof(CmbWorkDays));
                OnPropertyChanged(nameof(SpecTrainingBorderColor));
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
        public Brush JobTitleBorderColor { get; set; } = Brushes.Yellow;
        public Brush YearsOfExpBorderColor { get; set; } = Brushes.Yellow;
        public Brush WorkDaysBorderColor { get; set; } = Brushes.Yellow;
        public Brush SpecTrainingBorderColor { get; set; } = Brushes.Yellow;

        public Visibility TaxIdVisibility { get; set; } = Visibility.Collapsed;
        public Visibility PhoneNumberVisibility { get; set; } = Visibility.Collapsed;
        public Visibility EmailVisibility { get; set; } = Visibility.Collapsed;
        public Visibility SpecTrainingVisibility { get; set; } = Visibility.Collapsed;

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
            DpDateOfBirth = null;
            TxtAddress = "";
            TxtPhoneNumber = "";
            TxtEmail = "";
            CmbJobTitle = null;
            CmbYearsOfExp = null;
            CmbWorkDays = null;
            CmbSpecTraining = null;

            OnPropertyChanged(nameof(TxtTaxId));
            OnPropertyChanged(nameof(TxtFirstName));
            OnPropertyChanged(nameof(TxtLastName));
            OnPropertyChanged(nameof(CmbGender));
            OnPropertyChanged(nameof(DpDateOfBirth));
            OnPropertyChanged(nameof(TxtAddress));
            OnPropertyChanged(nameof(TxtPhoneNumber));
            OnPropertyChanged(nameof(TxtEmail));
            OnPropertyChanged(nameof(CmbJobTitle));
            OnPropertyChanged(nameof(CmbYearsOfExp));
            OnPropertyChanged(nameof(CmbWorkDays));
            OnPropertyChanged(nameof(CmbSpecTraining));

            TaxIdVisibility = Visibility.Collapsed;
            PhoneNumberVisibility = Visibility.Collapsed;
            EmailVisibility = Visibility.Collapsed;

            OnPropertyChanged(nameof(TaxIdVisibility));
            OnPropertyChanged(nameof(PhoneNumberVisibility));
            OnPropertyChanged(nameof(EmailVisibility));

            TaxIdBorderColor = Brushes.Yellow;
            PhoneNumberBorderColor = Brushes.Yellow;
            EmailBorderColor = Brushes.Yellow;

            OnPropertyChanged(nameof(TaxIdBorderColor));
            OnPropertyChanged(nameof(PhoneNumberBorderColor));
            OnPropertyChanged(nameof(EmailBorderColor));
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
            if (string.IsNullOrEmpty(CmbJobTitle))
            {
                JobTitleBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(CmbYearsOfExp))
            {
                YearsOfExpBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(CmbWorkDays))
            {
                WorkDaysBorderColor = Brushes.Red;
            }
            if (string.IsNullOrEmpty(CmbSpecTraining))
            {
                SpecTrainingBorderColor = Brushes.Red;
            }

            OnPropertyChanged(nameof(TaxIdBorderColor));
            OnPropertyChanged(nameof(FirstNameBorderColor));
            OnPropertyChanged(nameof(LastNameBorderColor));
            OnPropertyChanged(nameof(GenderBorderColor));
            OnPropertyChanged(nameof(DateOfBirthBorderColor));
            OnPropertyChanged(nameof(AddressBorderColor));
            OnPropertyChanged(nameof(PhoneNumberBorderColor));
            OnPropertyChanged(nameof(EmailBorderColor));
            OnPropertyChanged(nameof(JobTitleBorderColor));
            OnPropertyChanged(nameof(YearsOfExpBorderColor));
            OnPropertyChanged(nameof(WorkDaysBorderColor));
            OnPropertyChanged(nameof(SpecTrainingBorderColor));

            if (TaxIdBorderColor == Brushes.Red || FirstNameBorderColor == Brushes.Red ||
                LastNameBorderColor == Brushes.Red || GenderBorderColor == Brushes.Red ||
                DateOfBirthBorderColor == Brushes.Red || AddressBorderColor == Brushes.Red ||
                PhoneNumberBorderColor == Brushes.Red || EmailBorderColor == Brushes.Red ||
                JobTitleBorderColor == Brushes.Red || YearsOfExpBorderColor == Brushes.Red ||
                WorkDaysBorderColor == Brushes.Red || (SpecTrainingVisibility == Visibility.Visible && SpecTrainingBorderColor == Brushes.Red))
            {
                    MessageBox.Show("All the fields have to be filled accordingly!");
            }
            else
            {
                Employee registratedEmployee = new Employee();

                registratedEmployee.TaxId = TxtTaxId;
                registratedEmployee.FirstName = TxtFirstName;
                registratedEmployee.LastName = TxtLastName;
                registratedEmployee.Gender = CmbGender;
                registratedEmployee.DateOfBirth = DpDateOfBirth;
                registratedEmployee.Address = TxtAddress;
                registratedEmployee.PhoneNumber = TxtPhoneNumber;
                registratedEmployee.Email = TxtEmail;
                registratedEmployee.JobTitle = CmbJobTitle;

                Match yearsOfExpNumber = Regex.Match(CmbYearsOfExp, @"\d+");
                registratedEmployee.YearsOfExperience = CmbYearsOfExp;
                int intYearsOfExp = int.Parse(yearsOfExpNumber.Value);

                registratedEmployee.WorkDays = CmbWorkDays;

                Match WorkDaysNumber = Regex.Match(CmbWorkDays, @"\d+");
                int intWorkDays = int.Parse(WorkDaysNumber.Value);
                registratedEmployee.HourlySalary = Employee.GetHourlySalary(CmbJobTitle, intYearsOfExp, intWorkDays);

                if (registratedEmployee.JobTitle == "Coach")
                {
                    Coach registratedCoach = Coach.Parse(registratedEmployee);
                    registratedCoach.SpecializedTraining = CmbSpecTraining;
                    if (FileExplorer.RegistrateMemberSuccessfully(registratedCoach))
                    {
                        MemberStore.CoachList.Add(registratedCoach);
                        ExecuteCleanAllCommand(parameter);
                    }
                }
                else
                {
                    if(FileExplorer.RegistrateMemberSuccessfully(registratedEmployee))
                    {
                        MemberStore.EmployeeList.Add(registratedEmployee);
                        ExecuteCleanAllCommand(parameter);
                    }
                }
            }
        }
    }
}
