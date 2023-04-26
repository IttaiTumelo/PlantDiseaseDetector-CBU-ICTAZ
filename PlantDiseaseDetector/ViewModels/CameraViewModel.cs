namespace PlantDiseaseDetector.ViewModels
{
	public partial class CameraViewModel : BaseViewModel
	{
        [RelayCommand]
        async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
            else
            {
                ShowToast();
            }
        }

 

        [RelayCommand]
        async void Alert()
        {
            //await DisplayAlert("Alert", "You have been alerted", "OK");
        }


    }
}

