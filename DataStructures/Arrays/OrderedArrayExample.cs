namespace DataStructures.Arrays;

public class OrderedArrayExample : IArrayExample
{
    public void Execute()
    {
        const int arraySize = 4;
        var array = new OrderedArrayStructure(arraySize);
        array.Insert(77); // insert 10 items
        array.Display();
        array.Insert(99);
        array.Display();
        array.Insert(44);
        array.Insert(55);
        array.Display();
        array.Insert(22);
        array.Insert(88);
        array.Insert(11);
        array.Insert(00);
        array.Insert(66);
        array.Display();
        array.Insert(33);
    }
}

public class OrderedArrayStructure(int maxElements)
{
    private int[] _array = new int[maxElements];
    private int _numOfElements = 0;

    public int? Find(int value)
    {
        var lowerBound = 0;
        var upperBound = _numOfElements-1;
        while (true)
        {
            var middleIndex = (upperBound + lowerBound) / 2;
            if (_array[middleIndex] == value)
                return middleIndex;

            if(lowerBound > upperBound)
                return null;

            if (_array[middleIndex] > value)
                upperBound = middleIndex - 1;
            else if (_array[middleIndex] < value)
                lowerBound = middleIndex + 1;
        }
    }

    public void Insert(int value)
    {
        //_numOfElements checks if current number of elements are equal to length of my array
        if (_numOfElements == _array.Length)
            throw new Exception("Array is full");

        if (_numOfElements == 0)
        {
            _array[_numOfElements] = value;
            _numOfElements++;
            return;
        }

        var lowerBound = 0;
        var upperBound = _numOfElements - 1;
        int indexToInsertAt = 0;
        while (lowerBound <= upperBound)
        {
            var middleIndex = (upperBound + lowerBound) / 2;
            if (_array[middleIndex] == value)
            {
                indexToInsertAt = middleIndex;
                break;
            }

            if(_array[middleIndex] < value)
                lowerBound = middleIndex + 1;
            else if (_array[middleIndex] > value)
                upperBound = middleIndex - 1;
        }

        if (indexToInsertAt == 0)
            indexToInsertAt = lowerBound;
        
        for (int i = _numOfElements; i > indexToInsertAt; i--)
        {
            _array[i] = _array[i - 1];
        }
        
        _array[indexToInsertAt] = value;
        _numOfElements++;
    }
    
    public void Display()
    {
        for (int i = 0; i < _numOfElements; i++)
        {
            Console.Write($"{_array[i]} ");
        }

        Console.WriteLine();
        Console.WriteLine($"currentNumberOfElements = {_numOfElements}");
    }
}