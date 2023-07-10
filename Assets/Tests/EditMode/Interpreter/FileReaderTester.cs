using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Interpreter;

/// This Tests Tokenizer for:
/// 1) Able to Create Tokens
/// 2) Crate the Right Amount of Tokens

public class TestFileReader
{
    [Test]
    public void Read_Test_File()
    {
        string projectPath = "./Assets/Tests/EditMode/Interpreter/TestData/";
        string fileName = "HelloWorld.dack";
        string path = projectPath + fileName; ;
        StreamReader reader = new StreamReader(path);
        string content = reader.ReadToEnd();

        int fileCharacterSize = 57; // Manually Counted including new line character
        Assert.AreEqual(fileCharacterSize, content.Length);
    }

    [Test]
    public void Test_OpenParenthesis_Token_Size()
    {
        string projectPath = "./Assets/Tests/EditMode/Interpreter/TestData/";
        string fileName = "OneSymbol.dack";
        string path = projectPath + fileName; ;
        StreamReader reader = new StreamReader(path);
        string content = reader.ReadToEnd();

        Tokenizer tokenizer = new Tokenizer(content);

        int answer = 2; // One Open Parenthesis and One EOF
        int size = tokenizer.ScanTokens().Count;

        Assert.AreEqual(answer, size);
    }

    [Test]
    public void Test_Declare_Index_Variable()
    {
        string projectPath = "./Assets/Tests/EditMode/Interpreter/TestData/";
        string fileName = "InitVariable.dack";
        string path = projectPath + fileName; ;
        StreamReader reader = new StreamReader(path);
        string content = reader.ReadToEnd();

        Tokenizer tokenizer = new Tokenizer(content);

        int answer = 5;
        int size = tokenizer.ScanTokens().Count;

        Assert.AreEqual(answer, size);
    }

    [Test]
    public void Test_Declare_Index_Variable_And_End_Variable()
    {
        string projectPath = "./Assets/Tests/EditMode/Interpreter/TestData/";
        string fileName = "InitTwoVariables.dack";
        string path = projectPath + fileName; ;
        StreamReader reader = new StreamReader(path);
        string content = reader.ReadToEnd();

        Tokenizer tokenizer = new Tokenizer(content);

        int answer = 9;
        int size = tokenizer.ScanTokens().Count;

        Assert.AreEqual(answer, size);
    }

    [Test]
    public void Test_Scan_Result_Size()
    {
        string projectPath = "./Assets/Tests/EditMode/Interpreter/TestData/";
        string fileName = "HelloWorld.dack";
        string path = projectPath + fileName; ;
        StreamReader reader = new StreamReader(path);
        string content = reader.ReadToEnd();

        Tokenizer tokenizer = new Tokenizer(content);

        int answer = 21;
        int size = tokenizer.ScanTokens().Count;

        Assert.AreEqual(answer, size);
    }
}

