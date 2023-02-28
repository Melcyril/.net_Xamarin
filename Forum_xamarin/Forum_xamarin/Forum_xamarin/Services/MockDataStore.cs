using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum_xamarin.Models;

namespace Forum_xamarin.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        List<Categorie> Categories;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },                
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        
        // Catégorie
        public async Task<Categorie> GetCategorieAsync(string id)
        {
            return await Task.FromResult(Categories.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Categorie>> GetCategoriesAsync(bool forceRefresh = false)
        {            
            Categories = new List<Categorie>();
            var listeCategories = new List<Categorie>
            {
                new Categorie { Id = Guid.NewGuid().ToString(), LibelleCategorie = "Html/Css"},
                new Categorie { Id = Guid.NewGuid().ToString(), LibelleCategorie = "Asp.Net"},
                new Categorie { Id = Guid.NewGuid().ToString(), LibelleCategorie = "Xamarin"},
            };
            foreach (var item in listeCategories)
            {
                Categories.Add(item);
            }
            return await Task.FromResult(Categories);
        }
        
    }
}