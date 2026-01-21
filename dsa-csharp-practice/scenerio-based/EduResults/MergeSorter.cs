using System.Collections.Generic;

namespace EduResults
{
    public class MergeSorter
    {
        // Public method to sort a list of students
        public List<Student> Sort(List<Student> list)
        {
            if (list == null || list.Count <= 1)
                return list;

            return MergeSort(list);
        }

        // Internal recursive merge sort
        private List<Student> MergeSort(List<Student> list)
        {
            if (list.Count <= 1)
                return list;

            int mid = list.Count / 2;
            List<Student> left = list.GetRange(0, mid);
            List<Student> right = list.GetRange(mid, list.Count - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        // Merge two sorted lists (stable, descending by score)
        private List<Student> Merge(List<Student> left, List<Student> right)
        {
            List<Student> result = new List<Student>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i].Score > right[j].Score)
                {
                    result.Add(left[i]);
                    i++;
                }
                else if (left[i].Score < right[j].Score)
                {
                    result.Add(right[j]);
                    j++;
                }
                else
                {
                    // Stable: keep left student first if scores equal
                    result.Add(left[i]);
                    i++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }
    }
}
