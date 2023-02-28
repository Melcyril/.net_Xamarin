using System;

using Forum_xamarin.Models;

namespace Forum_xamarin.ViewModels
{
    public class CategorieDetailViewModel : BaseViewModel
    {
        public Categorie Categorie { get; set; }
        public CategorieDetailViewModel(Categorie categorie = null)
        {
            Title = categorie?.LibelleCategorie;
            Categorie = categorie;
        }

       
    }
}
