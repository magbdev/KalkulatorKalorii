using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalkulator_Kalorii.ViewModels;
using Kalkulator_Kalorii.Models;
using Kalkulator_Kalorii.BusinessLayout;

namespace Kalkulator_Kalorii.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult ListProduct()
        {
            ProductBL productBL = new ProductBL();
            ProductListVM productListVM = new ProductListVM();
            productListVM.productVMlist = ProductList2ProductVMList(productBL.GetProductList());
            return View(productListVM);
        }

        private List<ProductVM> ProductList2ProductVMList(List<Product> productList)
        {
            List<ProductVM> productVMList = new List<ProductVM>();

            foreach (Product product in productList)
            {
                ProductVM productVM = new ProductVM();
                productVM.product = product;
                productVMList.Add(productVM);
            }


            return productVMList;
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductBL productBL = new ProductBL();
                productBL.CreateProduct(product);
                return RedirectToAction("ListProduct");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EditProduct(int id)
        {
            ProductBL productBL = new ProductBL();
            List<Product> productList = productBL.GetProductList();
            Product product = productList.Where(u => u.productID == id).Single();
            return View(product);
        }
        
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductBL productBL = new ProductBL();
                productBL.EditProduct(product.productID, product.name, product.calories, product.protein, product.carbs, product.fats);
                return RedirectToAction("ListProduct");
            }
            else
            {
                return View(product);
            }
        }
        public ActionResult DeleteProduct(Product product)
        {
            ProductBL productBL = new ProductBL();
            productBL.DeleteProduct(product);
            return RedirectToAction("ListProduct");
        }

        //
        public ActionResult ListExercise()
        {
            ExerciseBL exerciseBL = new ExerciseBL();
            ExerciseListVM exerciseListVM = new ExerciseListVM();
            exerciseListVM.exerciseVMList = ExerciseList2ExerciseVMList(exerciseBL.GetExerciseList());
            return View(exerciseListVM);
        }

        private List<ExerciseVM> ExerciseList2ExerciseVMList(List<Exercise> exerciseList)
        {
            List<ExerciseVM> exerciseVMList = new List<ExerciseVM>();

            foreach (Exercise exercise in exerciseList)
            {
                ExerciseVM exerciseVM = new ExerciseVM();
                exerciseVM.exerciseVM = exercise;
                exerciseVMList.Add(exerciseVM);
            }


            return exerciseVMList;
        }

        public ActionResult CreateExercise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExercise(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                ExerciseBL exerciseBL = new ExerciseBL();
                exerciseBL.CreateExercise(exercise);
                return RedirectToAction("ListExercise");
            }
            else
            {
                return View(exercise);
            }
        }

        public ActionResult EditExercise(int id)
        {
            ExerciseBL exerciseBL = new ExerciseBL();
            List<Exercise> exerciseList = exerciseBL.GetExerciseList();
            Exercise exercise = exerciseList.Where(u => u.exerciseID == id).Single();
            return View(exercise);
        }

        [HttpPost]
        public ActionResult EditExercise(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                ExerciseBL exerciseBL = new ExerciseBL();
                exerciseBL.EditExercise(exercise.exerciseID, exercise.name, exercise.calories);
                return RedirectToAction("ListExercise");
            }
            else
            {
                return View(exercise);
            }
        }
        public ActionResult DeleteExercise(Exercise exercise)
        {
            ExerciseBL exerciseBL = new ExerciseBL();
            exerciseBL.DeleteExercise(exercise);
            return RedirectToAction("ListExercise");
        }
    }
}