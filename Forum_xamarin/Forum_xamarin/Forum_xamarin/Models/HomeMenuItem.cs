using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_xamarin.Models
{
    public enum MenuItemType
    {
        Browse,
        Categorie,
        Poser_question,
        Mon_compte,
        Inscription,
        Connexion,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
