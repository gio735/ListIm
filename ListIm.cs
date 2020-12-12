using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListIm
{
    public class ListIm<T> : IEnumerable where T : IComparable
    {
        private int _size = 5;
        private int _currentIndex = 0;
        private T[] Array1;

        public ListIm()
        {
            Array1 = new T[_size];
        }

        public void Append(T addition)
        {
            if (_currentIndex == _size - 1)
            {
                _size *= 2;
                T[] Array2 = new T[_size];
                for (int indexer = 0; indexer < _currentIndex; indexer++)
                {
                    Array2[indexer] = Array1[indexer];
                }
                Array2[_currentIndex] = addition;
                _currentIndex++;
                Array1 = Array2;
            }
            else
            {
                Array1[_currentIndex] = addition;
                _currentIndex++;
            }
        }
        public void MultiAppend(T[] additions)
        {
            foreach (T addition in additions)
            {
                Append(addition);
            }
        }

        public void Pop(int ind = -1)

        {
            if (ind >= _currentIndex)
            {
                Console.WriteLine("There is no element on that index");
                return;
            }
            if (ind == -1)
            {
                ind = _currentIndex - 1;
            }
            for (int i = ind; _currentIndex >= i; i++)
            {
                Array1[i] = Array1[i + 1];
            }
            _currentIndex--;

            if (_currentIndex <= Array1.Length / 4)
            {
                Reduce();
            }
        }
        public void Pop(T obj)
        {
            Pop((int)IndexOf(obj));
        }
        public void PopAll(T obj, int amount = -1)
        {
            int count = 0;
            for (int i = 0; i < _currentIndex; i++)
            {
                if (Array1[i].CompareTo(obj) == 0)
                {
                    if (count == amount)
                    {
                        Console.WriteLine($"{count} element eliminated :>");
                        return;
                    }
                    Pop(Array1[i]);
                    count++;
                }
            }
            Console.WriteLine($"{count} element eliminated :>");
        }
        private void Reduce()
        {
            _size /= 2;
            T[] Array2 = new T[_size];
            _currentIndex = 0;
            foreach (T value in Array1)
            {
                Array2[_currentIndex] = value;
                _currentIndex++;

            }
        }

        public void Print()
        {
            string result = "";

            for (int i = 0; i < _currentIndex; i++)
            {
                if (Array1[i] != null)
                {
                    result += Array1[i].ToString() + " ";
                }

            }
            result += "\n";
            Console.Write(result.Replace("  ", " "));
        }
        public void Print(int ind)
        {
            Console.WriteLine(Get(ind));
        }
        public void Print(int firstVal, int secondVal)
        {
            string result = "";
            if (firstVal < secondVal)
            {

                bool compatable = firstVal > 0 && firstVal < _currentIndex && secondVal < _currentIndex;
                if (compatable)
                {
                    while (firstVal <= secondVal)
                    {
                        result += Array1[firstVal] + " ";
                        firstVal++;
                    }
                }
                else
                {
                    Console.WriteLine("Index out of range!");
                    return;
                }
            }
            else
            {
                bool compatable = secondVal > 0 && secondVal < _currentIndex && firstVal < _currentIndex;
                if (compatable)
                {
                    while (secondVal <= firstVal)
                    {
                        result += Array1[secondVal] + " ";
                        secondVal++;
                    }
                }
                else
                {
                    Console.WriteLine("Index out of range!");
                    return;
                }
            }
            Console.WriteLine(result);
        }
        public T Get(int ind)
        {
            if (ind < _currentIndex)
            {
                return Array1[ind];
            }
            else
            {
                return Array1[_currentIndex - 1];
            }

        }

        public void Sorter(bool descend = false)
        {
            T[] sorted = Array1;
            T temp;
            if (descend)
            {




                for (int i = 0; i < _currentIndex; i++)
                {
                    for (int j = 0; j < _currentIndex; j++)
                    {
                        if (sorted[i].CompareTo(sorted[j]) == 1)
                        {
                            temp = sorted[i];
                            sorted[i] = sorted[j];
                            sorted[j] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < _currentIndex; i++)
                {
                    for (int j = 0; j < _currentIndex; j++)
                    {
                        if (sorted[i].CompareTo(sorted[j]) == -1)
                        {
                            temp = sorted[i];
                            sorted[i] = sorted[j];
                            sorted[j] = temp;
                        }
                    }
                }
            }
        }

        public int? IndexOf(T obj)
        {
            int i = 0;
            foreach (T element in Array1)
            {
                if (element != null)
                {
                    int compared = element.CompareTo(obj);
                    if (compared > 0)
                    {
                        return i;
                    }
                    i++;
                }
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
