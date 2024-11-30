namespace DataStructures.Arrays;

public interface IArrayExample
{
    void Execute();
}


public class UnOrderedArrayExample : IArrayExample
{
    public void Execute()
    {
        const int arraySize = 100;
        var arrayExample = new UnOrderedArrayStructure(arraySize);
        
        arrayExample.Insert(77); 
        arrayExample.Insert(99);
        arrayExample.Insert(44);
        arrayExample.Insert(55);
        arrayExample.Insert(22);
        arrayExample.Insert(88);
        arrayExample.Insert(11);
        arrayExample.Insert(00);
        arrayExample.Insert(66);
        arrayExample.Insert(33);
        
        arrayExample.Display();
        
        var searchKey = 35; // search for item
        Console.WriteLine(arrayExample.Find(searchKey) ? 
            $"Found element {searchKey}" : $"{searchKey} not found");
        
        arrayExample.Remove(00); // delete 3 items
        arrayExample.Remove(55);
        arrayExample.Remove(99);
        
        arrayExample.Display();
    }
}

public class UnOrderedArrayStructure(int maxElements)
{
    private int[] _testArray = new int[maxElements];
    private int _numOfElements;

    public bool Find(int searchKey)
    {
        var found = false;
        for (var i = 0; i < _numOfElements; i++)
        {
            if (_testArray[i] == searchKey)
            {
                found = true;
                break;
            }
        }
        
        return found;
    }

    public void Insert(int value)
    {
        _testArray[_numOfElements] = value;
        _numOfElements++;
    }

    public bool Remove(int searchKey)
    {
        var found = false;
        var foundIndex = 0;
        for (int i = 0; i < _numOfElements; i++)
        {
            if (_testArray[i] == searchKey)
            {
                found = true;
                foundIndex = i;
                break;
            }
        }

        if (!found) return false;
        {
            for (int i = foundIndex; i < _numOfElements; i++)
            {
                _testArray[i] = _testArray[i + 1];
            }
            _numOfElements--;
            return true;
        }
    }

    public void Display()
    {
        for (int i = 0; i < _numOfElements; i++)
        {
            Console.Write($"{_testArray[i]} ");
        }

        Console.WriteLine();
        Console.WriteLine($"currentNumberOfElements = {_numOfElements}");
    }
}