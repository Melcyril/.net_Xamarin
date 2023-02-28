using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Forum_xamarin.ViewModels
{
    public class Poser_questionViewModel : BaseViewModel
    {
        public Poser_questionViewModel()
        {
            Title = "Poser une question ?";

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        //public ICommand OpenWebCommand { get; }
    }
}