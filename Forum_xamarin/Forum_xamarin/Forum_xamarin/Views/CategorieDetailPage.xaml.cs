using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Forum_xamarin.Models;
using Forum_xamarin.ViewModels;

namespace Forum_xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CategorieDetailPage : ContentPage
    {
        CategorieDetailViewModel viewModel;

        public CategorieDetailPage(CategorieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CategorieDetailPage()
        {
            InitializeComponent();

            var categorie = new Categorie
            {
                LibelleCategorie = "Item 1",
                //Text = "Item 1",
                //Description = "This is an item description."
            };

            viewModel = new CategorieDetailViewModel(categorie);
            BindingContext = viewModel;
        }
    }
}