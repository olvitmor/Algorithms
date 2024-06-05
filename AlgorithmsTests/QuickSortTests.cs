using Algorithms;
using FluentAssertions;
using Xunit;

namespace AlgorithmsTests;

public class QuickSortTests
{
    private readonly QuickSort _sort;
    
    public QuickSortTests()
    {
        _sort = new QuickSort();
    }
    
    [Fact]
    public void SortArray_ReturnsSorted()
    {
        // Arrange
        int[] arr = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10];
        var sortedViaLinq = arr.ToList();
        sortedViaLinq.Sort();
        
        // Act
        var sortedArray = _sort.SortArray(arr);

        // Assert
        sortedArray.Should().BeEquivalentTo(sortedViaLinq);
    }
}