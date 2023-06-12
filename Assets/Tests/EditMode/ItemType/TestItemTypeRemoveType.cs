using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using NUnit.Framework;

public class TestItemTypeRemoveType
{
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Remove_Rock_Expect_Exactly_Ore()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        itemType.RemoveType(ResourceType.Rock);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ResourceType.Ore));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_RemoveOre_Expect_Exactly_Rock()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        itemType.RemoveType(ResourceType.Ore);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ResourceType.Rock));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_Remove_Rock_Expect_Not_Rock()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        itemType.RemoveType(ResourceType.Rock);
        Assert.AreEqual(false, itemType.IsItemType(ResourceType.Rock));
    }
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_And_AddType_To_Rock_RemoveOre_Expect_Not_Ore()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.AddType(ResourceType.Rock);
        itemType.RemoveType(ResourceType.Ore);
        Assert.AreEqual(false, itemType.IsItemType(ResourceType.Ore));
    }
}
