using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CompareDelegateCore
{
    public delegate bool CompareDelegate<T>(T lhs, T rhs);
    
    public class Compare<T> 
        where T: IComparable
    {
        public static bool RhsIsGreater(T lhs, T rhs)
        {
            var typeLhs = lhs.GetType();
            var typeRhs = rhs.GetType();

            if (typeLhs != typeRhs)
            {
                return false;
            }

            int result = lhs.CompareTo(rhs);

            if (result > 0)
                return true;

            return false;
        }
    }
}

