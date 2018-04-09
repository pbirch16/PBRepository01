//https://stackoverflow.com/questions/5716423/c-sharp-sortable-collection-which-allows-duplicate-keys
using System;
using System.Collections.Generic;

namespace PbPropertyEditor
{
    class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);
            if (result == 0)
            {
                return 1; //Handle equality as being greater
            }
            else
            {
                return result;
            }
        }
    }
}
