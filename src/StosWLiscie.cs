using System;
using System.Collections;
using System.Collections.Generic;


namespace Stos
{
    public class StosWLiscie<T> : IStos<T>
    {

        private class Wezel
        {
            public T dane;
            public Wezel next;

            public Wezel(T e, Wezel next)
            {
                dane = e;
                this.next = next;
            }
        }
        private Wezel szczyt;


        public StosWLiscie()
        {
            szczyt = null;
        }
        public void Push(T e)
        {
            szczyt = new Wezel(e, szczyt);
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();
            szczyt = szczyt.next;

            return default;
        }
        public T Peek => IsEmpty ? throw new StosEmptyException() : szczyt.dane;
       

        public int Size()
        {
            int size = 0;
            Wezel currentWezel = szczyt;
            while (currentWezel != null)
            {
                size++;
                currentWezel = currentWezel.next;
            }

            return size;
        }

        public int Count => Size();

        public void TrimExcess()
        {
            int trim = (int)(Count * 0.1);
            for (int i = 0; i < trim; i++)
            {
                Pop();

            }
        }
        public bool IsEmpty => szczyt == null;
        public void Clear() => szczyt = null;

        public T this[int index]
        {
            get
            {
                Wezel currentWezel = szczyt;
                int i = index;
                while (i > 0)
                {
                    currentWezel = currentWezel.next;
                    i--;
                }
                return currentWezel.dane;
            }
        }

        public T[] ToArray()
        {
            T[] temp = new T[Size()];

            int i = 0;
            foreach (var x in this)
            {
                temp[i++] = x;
            }

            return temp;
        }
        public IEnumerator<T> GetEnumerator()
        {
           for (int i = 0; i < Size(); i++)
           {
               yield return this[i];
           }
        }
      

        private class EnumeratorStosu : IEnumerator<T>
        {
            private StosWLiscie<T> stos;
            private int position = -1;
            internal EnumeratorStosu(StosWLiscie<T> stos) => this.stos = stos;
            public T Current => stos[position];
            object IEnumerator.Current => Current;
            public void Dispose() { } //nie wymaga implementacji
            public bool MoveNext()
            {
                if (position < stos.Count - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Reset() => position = -1;
        }
    }
}