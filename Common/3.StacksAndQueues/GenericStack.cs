
using System.Collections.Generic;

namespace Common
{
    public class GenericStack<T> : IPushPop<T>
    {
        //TODO #1: Declare a List inside this object class to store the objects. Choose the most appropriate object class
        GenericArrayList<T> list = new GenericArrayList<T>(10000000);

        public string AsString()
        {
            //TODO #2: Return the list as a string. Use the method already implemented in your list
            return list.AsString();
        }

        public int Count()
        {
            //TODO #3: Return the number of objects
            return list.Count();
        }

        public void Clear()
        {
            //TODO #4: Remove all objects stored
            list.Clear();
        }

        public void Push(T value)
        {
            //TODO #5: Add a new object to the list (at the end of it)
            list.Add(value);
        }

        public T Pop()
        {
            //TODO #6: Remove the first object of the list and return it
            T removedElement = list.Get(list.Count() - 1);
            list.Remove(list.Count() - 1);
            return removedElement;
        }
    }
}