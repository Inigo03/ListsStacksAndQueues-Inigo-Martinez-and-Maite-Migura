using System;

namespace Common
{
    public class IntListNode
    {
        public int Value;
        public IntListNode Next = null;

        public IntListNode(int value)
        {
            Value = value;
        }
    }

    public class IntList : IList
    {
        IntListNode First = null;
        IntListNode Last = null;
        int numElements = 0;

        //This method returns all the elements on the list as a string
        //Use it as an example on how to access all the elements on the list
        public string AsString()
        {
            IntListNode node = First;
            string output = "[";

            while (node != null)
            {
                output += node.Value + ",";
                node = node.Next;
            }
            output = output.TrimEnd(',') + "] " + Count() + " elements";

            return output;
        }

        
        public void Add(int value)
        {
            //TODO #1: add a new integer to the end of the list
            IntListNode newNode = new IntListNode(value);
            IntListNode refNode = First;
            
            if (refNode == null)
            {
                First = newNode;
                Last = newNode;
                numElements++;
            }
            else
            {
                while (refNode != null && refNode.Next != null)
                {
                    refNode = refNode.Next;
                }
                refNode.Next = newNode;
                Last = newNode;
                numElements++;
            }
        }

        private IntListNode GetNode(int index)
        {
            //TODO #2: Return the element in position 'index'
            int currentPos = 0;
            IntListNode currentNode = First;
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

        
        public int Get(int index)
        {
            //TODO #3: return the element on the index-th position. YOU MUST USE GetNode(int). O if the position is out of bounds
            if (index < 0 || index > Count())
            {
                return 0;
            }
            else
                return GetNode(index).Value;
        }

        
        public int Count()
        {
            //TODO #4: return the number of elements on the list
            return numElements;
        }
        
        public void Remove(int index)
        {
            //TODO #5: remove the element on the index-th position. Do nothing if position is out of bounds
            if (index >= 0 || index <= numElements) 
            { 
                IntListNode node = GetNode(index);

                if (node == First) 
                {
                    if (node.Next == null)
                    {
                        First = null;
                        Last = null;
                        numElements--;
                    }
                    else
                    {
                        First = node.Next;
                        numElements--;
                    }
                }
                else if (node == Last) 
                {
                    Last = GetNode(index - 1);
                    Last.Next = null;
                    numElements--;
                }
                else
                {
                    node.Next = GetNode(index - 1).Next;
                    numElements--;
                }
            }
        }

        
        public void Clear()
        {
            //TODO #6: remove all the elements on the list
            First = null;
            numElements = 0;
        }
    }
}