namespace Algorithms;

public class QuickSort
{
    public int[] SortArray(int[] arr)
    {
        if (arr.Length < 2)
            return arr;

        var pivot = arr.Length / 2;
        
        var left = SortArray(arr.Where(x => x <= arr[pivot]).ToArray());
        var right = SortArray(arr.Where(x => x > arr[pivot]).ToArray());

        return left.Concat(right).ToArray();
    }
}