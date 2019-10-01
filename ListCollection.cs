using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var names = new List<string> { "<name>", "Ana", "Felipe" };
        foreach (var name in names)
        {
            Console.WriteLine($"Hello {name.ToUpper()}!");
        }
        //**********************************************************************
        Console.WriteLine();
        names.Add("Maria");
        names.Add("Bill");
        names.Remove("Ana");
        foreach (var name in names)
        {
            Console.WriteLine($"Hello {name.ToUpper()}!");
            Console.WriteLine($"My name is {names[0]}.");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");
            Console.WriteLine($"The list has {names.Count} people in it");
        }
        //************************************************************************
        //To find elements in these larger collections, you need to search the list for different items. 
        //The IndexOf method searches for an item and returns the index of the item.
        //You may not know if an item is in the list, so you should always check the index returned by IndexOf. If it is -1, the item was not found.
        var index = names.IndexOf("Felipe");
        if (index != -1)
            Console.WriteLine($"The name {names[index]} is at index {index}");

        var notFound = names.IndexOf("Not Found");
        Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

        //The Sort method sorts all the items in the list in their normal order (alphabetically in the case of strings).
        names.Sort();
        foreach (var name in names)
        {
            Console.WriteLine($"Hello {name.ToUpper()}!");
        }

        //**************************************************************************
        var fibonacciNumbers = new List<int> { 1, 1 };
        //That creates a list of integers, and sets the first two integers to the value 1. 
        //The Fibonacci Sequence, a sequence of numbers, starts with two 1s. 
        //Each next Fibonacci number is found by taking the sum of the previous two numbers.
        var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
        var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

        fibonacciNumbers.Add(previous + previous2);

        foreach (var item in fibonacciNumbers)
            Console.WriteLine(item);
    }
}
