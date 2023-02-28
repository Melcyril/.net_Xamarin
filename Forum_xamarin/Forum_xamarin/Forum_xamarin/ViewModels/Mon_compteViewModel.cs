using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Forum_xamarin.ViewModels
{
    public class Mon_compteViewModel : BaseViewModel
    {
        public Mon_compteViewModel()
        {
            Title = "Mon compte";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}