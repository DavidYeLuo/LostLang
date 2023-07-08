using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData<T>
{
    public void SetData(T data);
    public T GetData();
}
