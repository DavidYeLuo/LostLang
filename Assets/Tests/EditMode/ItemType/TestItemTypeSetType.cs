using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class TestItemTypeSetType
{
    // ---------- Tests SetType() ----------
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_Expect_Type_Ore()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ItemType.ORE));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_Then_To_Rock_Expect_Type_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.SetType(ItemType.ROCK);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ItemType.ROCK));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_Then_To_Rock_NotExpect_Type_Ore()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.SetType(ItemType.ROCK);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.ORE));
    }
}
