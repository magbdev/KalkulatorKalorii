using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalkulator_Kalorii.DAL;
using Kalkulator_Kalorii.Models;

namespace Kalkulator_Kalorii.BusinessLayout
{
    public class ExerciseBL
    {
        public List<Exercise> GetExerciseList()
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            return DAL_calculator.GetListExercise();
        }
        public void CreateExercise(Exercise exercise)
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            DAL_calculator.ExerciseCreate(exercise);
        }
        public void EditExercise(int id,string name, int calories)
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            DAL_calculator.ExerciseEdit(id, name, calories);
        }
        public void DeleteExercise(Exercise exercise)
        {
            DAL_Calculator DAL_calculator = new DAL_Calculator();
            DAL_calculator.ExerciseDelete(exercise);
        }
    }
}