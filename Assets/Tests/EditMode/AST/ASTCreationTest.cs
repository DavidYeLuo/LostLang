using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Interpreter;
using AST;
using UnityEngine;

public class ASTCreationTest
{
    string outputDir;
    string baseNameAST;
    List<string> typesAST;

    private void Init()
    {
        InitOutputDir();
        InitBaseNameAST();
        InitTypes();
    }
    private void InitOutputDir()
    {
        outputDir = "./Assets/Tests/EditMode/AST/ASTOutput/";
    }
    private void InitBaseNameAST()
    {
        baseNameAST = "ExprTest";
    }
    private void InitTypes()
    {
        typesAST = new List<string>();
        typesAST.Add("Binary   : Expr left, Token op, Expr right");
        typesAST.Add("Grouping : Expr expression");
        typesAST.Add("Literal  : Object value");
        typesAST.Add("Unary    : Token op, Expr right");
    }
    private void AssertCompareFiles(string expectedFilePath, string outputFilePath)
    {
        StreamReader reader = new StreamReader(expectedFilePath);
        string expected = reader.ReadToEnd();
        reader = new StreamReader(outputFilePath);
        string output = reader.ReadToEnd();
        Assert.AreEqual(expected, output);
    }

    [Test]
    public void Test_Printer()
    {
        string expected = "(* (- 123) (group 45.67))";
        string result;

        Expr expression = new Binary(
                new Unary(
                    new Token(TokenType.MINUS, "-", null, 1),
                    new Literal(123)
                ),
                new Token(TokenType.STAR, "*", null, 1),
                new Grouping(
                    new Literal(45.67)
                )
        );
        result = (new ASTPrinter()).Print(expression);

        Assert.AreEqual(expected, result);
    }

    // Only Enable It For Testing because it produces actual .cs file
    // that will likely make compile errors
    // [Test]
    // public void Test_Default_Definition()
    // {
    //     InitOutputDir();
    //     InitBaseNameAST();
    //     typesAST = new List<string>();
    //     typesAST.Add("Binary   : ExprTest left, Token op, ExprTest right");
    //
    //     ASTGenerator generator = new ASTGenerator();
    //     generator.DefineAST(outputDir, baseNameAST, typesAST);
    //
    //     string projectPath = "./Assets/Tests/EditMode/AST";
    //
    //     string outputPath = projectPath + "/ASTOutput/ExprTest.cs";
    //     string expectedResultPath = projectPath + "/ASTExpected/OnlyBinary/ExprTest.test";
    //     AssertCompareFiles(expectedResultPath, outputPath);
    // }
}

