using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Forum_xamarin.Models;
using Forum_xamarin.Views;
using Forum_xamarin.ViewModels;

namespace Forum_xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CategoriePage : ContentPage
    {
        CategorieViewModel viewModel;

        public CategoriePage()
        {
            InitializeComponent();

            BindingContext = this.viewModel = new CategorieViewModel();
        }

        async void OnCategorieSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var categorie = args.SelectedItem as Categorie;
            if (categorie == null)
                return;

            await Navigation.PushAsync(new CategorieDetailPage(new CategorieDetailViewModel(categorie)));

            // Manually deselect item.
            CategorieListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categories.Count == 0)
                viewModel.LoadCategoriesCommand.Execute(null);
        }
    }
}