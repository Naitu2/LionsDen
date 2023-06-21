using LionsDen.Commands;
using LionsDen.Models;
using LionsDen.Service;
using LionsDen.Stores;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LionsDen.ViewModels
{
    class EmployeeUpdateViewModel : BaseViewModel
    {
        private Employee updatedEmployee;
        private Coach updatedCoach;
        private bool _isCoach;
        public ICommand ReturnNavigateCommand { get; }
        private ICommand _deleteEmployeeCommand;
        public ICommand DeleteEmployeeCommand
        {
            get { return _deleteEmployeeCommand ?? (_deleteEmployeeCommand = new RelayCommand(ExecuteDeleteEmployeeCommand)); }
        }
        private ICommand _updateEmployeeCommand;
        public ICommand UpdateEmployeeCommand
        {
            get { return _updateEmployeeCommand ?? (_updateEmployeeCommand = new RelayCommand(ExecuteUpdateEmployeeCommand)); }
        }
        public EmployeeUpdateViewModel(NavigationStore navigationStore, Employee clickedEmployee)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new EmployeeInformationViewModel(navigationStore));

            _txtAddress = clickedEmployee.Address;
            _txtPhoneNumber = clickedEmployee.PhoneNumber;
            _txtEmail = clickedEmployee.Email;
            _cmbYearsOfExp = clickedEmployee.YearsOfExperience;
            _cmbWorkDays = clickedEmployee.WorkDays;

            updatedEmployee = clickedEmployee;
            _isCoach = false;
        }
        public EmployeeUpdateViewModel(NavigationStore navigationStore, Coach clickedCoach)
        {
            ReturnNavigateCommand = new NavigateCommand<BaseViewModel>(navigationStore, () => new EmployeeInformationViewModel(navigationStore));

            _txtAddress = clickedCoach.Address;
            _txtPhoneNumber = clickedCoach.PhoneNumber;
            _txtEmail = clickedCoach.Email;
            _cmbYearsOfExp = clickedCoach.YearsOfExperience;
            _cmbWorkDays = clickedCoach.WorkDays;
            _cmbSpecTraining = clickedCoach.SpecializedTraining;

            updatedCoach = clickedCoach;
            _isCoach = true;
            SpecTrainingVisibility = Visibility.Visible;
        }

        public ObservableCollection<string> YearsOfExpOptions { get; } = new ObservableCollection<string>
        {
         "1 year or less",
         "3 years",
         "5 years",
         "10 years"
        };
        public ObservableCollection<string> WorkDaysOptions { get; } = new ObservableCollection<string>
        {
        "1 day",
        "2 days",
        "3 days",
        "4 days",
        "5 days",
        "6 days",
        "7 days"
        };
        public ObservableCollection<string> SpecTrainingOptions { get; } = new ObservableCollection<string>
        {
        "Cardio",
        "Personal",
        "Strength",
        "Yoga"
        };
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

        public Brush AddressBorderColor { get; set; } = Brushes.Yellow;
        public Brush PhoneNumberBorderColor { get; set; } = Brushes.Yellow;
        public Brush EmailBorderColor { get; set; } = Brushes.Yellow;
        public Brush YearsOfExpBorderColor { get; set; } = Brushes.Yellow;
        public Brush WorkDaysBorderColor { get; set; } = Brushes.Yellow;
        public Brush SpecTrainingBorderColor { get; set; } = Brushes.Yellow;

        public Visibility PhoneNumberVisibility { get; set; } = Visibility.Collapsed;
        public Visibility EmailVisibility { get; set; } = Visibility.Collapsed;
        public Visibility SpecTrainingVisibility { get; set; } = Visibility.Collapsed;

        private void ExecuteDeleteEmployeeCommand(object parameter)
        {
            if (_isCoach)
            {
                MemberStore.CoachList.Remove(updatedCoach);
                FileExplorer.DeleteMemberData(updatedCoach);
            }
            else
            {
                MemberStore.EmployeeList.Remove(updatedEmployee);
                FileExplorer.DeleteMemberData(updatedEmployee);
            }
            ReturnNavigateCommand.Execute(parameter);
        }
        private void ExecuteUpdateEmployeeCommand(object parameter)
        {
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

            OnPropertyChanged(nameof(AddressBorderColor));
            OnPropertyChanged(nameof(PhoneNumberBorderColor));
            OnPropertyChanged(nameof(EmailBorderColor));
           
            if (AddressBorderColor == Brushes.Red ||
                PhoneNumberBorderColor == Brushes.Red || EmailBorderColor == Brushes.Red)
            {
                MessageBox.Show("All the fields have to be filled accordingly!");
            }
            else
            {
                if (_isCoach)
                {
                    updatedCoach.Address = TxtAddress;
                    updatedCoach.PhoneNumber = TxtPhoneNumber;
                    updatedCoach.Email = TxtEmail;

                    updatedCoach.YearsOfExperience = CmbYearsOfExp;
                    Match yearsOfExpNumber = Regex.Match(CmbYearsOfExp, @"\d+");
                    int intYearsOfExp = int.Parse(yearsOfExpNumber.Value);

                    updatedCoach.WorkDays = CmbWorkDays;

                    Match WorkDaysNumber = Regex.Match(CmbWorkDays, @"\d+");
                    int intWorkDays = int.Parse(WorkDaysNumber.Value);
                    updatedCoach.HourlySalary = Employee.GetHourlySalary(updatedCoach.JobTitle, intYearsOfExp, intWorkDays);

                    updatedCoach.SpecializedTraining = CmbSpecTraining;
                    FileExplorer.UpdateMemberData(updatedCoach, 'u');
                }
                else
                {
                    updatedEmployee.Address = TxtAddress;
                    updatedEmployee.PhoneNumber = TxtPhoneNumber;
                    updatedEmployee.Email = TxtEmail;

                    updatedEmployee.YearsOfExperience = CmbYearsOfExp;
                    Match yearsOfExpNumber = Regex.Match(CmbYearsOfExp, @"\d+");
                    int intYearsOfExp = int.Parse(yearsOfExpNumber.Value);

                    updatedEmployee.WorkDays = CmbWorkDays;

                    Match WorkDaysNumber = Regex.Match(CmbWorkDays, @"\d+");
                    int intWorkDays = int.Parse(WorkDaysNumber.Value);
                    updatedEmployee.HourlySalary = Employee.GetHourlySalary(updatedEmployee.JobTitle, intYearsOfExp, intWorkDays);

                    FileExplorer.UpdateMemberData(updatedEmployee, 'u');
                }
            }
        }
    }
}
