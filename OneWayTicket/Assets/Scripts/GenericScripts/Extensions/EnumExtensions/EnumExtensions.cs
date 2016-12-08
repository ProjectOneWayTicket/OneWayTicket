using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

public static class EnumExtensions
{
    public static string ToDescription<TEnum>(this TEnum e)
    {
        FieldInfo fi = e.GetType().GetField(e.ToString());

        if (fi != null)
        {
            object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;
        }

        return null;
    }
}

