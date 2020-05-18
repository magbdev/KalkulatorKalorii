using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalkulator_Kalorii.DAL;
using Kalkulator_Kalorii.Models;

namespace Kalkulator_Kalorii.BusinessLayout
{
    public class ProductBL
    {
        public List<Product> GetProductList()
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            return DAL_calculator.GetListProduct();
        }

        public void CreateProduct(Product product)
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            DAL_calculator.ProductCreate(product);
        }

        public void EditProduct(int id, string name, int calories, float protein, float carbs, float fats)
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            DAL_calculator.ProductEdit(id,name,calories,protein,carbs,fats);
        }
        public void DeleteProduct(Product product)
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            DAL_calculator.ProductDelete(product);
        }
    }
}