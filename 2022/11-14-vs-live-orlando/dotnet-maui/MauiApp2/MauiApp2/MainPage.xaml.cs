namespace MauiApp2;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	string display = "Click me";
	public string Display
	{
		get => display; 
		set
		{
			display = value;
			OnPropertyChanged();
		}
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{

		if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
		{
			DisplayAlert("Offline", "You have no internet", "OK");
			return;
		}
		count++;




		if (count == 1)
            Display = $"Clicked {count} time";
		else
            Display = $"Clicked {count} times";

		SemanticScreenReader.Announce(Display);
	}
}

