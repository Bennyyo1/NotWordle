using NotWordlev2.ViewModels;

namespace NotWordlev2.Views;

public partial class LosePage : ContentPage
{
	public LosePage()
	{
		InitializeComponent();
        BindingContext = GameViewModel.Instance;
    }

    private async void OnBackToMain(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}