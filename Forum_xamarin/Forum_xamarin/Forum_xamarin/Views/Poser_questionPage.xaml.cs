using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forum_xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Poser_questionPage : ContentPage
    {

        public Poser_questionPage()
        {
            InitializeComponent();
        }

        async void Bouton_envoyer(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", Item);
            //await Navigation.PopModalAsync();
        }

        async void Bouton_annuler(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}