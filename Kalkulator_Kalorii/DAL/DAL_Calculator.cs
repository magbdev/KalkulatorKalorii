using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Kalkulator_Kalorii.Models;
using Kalkulator_Kalorii.HashPassword;


namespace Kalkulator_Kalorii.DAL
{
    public class DAL_Calculator : DbContext
    {
        public DAL_Calculator() : base("MyDataBase")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<LoginUser> LoginUsers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Tbl_Products");
            modelBuilder.Entity<Exercise>().ToTable("Tbl_Exercises");
            modelBuilder.Entity<LoginUser>().ToTable("Tbl_Accounts");
            base.OnModelCreating(modelBuilder);
        }

        //PRODUCTS
        public List<Product> GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = Products.ToList();
            return products;
        }

        public void ProductCreate(Product product)
        {
            Products.Add(product);
            SaveChanges();
        }
        public void ProductEdit(int id,string name,int calories,float protein,float carbs,float fats)
        {
            Product productEdit = Products.Find(id);
            if (productEdit != null)
            {
                productEdit.name = name;
                productEdit.calories = calories;
                productEdit.protein = protein;
                productEdit.carbs = carbs;
                productEdit.fats = fats;
                SaveChanges();
            }
        }
        public void ProductDelete(Product product)
        {
            Products.Remove(Products.Find(product.productID));
            SaveChanges();
        }


        //EXERCISES
        public List<Exercise> GetListExercise()
        {
            List<Exercise> exercises = new List<Exercise>();
            exercises = Exercises.ToList();
            return exercises;
        }
        public void ExerciseCreate(Exercise exercise)
        {
            Exercises.Add(exercise);
            SaveChanges();
        }
        public void ExerciseEdit(int id, string name, int calories)
        {
            Exercise exerciseEdit = Exercises.Find(id);
            if(exerciseEdit != null)
            {
                exerciseEdit.name = name;
                exerciseEdit.calories = calories;
                SaveChanges();
            }
        }
        public void ExerciseDelete(Exercise exercise)
        {
            Exercises.Remove(Exercises.Find(exercise.exerciseID));
            SaveChanges();
        }

        //LOGINUSERS
        public void UserAccountCreate(LoginUser loginUser)
        {
            Hashing hash = new Hashing();
            string psw = hash.GetMd5Hash(loginUser.password);
            loginUser.password = psw;
            string cpsw = hash.GetMd5Hash(loginUser.confirmPassword);
            loginUser.confirmPassword = cpsw;
            LoginUsers.Add(loginUser);
            SaveChanges();
        }
        public List<LoginUser> GetListAccount()
        {
            List<LoginUser> accountList = new List<LoginUser>();
            accountList = LoginUsers.ToList();
            return accountList;
        }
    }
}