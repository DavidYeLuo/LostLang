using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class TestItemTypeAddType
{
    [Test]
    public void Test_Initialize_ItemType_With_AddType_To_Rock_ExpectExactly_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.AddType(ItemType.ROCK);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ItemType.ROCK));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Expect_Item_Type_ORE()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        Assert.AreEqual(true, itemType.IsItemType(ItemType.ROCK));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Expect_Item_Type_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        Assert.AreEqual(true, itemType.IsItemType(ItemType.ROCK));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_NotExpect_Exact_Type_Ore()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.ORE));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_NotExpect_Exact_Type_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.ROCK));
    }
}
