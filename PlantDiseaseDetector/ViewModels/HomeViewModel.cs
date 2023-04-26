using System;
namespace PlantDiseaseDetector.ViewModels
{
	public partial class HomeViewModel : BaseViewModel
	{

        [RelayCommand]
        async void FromFiles()=>TakePhoto(true);

        [RelayCommand]
        async void FromCamera() => TakePhoto();

        [RelayCommand]
        void NavToInfoPage()
        {
            IsBusy = true;
            ShowToast();
            Shell.Current.GoToAsync(nameof(InformationView));
            //await Shell.Current.Navigation.PushAsync(new HomeView());
            //Shell.Current.Navigation.PushAsync(new HomeView());
            IsBusy = false;

        }
        [ObservableProperty]
        public string localFilePath = "maize.png";


        [ObservableProperty]
        public bool uploadable = false;

        [RelayCommand]
        async void Upload()
        {
            IsBusy = true;
            await Task.Delay(1000);
            await Shell.Current.GoToAsync(nameof(ResultsView));
            IsBusy = false;
        }

        async void TakePhoto(bool fromFiles = false)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo;
                if (fromFiles)
                    photo = await MediaPicker.Default.PickPhotoAsync();
                else photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    LocalFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }
                Uploadable = !LocalFilePath.Equals("maize.png");
            }
            else
            {
                ShowToast();
            }
        }
    }
}

