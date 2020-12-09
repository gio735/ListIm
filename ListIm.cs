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

        /*public void Append(T addition)
        {
            if (_currentIndex == _size - 1)
            {
                _size *= 2;
                T[] Array2 = new T[_size];
                _currentIndex = 0;
                foreach (T value in Array1)
                {
                    if (value != null)
                    {
                        Array2[_currentIndex] = value;
                        _currentIndex++;
                    }
                   
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
                
            
        }*/
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
                _size /= 2;
                T[] Array2 = new T[_size];
                _currentIndex = 0;
                foreach (T value in Array1)
                {
                    Array2[_currentIndex] = value;
                    _currentIndex++;
                }
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
        /*public void Sorter()
        {
            T[] Array2 = new T[_size];
            for (int si = 0; _currentIndex - 1 > si; si++)
            {
                for (int fi = 0; _currentIndex - 1 > fi; fi++)
                {
                    if (Array1[fi] != null)
                    {
                        if (Array1[fi].CompareTo(Array2[si]) > 0)
                        {
                            Array2[si] = Array1[fi];
                            break;
                        }
                    }
                    
                }
            }
            Array1 = Array2;   
        }*/
        public void Sorter()
        {
            T[] Array2 = new T[_size];
            int si = 0;
            
            bool check = false;
            while (si < _currentIndex)
            {
                int fi = 0;
                while ( _currentIndex - 1 > fi)
                {
                    check = true;
                    if (Array1[fi] != null)
                    {
                        if (Array1[fi].CompareTo(Array2[si]) > 0)
                        {
                            Array2[si] = Array1[fi];
                            fi = _currentIndex;
                            si++;
                            check = false;
                        }
                    }
                }
            if (check)
                {
                    check = false;
                    si++;
                }
            }
            Array1 = Array2;
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
            throw new NotImplementedException();
        }
    }
}

