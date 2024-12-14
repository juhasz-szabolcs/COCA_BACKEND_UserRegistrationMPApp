
namespace UserRegistrationMPApp
{
    public partial class LoginPage : ContentPage
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public LoginPage()
        {
            InitializeComponent();
        }

        //private async void OnLoginClicked(object sender, EventArgs e)
        //{
        //    var email = EmailEntry.Text;
        //    var password = PasswordEntry.Text;

        //    if (await ApiService.Login(email, password))
        //    {
        //        await Navigation.PushAsync(new ProfilePage(email));
        //    }
        //    else
        //    {
        //        await DisplayAlert("Error", "Invalid login credentials", "OK");
        //    }
        //}

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null && user.Password == password)
            {
                await DisplayAlert("Success", "Login successful", "OK");
                // Navigálj a következő oldalra
                await Navigation.PushAsync(new ProfilePage(user));
            }
            else
            {
                await DisplayAlert("Error", "Invalid email or password", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }

}