//https://msdn.microsoft.com/en-us/library/cfttsh47(v=vs.110).aspx
//Comparer<T> Class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerTClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //public class BoxLengthFirst : Comparer<Box>
    //{
    //    // Compares by Length, Height, and Width.
    //    public override int Compare(Box x, Box y)
    //    {
    //        if (x.Length.CompareTo(y.Length) != 0)
    //        {
    //            return x.Length.CompareTo(y.Length);
    //        }
    //        else if (x.Height.CompareTo(y.Height) != 0)
    //        {
    //            return x.Height.CompareTo(y.Height);
    //        }
    //        else if (x.Width.CompareTo(y.Width) != 0)
    //        {
    //            return x.Width.CompareTo(y.Width);
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }

    //}

    //// This class is not demonstrated in the Main method
    //// and is provided only to show how to implement
    //// the interface. It is recommended to derive
    //// from Comparer<T> instead of implementing IComparer<T>.
    //public class BoxComp : IComparer<Box>
    //{
    //    // Compares by Height, Length, and Width.
    //    public int Compare(Box x, Box y)
    //    {
    //        if (x.Height.CompareTo(y.Height) != 0)
    //        {
    //            return x.Height.CompareTo(y.Height);
    //        }
    //        else if (x.Length.CompareTo(y.Length) != 0)
    //        {
    //            return x.Length.CompareTo(y.Length);
    //        }
    //        else if (x.Width.CompareTo(y.Width) != 0)
    //        {
    //            return x.Width.CompareTo(y.Width);
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //}

    public class Box : IComparable<Box>
    {

        public Box(int h, int l, int w)
        {
            this.Height = h;
            this.Length = l;
            this.Width = w;
        }
        public int Height { get; private set; }
        public int Length { get; private set; }
        public int Width { get; private set; }

        public int CompareTo(Box other)
        {
            // Compares Height, Length, and Width.
            if (this.Height.CompareTo(other.Height) != 0)
            {
                return this.Height.CompareTo(other.Height);
            }
            else if (this.Length.CompareTo(other.Length) != 0)
            {
                return this.Length.CompareTo(other.Length);
            }
            else if (this.Width.CompareTo(other.Width) != 0)
            {
                return this.Width.CompareTo(other.Width);
            }
            else
            {
                return 0;
            }
        }

    }

    }
