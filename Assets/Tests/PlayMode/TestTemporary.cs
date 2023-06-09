using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestTemporary
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestTemporaryWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        ReturnsTrueComponent returnsTrueComponent = (new GameObject()).AddComponent<ReturnsTrueComponent>();
        // Use yield to skip a frame.
        yield return null;
        Assert.AreEqual(true, returnsTrueComponent.ReturnTrue());
    }
}
