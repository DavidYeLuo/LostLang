using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class TestItemTypes
{
    // A Test behaves as an ordinary method
    [Test]
    public void Test_ItemType_Initialization_Should_Be_Type_Null()
    {
        ItemType itemType = new ItemType();
        Assert.AreEqual(true, itemType.IsExactlyItemType(ItemType.NULL));
    }

    [Test]
    public void Test_ItemType_AfterInitializastion_Should_be_NotNull()
    {
        ItemType itemType = new ItemType();
        itemType.AddType(ItemType.ROCK);
        Assert.AreEqual(true, itemType.IsItemType(ItemType.NULL));
    }

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

    // ---------- Tests AddType() ----------
    [Test]
    public void Test_Initialize_ItemType_With_AddType_To_Rock_ExpectExactly_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.AddType(ItemType.ROCK);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ItemType.ROCK | ItemType.NOT_NULL));
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

    // ---------- Tests RemoveType() ----------
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Remove_Rock_Expect_Exactly_Ore()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        itemType.RemoveType(ItemType.ROCK);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.ROCK | ItemType.NOT_NULL));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_RemoveOre_Expect_Exactly_Rock()
    {
        ItemType itemType = new ItemType();
        itemType.SetType(ItemType.ORE);
        itemType.AddType(ItemType.ROCK);
        itemType.RemoveType(ItemType.ORE);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.ORE | ItemType.NOT_NULL));
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
