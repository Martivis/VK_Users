using System.Reflection;

namespace Tests.Common;

public static class FieldAccessor
{
    public static TField GetValue<TObject, TField>(TObject source, string fieldName)
    {
        var type = typeof(TObject);
        var field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
            ?? throw new Exception($"Field {fieldName} not found");
        return (TField)field.GetValue(source)!;
    }

    public static void SetValue<TObject, TField>(TObject target, string fieldName, TField value)
    {
        var type = typeof(TObject);
        var field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
            ?? throw new Exception($"Field {fieldName} not found");
        field.SetValue(target, value);
    }
}
