using System;
using NUnit.Framework;

namespace Exercises.Chapter3
{
   // 1. Write a console app that calculates a user's Body-Mass Index:
   //   - prompt the user for her height in metres and weight in kg
   //   - calculate the BMI as weight/height^2
   //   - output a message: underweight(bmi<18.5), overweight(bmi>=25) or healthy weight
   // 2. Structure your code so that structure it so that pure and impure parts are separate
   // 3. Unit test the pure parts
   // 4. Unit test the impure parts using the HOF-based approach

   public static class Bmi
   {
      private static Func<int> GetHeight = () =>
      {
         Console.WriteLine("Enter height in metres");
         return int.Parse(Console.ReadLine() ?? "0");
      };

      private static Func<int> GetWeight = () =>
      {
         Console.WriteLine("Enter weight in kg");
         return int.Parse(Console.ReadLine() ?? "0");
      };

      private static Func<double> CalcBmi(Func<int> height, Func<int> weight) =>
         () => weight() / height() ^ 2;

      private static Func<int> AssessBmi(Func<double> bmi) =>
         () => {
            var value = bmi();
            if (value < 18.5)
               return -1;
            if (value >= 25)
               return 1;
            else
               return 0;
         };

      private static Action ShowBmiResult(Func<int> bmiAssessment) => () =>
      {
         var value = bmiAssessment();
         if (value < 0)
         {
            Console.WriteLine("Underweight");
            return;
         }
         else if (value > 1)
         {
            Console.WriteLine("Overweight");
            return;
         }
         else
         {
            Console.WriteLine("Healthy weight");
            return;
         }
      };

      [Test]
      public static void TestBmi()
      {
         ShowBmiResult(AssessBmi(CalcBmi(() => 1, ()=>222)))();
      }
   }
}
