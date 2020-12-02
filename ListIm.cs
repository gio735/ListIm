using System;
using System.Collections.Generic;
using System.Text;

namespace ListIm
{
    public class ListIm<T>
    {
        private int _size = 5;

        private int _currentArray = 1;
        private int _currentIndex = 0;
        public T[] Array1 { get; private set; }
        public T[] Array2 { get; private set; }

        public ListIm()
        {
            Array1 = new T[_size];
            Array2 = new T[_size];
        }

        public void Append(T addition)
        {
            if (_currentArray == 1)
            {
                if (_currentIndex == _size - 1)
                {
                    _currentArray = 2;
                    _size *= 2;
                    Array2 = new T[_size];
                    _currentIndex = 0;
                    foreach (T value in Array1)
                    {
                        Array2[_currentIndex] = value;
                        _currentIndex++;
                    }
                    Array2[_currentIndex] = addition;
                    _currentIndex++;
                }
                else
                {
                    Array1[_currentIndex] = addition;
                    _currentIndex++;
                }
            }
            else
            {
                if (_currentIndex == _size - 1)
                {
                    _currentArray = 1;
                    _size *= 2;
                    Array1 = new T[_size];
                    _currentIndex = 0;
                    foreach (T value in Array2)
                    {
                        Array1[_currentIndex] = value;
                        _currentIndex++;
                    }
                    Array1[_currentIndex] = addition;
                    _currentIndex++;
                }
                else
                {
                    Array2[_currentIndex] = addition;
                    _currentIndex++;
                }
            }
            
        }
        public void pop(int index = -1)

        {
            if (index >= _currentIndex)
            {
                Console.WriteLine("There is no element on that index");
            }
            if (index == -1)
            {
                index = _currentIndex - 1;
            }
            if (_currentArray == 1)
            {
                for (int i = index; _currentIndex >= i; i++)
                {
                    Array1[i] = Array1[i + 1];
                }
                _currentIndex--;
            }
            else
            {
                for (int i = index; _currentIndex > i; i++)
                {
                    Array2[i] = Array2[i + 1];
                }
                _currentIndex--;
            }
        }
        public void Print()
        {
            string result = "";
            foreach (T element in Array1)
            {
                result += element + " ";
            }
            result += "\n";
            Console.WriteLine(result);
        }
    }
}
