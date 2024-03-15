namespace NotWordlev2.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void OnSignInBtnClicked(object sender, EventArgs e)
    {
		string username = UserName.Text;
		string password = Password.Text;

		bool isAuthenticated = LoginFacade.Instance.Authenticate(username, password);

		if(isAuthenticated)
		{
			DisplayAlert("Success", "Sign in succeeded!", "OK");
		}
		else
		{
            DisplayAlert("Error", "Sign in failed!", "OK");
        }
    }

    private async void OnBackToMainClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}