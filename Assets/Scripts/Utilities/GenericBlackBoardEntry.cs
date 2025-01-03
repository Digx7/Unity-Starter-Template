using UnityEngine;
using UnityEngine.Events;
using System;

public class GenericBlackBoardEntry 
{
    private object value;
    private Type type;

    public UnityEvent<object, Type> OnEntryChanged;

    public GenericBlackBoardEntry(Type newType)
    {
        value = new object();
        type = newType;
    }

    public T GetEntryValue<T>()
    {
        return (T)value;
    }

    public Type GetEntryType()
    {
        return type;
    }

    public void SetEntryValue<T>(T newValue)
    {
        value = newValue;
        type = typeof(T);
        OnEntryChanged.Invoke(value, type);
    }
}