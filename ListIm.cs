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
        public void Pop(T obj)
        {
            Pop((int)IndexOf(obj));
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
        public void Sorter()
        {
            T[] Array2 = Array1;
            int[] banned = new int[_size];
            int[] bannedSi = new int[_size];
            for (int i = 0; i < bannedSi.Length; i++)
            {
                bannedSi[i] = -1;
            }
            int bannedAmount = 0;
            bool zeroUsed = false;
            for (int si = 0; _currentIndex - 1 > si; si++)
            {
                bool bannedVal = false;
                int fi = 0;
                for (fi = 0; _currentIndex - 1 > fi; fi++)
                {
                    bannedVal = false;
                    foreach (int index in banned)
                    {
                        
                        if (index == fi && fi != 0 || fi == 0 && zeroUsed)
                        {
                            bannedVal = true;
                            
                            break;
                        }
                        
                    }
                    bool isBannedSi = false;
                    foreach (int index in bannedSi)
                    {

                        if (index == si)
                        {
                            isBannedSi = true;

                            break;
                        }

                    }
                    if (Array1[fi] != null && !bannedVal)
                    {
                        if (Array1[fi].CompareTo(Array2[si]) < 0 || isBannedSi)
                        {
                            Array2[si] = Array1[fi];
                            if (isBannedSi)
                            {
                                for (int i = 0; i < bannedSi.Length; i++)
                                {

                                    if (bannedSi[i] == si)
                                    {
                                        bannedSi[i] = -1;
                                    }

                                }
                            }
                        }
                    }
                    
                }
                if (!bannedVal)
                {
                    banned[bannedAmount] = fi;
                    
                    bannedAmount++;
                    if (fi == 0)
                    {
                        zeroUsed = true;
                    }
                }
                
                
            }
            IntArray(banned, bannedAmount);
            Array1 = Array2;   
        }
        private void IntArray(int[] numbs, int len)
        {
            for ( int i = 0; i < len; i++)
            {
                Console.WriteLine(numbs[i]);
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
            return Array1.GetEnumerator();
        }
        public void Test()
        {
            Console.WriteLine("b".CompareTo("a"));
        }
    }
}
