using MauiApp6.Helper;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MauiApp6.VeiwModels
{
    public class SignUpViewModel : ViewModelBase
    {
        #region Properties
        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private string? _password;
        private string? _mobile;
        private bool _entryAsPassword;
        private string? _passwordIconCode;

        public string FirstName
        {
            get => _firstName!;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public string LastName
        {
            get => _lastName!;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public string UserEmail
        {
            get => _email!;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public string UserPassword
        {
            get => _password!;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public string Mobile
        {
            get => _mobile!;
            set
            {
                if (_mobile != value)
                {
                    _mobile = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public bool EntryAsPassword
        {
            get => _entryAsPassword;
            set
            {
                if (_entryAsPassword != value)
                {
                    _entryAsPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PasswordIconCode
        {
            get => _passwordIconCode!;
            set
            {
                if (_passwordIconCode != value)
                {
                    _passwordIconCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowPasswordCommand { get; }
        public ICommand SignUpCommand { get; }
        #endregion

        public SignUpViewModel()
        {
            EntryAsPassword = true;
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
            ShowPasswordCommand = new Command(TogglePasswordButton);
            SignUpCommand = new Command(SignUp, Validate);
        }

        private void TogglePasswordButton()
        {
            EntryAsPassword = !EntryAsPassword;
            PasswordIconCode = EntryAsPassword
                ? FontHelper.CLOSED_EYE_ICON
                : FontHelper.OPEN_EYE_ICON;
        }

        private bool Validate()
        {
            var fnameOK = !string.IsNullOrEmpty(FirstName);
            var lnameOK = !string.IsNullOrEmpty(LastName);
            var emailOK = !string.IsNullOrEmpty(UserEmail) &&
                          Regex.IsMatch(UserEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            var passOK = !string.IsNullOrEmpty(UserPassword) && UserPassword.Length > 5;
            var mobileOK = !string.IsNullOrEmpty(Mobile) &&
                           Mobile.Length == 10 &&
                           Mobile.All(char.IsDigit);

            return fnameOK && lnameOK && emailOK && passOK && mobileOK;
        }

        private async void SignUp()
        {
            await Application.Current!.Windows[0].Page!.DisplayAlert("Sign Up", "SignUp new user", "OK");
            //Register user into DB
            //Save User to Current User
            //Go to Main Page
        }
    }
}
