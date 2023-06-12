using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class ItemId<T>
{
    private List<T> itemType;

    public ItemId()
    {
        itemType = new List<T>();
    }

    public void SetType(T itemType)
    {
        if(this.itemType.Count > 0)
        {
            this.itemType.Clear();
        }
        this.itemType.Add(itemType);
    }

    public bool IsExactlyItemType(T itemType)
    {
        return this.itemType.Count == 1 && this.itemType.Contains(itemType);
    }
    public bool IsItemType(T itemType) {
        return this.itemType.Contains(itemType);
    }

    public void AddType(T itemType)
    {
        this.itemType.Add(itemType);
    }
    public void RemoveType(T itemType)
    {
        if(this.itemType.Contains(itemType))
        {
            this.itemType.Remove(itemType);
        }
    }
}
