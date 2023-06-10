using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType
{
    public static readonly int NULL = 0;
    public static readonly int NOT_NULL = 1;
    public static readonly int ORE = 1 << 1;
    public static readonly int ROCK = 1 << 2;

    private int itemType;

    public ItemType()
    {
        this.itemType = NULL;
    }

    public void SetType(int itemType)
    {
        this.itemType = itemType;
    }

    public bool IsExactlyItemType(int itemType)
    {
        return this.itemType == itemType;
    }
    public bool IsItemType(int itemType) {
        return (this.itemType & itemType) == itemType;
    }

    public void AddType(int itemType)
    {
        this.itemType = this.itemType | itemType | NOT_NULL;
    }
    public void RemoveType(int itemType)
    {
        this.itemType = this.itemType & (~itemType);
    }
}
