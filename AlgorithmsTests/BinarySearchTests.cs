using System.Diagnostics;
using Algorithms;
using FluentAssertions;
using Xunit;

namespace AlgorithmsTests;

public class BinarySearchTests
{
    private readonly BinarySearch _search;
    
    public BinarySearchTests()
    {
        _search = new BinarySearch();
    }
    
    [Fact]
    public void FindIndex_FindsIndex()
    {
        // Arrange
        int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        
        // Act
        var index = _search.FindIndex(arr, 7);

        // Assert
        index.Should().Be(Array.IndexOf(arr, 7));
    }

    [Fact]
    public void FindIndex_LargeArray_FindsIndex()
    {
        // Arrange
        var random = new Random();
        var list = Enumerable.Range(0, 1000000)
            .Select(x => random.Next(-500000, 500000))
            .ToList();

        list.Sort();

        var target = list[random.Next(0, 1000000)];

        // Act
        var index = _search.FindIndex(list.ToArray(), target);

        // Assert
        index.Should().Be(list.IndexOf(target));
    }

    [Fact]
    public void FindIndex_AbsentValue_ReturnsMinusOne()
    {
        // Arrange
        var random = new Random();
        var list = Enumerable.Range(0, 1000000)
            .Select(x => random.Next(-500000, 500000))
            .ToList();
        
        list.Sort();
        
        var target = list[random.Next(0, 1000000)];
        list.RemoveAll(x => x == target);

        // Act
        var index = _search.FindIndex(list.ToArray(), target);

        // Assert
        index.Should().Be(-1);
    }

    [Fact]
    public void FindIndex_LargeArray_FasterThanIteration()
    {
        // Arrange
        var random = new Random();
        var list = new List<int>();

        for (var i = 0; i < 100000000; i++)
        {
            list.Add(i -500000);
        }

        list.Sort();
        var arr = list.ToArray();

        var target = list[random.Next(100000, 10000000)];

        var sw = new Stopwatch();
        sw.Start();

        foreach (var t in arr)
        {
            if (t == target)
            {
                break;
            }
        }
        
        sw.Stop();
        var iterationTime = sw.ElapsedMilliseconds;
        sw.Restart();
        
        // Act
        var index = _search.FindIndex(arr, target);
        sw.Stop();
        var binarySearchTime = sw.ElapsedMilliseconds;

        // Assert
        binarySearchTime.Should().BeLessThanOrEqualTo(iterationTime);
    }
}