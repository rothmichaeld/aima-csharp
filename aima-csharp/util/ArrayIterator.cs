using System;
using System.Collections;
using System.Collections.Generic;

namespace aima.core.util
{
    /**
     * Iterates efficiently through an array.
     * 
     * @author Ruediger Lunde
     */
    public class ArrayIterator<T> : IEnumerator<T>
    {
        private readonly T[] values;
        private int counter;

        public T Current => values[counter];

        object IEnumerator.Current => Current;

        public ArrayIterator(T[] values)
        {
            this.values = values;
            counter = 0;
        }

        public bool hasNext()
        {
            return counter < values.Length;
        }

        public T next()
        {
            return values[counter++];
        }

        public void remove()
        {
            throw new NotSupportedException();
        }

        public bool MoveNext()
        {
            counter++;
            return (counter < values.Length);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}