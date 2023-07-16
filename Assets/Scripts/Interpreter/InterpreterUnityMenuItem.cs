using UnityEditor;
using UnityEngine;
using AST;
namespace Interpreter
{
    public class MenuItemTemp : MonoBehaviour
    {
        [MenuItem("Interpreter/AST/Helper/DefineAST")]
        private static void DefineAST()
        {
            ASTGenerator generator = new ASTGenerator();
            generator.DefineDefaultAST();
            Debug.Log("Defining AST");
        }
    }
}
