using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_Users.Common;

public static class EnumHelper
{
    public static string GetEnumValuesInString(this Type e)
    {
        var values = e.GetEnumValuesAsUnderlyingType();
        var stringBuilder = new StringBuilder();

        foreach (var value in values)
        {
            if (stringBuilder.Length == 0)
                stringBuilder.Append($"[{value}");
            else
                stringBuilder.Append($", {value.ToString()}");
        }
        stringBuilder.Append(']');
        return stringBuilder.ToString();
    }
}
