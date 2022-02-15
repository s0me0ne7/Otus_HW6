using System.Collections;
using System;

namespace Otus_HW6
{
    public static class Finders
    {
        public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter)
        {
            var res = default(T);
            var maxVal = float.MinValue;
            foreach (T item in e)
            {
                var curVal = getParameter(item);

                if (curVal > maxVal)
                {
                    maxVal = curVal;
                    res = item;
                }
            }
            return res; 
        }

    }
}
