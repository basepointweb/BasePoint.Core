﻿using BasePoint.Core.Shared;
using System.ComponentModel;
using System.Reflection;

namespace BasePoint.Core.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            string name = Enum.GetName(type, enumValue);

            if (!name.IsEmpty())
            {
                FieldInfo field = type.GetField(name);

                if (field is not null && Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute descriptionAttribute)
                    return descriptionAttribute.Description;
            }

            return string.Empty;
        }

        public static Enum NextValue<T>(this Enum enumValue) where T : Enum
        {
            Type type = enumValue.GetType();

            var values = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToList();

            var currentIndex = values.IndexOf((T)enumValue);

            if (currentIndex >= values.Count.ToZeroBasedIndex())
                return null;

            var nextIndex = currentIndex + Constants.QuantityOne;

            return values[nextIndex];
        }

        public static Enum CyclingNextValue<T>(this Enum enumValue) where T : Enum
        {
            Type type = enumValue.GetType();

            var values = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToList();

            var currentIndex = values.IndexOf((T)enumValue);

            if (currentIndex >= values.Count.ToZeroBasedIndex())
                return values.First();

            var nextIndex = currentIndex + Constants.QuantityOne;

            return values[nextIndex];
        }

        public static Enum CyclingPreviousValue<T>(this Enum enumValue) where T : Enum
        {
            Type type = enumValue.GetType();

            var values = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToList();

            var currentIndex = values.IndexOf((T)enumValue);

            if (currentIndex <= Constants.ZeroBasedFirstIndex)
                return values.Last();

            return values[currentIndex - Constants.QuantityOne];
        }
    }
}
