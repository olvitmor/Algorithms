namespace Algorithms;

public class BinarySearch
{
    /// <summary>
    /// Find index of target with binary search
    /// </summary>
    /// <param name="arr">Sorted array of unique int values</param>
    /// <param name="target">Value to find</param>
    /// <returns></returns>
    public int FindIndex(int[] arr, int target)
    {
        int left = -1, right = -1;
        
        while (true)
        {
            if (left == -1) left = 0;

            if (right == -1) right = arr.Length - 1;

            var middle = left + (right - left) / 2;

            if (target == arr[middle]) return middle;

            if (right < left || (middle == left && arr[right] != target))
            {
                return -1;
            }

            if (target > arr[middle])
            {
                left = middle;
            }
            else
            {
                right = middle;
            }
        }
    }
}