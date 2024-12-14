

namespace UserRegistrationMPApp
{

    public partial class RegisterPage : ContentPage
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public RegisterPage()
        {
            InitializeComponent();
        }

        //    private async void OnRegisterClicked(object sender, EventArgs e)
        //    {
        //        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        //        {
        //            await DisplayAlert("Error", "Passwords do not match", "OK");
        //            return;
        //        }

        //        var user = new User
        //        {
        //            UserName = UserNameEntry.Text,
        //            Email = EmailEntry.Text,
        //            Password = PasswordEntry.Text,
        //            FirstName = FirstNameEntry.Text,
        //            LastName = LastNameEntry.Text
        //        };

        //        if (await ApiService.Register(user))
        //        {
        //            await DisplayAlert("Success", "Account created successfully", "OK");
        //            await Navigation.PopAsync();
        //        }
        //        else
        //        {
        //            await DisplayAlert("Error", "Registration failed", "OK");
        //        }
        //    }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            var user = new User
            {
                UserName = UserNameEntry.Text,
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text,
                FirstName = FirstNameEntry.Text,
                LastName = LastNameEntry.Text
            };

            if (await _userRepository.RegisterUserAsync(user))
            {
                await DisplayAlert("Success", "Account created successfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "User with this email already exists", "OK");
            }
        }
    }

}
