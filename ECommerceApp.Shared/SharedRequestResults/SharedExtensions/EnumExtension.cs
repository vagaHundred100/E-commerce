using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace ECommerceApp.Shared.SharedRequestResults.SharedExtensions
{
    public static class EnumExtension
    {
        public static string GetEnumFieldDescription(this Enum value)
        {
            FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        public static List<KeyValuePair<string, int>> GetEnumKeyValueList<T>()
        {
            List<KeyValuePair<string, int>>? list = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
            }
            return list;
        }
        public static List<KeyValuePair<string, int>> EnumDescriptionToList<T>()
        {
            List<KeyValuePair<string, int>>? pairs = new List<KeyValuePair<string, int>>();
            Array enumValues = Enum.GetValues(typeof(T));
            foreach (Enum value in enumValues)
            {
                pairs.Add(new KeyValuePair<string, int>(value.GetEnumFieldDescription(), Convert.ToInt32(value)));
            }
            return pairs;
        }
        public static T[] ToBestcompArray<T>(this List<T> list)
        {
            T[] value = new T[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                value[i] = list[i];
            }
            return value;
        }
    }
}