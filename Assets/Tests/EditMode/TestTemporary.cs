using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestTemporary
{
    // A Test behaves as an ordinary method
    [Test]
    public void Call_Function_Expect_True()
    {
        // Use the Assert class to test conditions
        ReturnsTrue returnsTrue = new ReturnsTrue();
        Assert.AreEqual(true, returnsTrue.ReturnTrue());
    }
}
