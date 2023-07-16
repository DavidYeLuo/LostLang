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
            string path = generator.DefineDefaultAST();
            Debug.LogFormat("Generated Definition at: {0}\n", path);
        }
    }
}
