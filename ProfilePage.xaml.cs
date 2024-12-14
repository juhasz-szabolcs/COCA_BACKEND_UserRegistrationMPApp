
namespace UserRegistrationMPApp
{

    public partial class ProfilePage : ContentPage
    {
        private string userEmail;

        public ProfilePage(string email)
        {
            InitializeComponent();
            userEmail = email;
            LoadProfile();
        }

        public ProfilePage(User data)
        {
            InitializeComponent();
            userEmail = data.Email;
            LoadProfile();
        }

        private async void LoadProfile()
        {
            var user = await ApiService.GetUserProfile(userEmail);
            if (user != null)
            {
                UserNameEntry.Text = user.UserName;
                EmailEntry.Text = user.Email;
                FirstNameEntry.Text = user.FirstName;
                LastNameEntry.Text = user.LastName;
            }
        }

        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                UserName = UserNameEntry.Text,
                Email = EmailEntry.Text,
                FirstName = FirstNameEntry.Text,
                LastName = LastNameEntry.Text
            };

            if (await ApiService.UpdateProfile(user))
            {
                await DisplayAlert("Success", "Profile updated", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Failed to update profile", "OK");
            }
        }
    }


}

