using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using NUnit.Framework;

public class TestItemTypeSetType
{
    // ---------- Tests SetType() ----------
    [Test]
    public void Test_ItemType_Set_Type_To_Ore_Expect_Type_Ore()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ResourceType.Ore));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_Then_To_Rock_Expect_Type_Rock()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.SetType(ResourceType.Rock);
        Assert.AreEqual(true, itemType.IsExactlyItemType(ResourceType.Rock));
    }

    [Test]
    public void Test_ItemType_Set_Type_To_Ore_Then_To_Rock_NotExpect_Type_Ore()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        itemType.SetType(ResourceType.Ore);
        itemType.SetType(ResourceType.Rock);
        Assert.AreEqual(false, itemType.IsExactlyItemType(ResourceType.Ore));
    }
}
