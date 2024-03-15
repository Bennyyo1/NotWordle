using NotWordlev2.ViewModels;
using NotWordlev2.Views;

namespace NotWordlev2
{
    public partial class MainPage : ContentPage
    {
        //API ordlista X 
        //Singleton/facade? X 
        //make keyboardbuttons grayed out
        //statistics page
        //jämföra ord mot ordlista
        //keyboard support
        
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPlayBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());

            GameViewModel gameViewModelInstance = GameViewModel.Instance;
        }

        private async void OnLoginBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void OnWinBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WinPage());
        }

        private async void OnLoseBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LosePage());
        }
    }

}
