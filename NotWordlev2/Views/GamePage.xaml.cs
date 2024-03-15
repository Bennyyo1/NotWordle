using NotWordlev2.ViewModels;

namespace NotWordlev2;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
        BindingContext = GameViewModel.Instance;
		
        
    }


}