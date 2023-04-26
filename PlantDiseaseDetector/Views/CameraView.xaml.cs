namespace PlantDiseaseDetector.Views;

public partial class CameraView : ContentPage
{
	public CameraView()
	{
		InitializeComponent();
		BindingContext = new CameraViewModel();
	}
}
