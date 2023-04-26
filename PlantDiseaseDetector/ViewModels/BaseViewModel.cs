namespace PlantDiseaseDetector.ViewModels
{
	public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        public bool IsNotBusy => !IsBusy;
        [RelayCommand]
        public async void ShowToast(string message="")
        {

            IsBusy = true;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = message.Equals("")? "Toast Message" : message;
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
            IsBusy = false;
        }
    }
}

