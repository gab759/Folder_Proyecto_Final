using UnityEngine;
using System;
public class TablaHash <T>
{
    class Node
    {
        public string Identifier { get; set; }
        public T Value { get; set; }
        public Node(string identifier, T value)
        {
            Identifier = identifier;
            Value = value;
        }
    }

    Node[] storage = new Node[103];
    int maxCollisions = 0;
    char[] alphabet = new char[27];

    public void InitializeAlphabet() // O(n)
    {
        int asciiValue = 97;
        for (int i = 1; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)asciiValue;
            asciiValue++;
        }
    }

    public void Add(string identifier, T value) // O(n)
    {
        identifier = identifier.ToLower();
        Node newElement = new Node(identifier, value);
        int hashBase = CreateHash(identifier);
        int primaryHash = hashBase % 103;
        int offset1 = 0;
        int offset2 = 1;
        int attempts = 0;
        int index = primaryHash;

        while (storage[index] != null)
        {
            index = (primaryHash + offset1 * attempts + offset2 * attempts * attempts) % 103;
            attempts++;
        }

        if (attempts > maxCollisions)
        {
            maxCollisions = attempts;
        }

        storage[index] = newElement;
    }

    public T Search(string identifier) // O(n)
    {
        identifier = identifier.ToLower();
        int hashBase = CreateHash(identifier);
        int primaryHash = hashBase % 103;
        int offset1 = 0;
        int offset2 = 1;
        int attempts = 0;
        int index = primaryHash;
        if (index < 0 || index >= storage.Length)
        {
            throw new IndexOutOfRangeException("Papito lindo este indice: " + index + " esta fuera del rango");
        }
        while (storage[index] != null && storage[index].Identifier != identifier)
        {
            index = (primaryHash + offset1 * attempts + offset2 * attempts * attempts) % 103;
            attempts++;
        }

        if (storage[index] != null && storage[index].Identifier == identifier)
        {
            return storage[index].Value;
        }

        return default(T);
    }

    private int CreateHash(string identifier)//O(n)2
    {
        char[] characters = identifier.ToCharArray();
        int stringLength = identifier.Length;
        int hashValue = 0;

        for (int i = 0; i < characters.Length; i++)
        {
            int charIndex = 0;

            for (int j = 0; j < alphabet.Length; j++)
            {
                if (characters[i] == alphabet[j])
                {
                    charIndex = j;
                    break;
                }
            }

            int multiplier = 1;
            for (int j = 0; j < stringLength - 1; j++)
            {
                multiplier *= 26;
            }

            hashValue += charIndex * multiplier;
            stringLength--;
        }

        return hashValue;
    }

    public void DisplayAllData() // O(n)
    {
        for (int i = 0; i < storage.Length; i++)
        {
            if (storage[i] != null)
            {
                Debug.Log("Indice " + i + " identificador o codigo llave: " + storage[i].Identifier);
            }
        }
    }
}