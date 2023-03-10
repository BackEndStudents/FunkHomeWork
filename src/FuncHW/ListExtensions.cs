using System;
using System.Collections.Generic;

namespace FuncHW
{
    public static class ListExtensions
    {
        //add extension for List GetLast: receives Func, returns the last element in the List that matches the condition

        //add extension for List GetFirst: receives Func, returns the first element in the List that matches the condition

        public static int CountElements<T>(this List<T> values, Func<T, bool> func)
        {
            int count = 0;
            foreach (T item in values)
            {
                if (func(item))
                {
                    count++;
                }
            }

            return count;
        }

        public static List<T> SelectWhereNot<T>(this List<T> values, Func<T, bool> func)
        {
            List<T> resultList = new List<T>();

            foreach (var item in values)
            {
                if (!func(item))
                {
                    resultList.Add(item);
                }
            }

            return resultList;
        }
        //add extension for List SelectWhereNot: receives Func, returns the list of elements that don't match the condition

        public static T GetLast<T>(this List<T> values, Func<T, bool> func) where T : class
        {
            for (int i = values.Count - 1; i >= 0; i--)
            {
                if (func(values[i]))
                {
                    return values[i];
                }
            }
            return null;
        }
    }
}