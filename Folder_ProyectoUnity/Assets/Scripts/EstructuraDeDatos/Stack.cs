using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Stack<T>
{
    class Node
    {
        public T Value { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Previous = null;
            Next = null;
        }
    }
    private Node head;
    private Node top;
    public int count = 0;

    public void Push(T value)
    {
        if (top == null)
        {
            Node newNode = new Node(value);
            head = newNode;
            top = newNode;
            count = count + 1;
        }
        else
        {
            Node newNode = new Node(value);
            top.Next = newNode;
            newNode.Previous = top;
            top = newNode;
            count = count + 1;
        }
    }

    public T Pop()
    {
        if (top == null)
        {
            Debug.LogError("La pila está vacía");
            return default;
        }
        else
        {
            T value = top.Value;
            Node previousNode = top.Previous;
            if (previousNode != null)
            {
                previousNode.Next = null;
            }
            top.Previous = null;
            top = previousNode;
            count--;
            return value;
        }
    }
    public T Peek()
    {
        if (top == null)
        {
            Debug.LogError("La pila está vacía.");
            return default;
        }
        return top.Value;
    }
    public void PrintAllNodes()
    {
        Node tmp = head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
    }
}