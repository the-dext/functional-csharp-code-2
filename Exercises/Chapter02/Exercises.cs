using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Exercises.Chapter2
{
   static class Exercises
   {
      // 1. Write a function that negates a given predicate: whenvever the given predicate
      // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
      static bool Negate(Func<bool> predicate) =>
         !predicate();
      
      [Test]
      public static void InvertPredicate()
      {
         Assert.IsFalse(Negate(() => 5 == 5));
         Assert.IsTrue(Negate(() => 5 == 6));
      }

      private static int partitionCalls = 0;
      // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
      // rather than sorting it in place).
      static void QuickSortInPlace(List<int> input) => QuickSortInPlace(input, 0, input.Count-1);

      static void QuickSortInPlace(List<int> input, int start, int end)
      {
         if (end <= start)
            return;

         var pivot = PartitionInPlace(input, start, end);
         QuickSortInPlace(input, start, pivot-1);
         QuickSortInPlace(input, pivot+1, end);
      }

      static List<int> QuickSortOutOfPlace(List<int> array)
      {
         List<int> newList = array.Select(x => x).ToList();  
         QuickSortInPlace(newList, 0, array.Count - 1);
         return newList;
      }
      
      static int PartitionInPlace(List<int> array, int start, int end)
      {
         partitionCalls++;
         int tmp;
         int pivot = array[end]; // always value of last element
         int i = start - 1; // starts one place behind first element
         
         // move values less than the pivot to the left
         for (int j = start; j <= end -1; j++)
         {
            if (array[j] < pivot)
            {
               i++;
               tmp = array[i];
               array[i] = array[j];
               array[j] = tmp;
            }
         }
         // and finally move the pivot to the next spot in the array;
         i++;
         tmp = array[i];
         array[i] = array[end];
         array[end] = tmp;

         return i; // i is the location of the pivot
      }

      [Test]
      public static void QuickSortInPlaceTest()
      {
         List<int> input = new() { 3, 1, 8, 2, 5, 6, 10, 7, 4, 9 };
         QuickSortInPlace(input);
         
         CollectionAssert.AreEqual(new[]{1,2,3,4,5,6,7,8,9,10}, input);

         Assert.IsTrue(partitionCalls > 0);
         // Assert.AreNotSame(input, output);
         // CollectionAssert.IsOrdered(output);
      }
      
      [Test]
      public static void QuickSortOutOfPlaceTest()
      {
         List<int> input = new() { 3, 1, 8, 2, 5, 6, 10, 7, 4, 9 };
         var result = QuickSortOutOfPlace(input);
         
         CollectionAssert.AreEqual(new List<int>{1,2,3,4,5,6,7,8,9,10}, result);
         Assert.AreNotSame(input, result);
         CollectionAssert.IsOrdered(result);
      }
      
      // 3. Generalize your implementation to take a `List<T>`, and additionally a 
      // `Comparison<T>` delegate.

      // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
      // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
      // takes a `Func<IDisposable>` as first
      // parameter, instead of the `IDisposable`. (This can be used to fix warnings
      // given by some code analysis tools about instantiating an `IDisposable` and
      // not disposing it.)
   }
}
