using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class TestItemTypeInitialization
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
        Assert.AreEqual(false, itemType.IsExactlyItemType(ItemType.NULL));
    }
}
