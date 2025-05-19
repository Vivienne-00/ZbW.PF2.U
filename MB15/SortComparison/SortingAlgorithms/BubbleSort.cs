using System.Collections.Generic;

namespace MB15.SortComparison.SortingAlgorithms
{
    public class BubbleSort : SortAlgorithm
    {
        public override string Name => "Bubblesort";
        public override void Sort(IList<int> arrayToSort)
        {
          for (int i = 0; i < arrayToSort.Count; i++)
          {
            for (int j = i; j < arrayToSort.Count - (1 + i); j++)
            {
              if (arrayToSort[j] > arrayToSort[j + 1])
              {
                var temp = arrayToSort[j];
                arrayToSort[j] = arrayToSort[j + 1];
                arrayToSort[j + 1] = temp;
              }
            }
          }
        }
      }
    }
