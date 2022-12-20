using System;
using System.Collections.Generic;

namespace FuncHW
{
    public static class ListExtensions
    {
        //add extension for List GetLast: receives Func, returns the last element in the List that matches the condition

        //add extension for List GetFirst: receives Func, returns the first element in the List that matches the condition

        //add extension for List CountElements: receives Func, returns the number of elements that match the condition

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