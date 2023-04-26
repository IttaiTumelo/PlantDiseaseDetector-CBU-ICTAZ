namespace PlantDiseaseDetector.ViewModels
{
	public partial class MainViewModel : BaseViewModel
	{
  

        [RelayCommand]
		 void NavToAboutPage()
        {
            IsBusy = true;
            ShowToast();
             Shell.Current.GoToAsync(nameof(HomeView));
            //await Shell.Current.Navigation.PushAsync(new HomeView());
            //Shell.Current.Navigation.PushAsync(new HomeView());
            IsBusy = false;

        }

        [ObservableProperty]
        public ArticlePart articlePart = new ArticlePart()
        {
            Heading = "SMART PLANT DISEASE DETECTOR",
            Image = "",
            Paragraph = "Smart Plant Disease Detector is an app that helps you identify and treat plant diseases using your smartphone camera. Just snap a photo of the affected plant and the app will analyze it and provide you with a diagnosis and a recommendation. Whether you are a gardener, a farmer, or a plant lover, Smart Plant Disease Detector can help you keep your plants healthy and beautiful.",
            Subheading = ""
        };

    }
}

