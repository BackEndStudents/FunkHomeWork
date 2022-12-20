using System;
using System.Collections.Generic;

namespace FuncHW
{
    public static class ListExtensions
    {
        //add extension for List GetLast: receives Func, returns the last element in the List that matches the condition

        //add extension for List GetFirst: receives Func, returns the first element in the List that matches the condition

        //add extension for List CountElements: receives Func, returns the number of elements that match the condition

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
    }
}