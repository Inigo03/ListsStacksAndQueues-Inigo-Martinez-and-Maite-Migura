using Common;

public class GenericListNode<T>
{
    public T Value;
    public GenericListNode<T> Next = null;

    public GenericListNode(T value)
    {
      Value = value;
    }

    public override string ToString()
    {
      return Value.ToString();
    }
}

public class GenericList<T> : IGenericList<T>
{
    GenericListNode<T> First = null;
    GenericListNode<T> Last = null;
    int NumElements = 0;

    public string AsString()
    {
      GenericListNode<T> node = First;
      string output = "[";

      while (node != null)
      {
        output += node.ToString() + ",";
        node = node.Next;
      }
      output = output.TrimEnd(',') + "] " + Count() + " elements";
      
      return output;
    }

    public void Add(T value)
    {
        //TODO #1: add a new element to the end of the list
        GenericListNode<T> newNode = new GenericListNode<T>(value);
        GenericListNode<T> refNode = First;

        if (refNode == null)
        {
            First = newNode;
            Last = newNode;
            NumElements++;
        }
        else
        {
            while (refNode != null && refNode.Next != null)
            {
                refNode = refNode.Next;
            }
            refNode.Next = newNode;
            Last = newNode;
            NumElements++;
        }
    }

    public GenericListNode<T> FindNode(int index)
    {
        //TODO #2: Return the element in position 'index'
        int currentPos = 0;
        GenericListNode<T> currentNode = First;
        while (currentPos < index && currentNode.Next != null)
        {
            currentNode = currentNode.Next;
            currentPos++;
        }
        if (currentPos == index)
        {
            return currentNode;
        }
        else
            return null;
    }

    public T Get(int index)
    {
        //TODO #3: return the element on the index-th position. YOU MUST USE GetNode(int). Return the default value for object class T if the position is out of bounds
        if (index < 0 || index > Count())
        {
            return default(T);
        }
        else
            return FindNode(index).Value;
    }
    public int Count()
    {
        //TODO #4: return the number of elements on the list
        return NumElements;
    }


    public void Remove(int index)
    {
        //TODO #5: remove the element on the index-th position. Do nothing if position is out of bounds
        if (index >= 0 || index <= NumElements)
        {
            GenericListNode<T> node = FindNode(index);

            if (node == First)
            {
                if (node.Next == null)
                {
                    First = null;
                    Last = null;
                    NumElements--;
                }
                else
                {
                    First = node.Next;
                    NumElements--;
                }
            }
            else if (node == Last)
            {
                Last = FindNode(index - 1);
                Last.Next = null;
                NumElements--;
            }
            else
            {
                node.Next = FindNode(index - 1).Next;
                NumElements--;
            }
        }
    }

    public void Clear()
    {
        //TODO #6: remove all the elements on the list
        First = null;
        NumElements = 0;
    }
}