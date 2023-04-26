namespace PlantDiseaseDetector;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
		Routing.RegisterRoute(nameof(CameraView), typeof(CameraView));
		Routing.RegisterRoute(nameof(InformationView), typeof(InformationView));
		Routing.RegisterRoute(nameof(ResultsView), typeof(ResultsView));
        MainPage = new AppShell();
	}
}

