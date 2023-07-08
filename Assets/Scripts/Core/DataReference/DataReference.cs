using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReference<T>
{
    private T data;
    public Action onDataChange;
    public void SetData(T data)
    {
        this.data = data;
        onDataChange?.Invoke();
    }
    public T GetData()
    {
        return data;
    }
}
