using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forum_xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ConnexionPage : ContentPage
    {
        public ConnexionPage()
        {
            InitializeComponent();
        }

        //Bouton connexion
        async void Open_connexion(object sender, EventArgs e)
        {
            string Text = Email.Text;
            label_connexion.Text= "Bonjour " + Text;
        }

        //Bouton s'inscrire
        async void Open_inscriptionPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new InscriptionPage()));
        }
    }
}