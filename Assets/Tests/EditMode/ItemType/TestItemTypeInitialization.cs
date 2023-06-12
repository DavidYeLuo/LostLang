using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using NUnit.Framework;

public class TestItemTypeInitialization
{
    // A Test behaves as an ordinary method
    [Test]
    public void Test_ItemType_Initialization_Should_Not_Be_Metal()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        Assert.AreEqual(false, itemType.IsItemType(ResourceType.Metal));
    }

    [Test]
    public void Test_ItemType_Initializastion_Should_Not_Be_Herb()
    {
        ItemId<ResourceType> itemType = new ItemId<ResourceType>();
        Assert.AreEqual(false, itemType.IsItemType(ResourceType.Herb));
    }
}
