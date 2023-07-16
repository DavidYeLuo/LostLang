using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Interpreter;
using UnityEngine;

/// This Tests Tokenizer for:
/// 1) Able to Create Tokens
/// 2) Crate the Right Amount of Tokens

public class TestErrorHandler
{
    [Test]
    public void TestNoError()
    {
        ErrorHandler handler = new ErrorHandler();
        Assert.AreEqual(false, handler.IsError());
    }

    [Test]
    public void TestError()
    {
        ErrorHandler handler = new ErrorHandler();
        Debug.Log("[Unit Test] Begin Error() test.");
        handler.Error(0, "Test working properly.");
        Debug.Log("[Unit Test] End Error() test.");
        Assert.AreEqual(true, handler.IsError());
    }
    [Test]
    public void TestReport()
    {
        ErrorHandler handler = new ErrorHandler();
        Debug.Log("[Unit Test] Begin Report() test.");
        handler.Report(0, "TestWorkingFine()", "Test working properly.");
        Debug.Log("[Unit Test] End Report() test.");
        Assert.AreEqual(true, handler.IsError());
    }
}

