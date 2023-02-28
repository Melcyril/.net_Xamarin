using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Forum_xamarin.Models;
using Forum_xamarin.Views;

namespace Forum_xamarin.ViewModels
{
    public class CategorieViewModel : BaseViewModel
    {
        public ObservableCollection<Categorie> Categories { get; set; }
        public Command LoadCategoriesCommand { get; set; }

        public CategorieViewModel()
        {
            Title = "Catégories";
            Categories = new ObservableCollection<Categorie>();
            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Categories.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadCategoriesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Categories.Clear();
                var ListeCategories = await DataStore.GetCategoriesAsync(true);
                foreach (var cat in ListeCategories)
                {
                    Categories.Add(cat);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}