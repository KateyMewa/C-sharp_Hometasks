using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayEvent
{
   public class ArrayEventArgs<T> : EventArgs
    {
        public int Index { get; private set; }
        public T Value { get; private set; }
        public string Message { get; private set; }
        public ArrayEventArgs(int index, string message, T value)
        {
            Index = index;
            Message = message;
            Value = value;
        }
    }
}
