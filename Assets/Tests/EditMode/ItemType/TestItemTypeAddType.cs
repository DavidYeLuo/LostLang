using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using NUnit.Framework;

public class TestItemTypeAddType
{
    [Test]
    public void Test_Initialize_ItemType_With_AddType_To_Rock_ExpectExactly_Rock()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.AddType(ResourceType.Rock);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ResourceType.Rock));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Expect_Item_Type_ORE()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        Assert.AreEqual(true, itemType.IsItemType(ResourceType.Ore));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Expect_Item_Type_Rock()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        Assert.AreEqual(true, itemType.IsItemType(ResourceType.Rock));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_NotExpect_Exact_Type_Ore()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ResourceType.Ore));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_NotExpect_Exact_Type_Rock()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ResourceType.Rock));
    }
}
