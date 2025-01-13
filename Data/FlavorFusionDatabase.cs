using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlavorFusion.Models;

namespace FlavorFusion.Data
{
    public class FlavorFusionDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public FlavorFusionDatabase(string dbPath)
        {
            // Inițializează conexiunea la baza de date
            _database = new SQLiteAsyncConnection(dbPath);

            // Creează tabelele dacă nu există
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<Recipe>().Wait();
        }

        // ------------------ CRUD pentru User ------------------

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(u => u.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        // ------------------ CRUD pentru Category ------------------

        public Task<List<Category>> GetCategoriesAsync()
        {
            return _database.Table<Category>().ToListAsync();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return _database.Table<Category>()
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCategoryAsync(Category category)
        {
            if (category.Id != 0)
            {
                return _database.UpdateAsync(category);
            }
            else
            {
                return _database.InsertAsync(category);
            }
        }

        public Task<int> DeleteCategoryAsync(Category category)
        {
            return _database.DeleteAsync(category);
        }

        // ------------------ CRUD pentru Recipe ------------------

        public Task<List<Recipe>> GetRecipesAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }

        public Task<Recipe> GetRecipeAsync(int id)
        {
            return _database.Table<Recipe>()
                            .Where(r => r.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            if (recipe.Id != 0)
            {
                return _database.UpdateAsync(recipe);
            }
            else
            {
                return _database.InsertAsync(recipe);
            }
        }

        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return _database.DeleteAsync(recipe);
        }
    }
}
