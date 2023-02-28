using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Forum_xamarin.ViewModels
{
    public class ConnexionViewModel : BaseViewModel
    {
        public ConnexionViewModel()
        {
            Title = "Connexion";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}