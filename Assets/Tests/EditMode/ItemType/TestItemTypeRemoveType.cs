using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class TestItemTypeRemoveType
{
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Remove_Rock_Expect_Exactly_Ore()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        itemType.RemoveType(ItemType.ROCK);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.ROCK));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_RemoveOre_Expect_Exactly_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        itemType.RemoveType(ItemType.ORE);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.ORE));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Remove_Rock_Expect_Not_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        itemType.RemoveType(ItemType.ROCK);
        Assert.AreEqual(false, itemType.IsItemType(ItemType.ROCK));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_RemoveOre_Expect_Not_Ore()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        itemType.RemoveType(ItemType.ORE);
        Assert.AreEqual(false, itemType.IsItemType(ItemType.ORE));
    }
}
