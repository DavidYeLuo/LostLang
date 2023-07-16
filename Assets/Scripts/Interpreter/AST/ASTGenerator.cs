using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AST
{
    public class ASTGenerator
    {
        // TODO: Refactor
        public void DefineDefaultAST()
        {
            string outputDir = "./Assets/Scripts/Interpreter/AST/";
            List<string> typesAST = new List<string>();
            typesAST.Add("Binary   : Expr left, Token op, Expr right");
            typesAST.Add("Grouping : Expr expression");
            typesAST.Add("Literal  : Object value");
            typesAST.Add("Unary    : Token op, Expr right");
            DefineAST(outputDir, "Expr", typesAST);
        }
        public void DefineAST(string outputDir,
                              string baseName,
                              List<string> types)
        {
            string path = string.Format("{0}/{1}.cs", outputDir, baseName);
            StringBuilder sb = new StringBuilder();
            sb.Append("namespace Interpreter\n{\n");
            sb.AppendFormat("    public abstract class {0} {1}\n", baseName, "{}");
            foreach (string type in types)
            {
                sb.AppendFormat("\n");
                string className = type.Split(":")[0].Trim();
                string fields = type.Split(":")[1].Trim();
                DefineType(sb, baseName, className, fields);
            };
            sb.Append("}\n");
            WriteToFile(path, sb.ToString());
        }

        private void DefineType(StringBuilder sb, string baseName, string className, string fieldList)
        {
            sb.AppendFormat("{0}public class {1} : {2}\n{0}{3}\n", Tab(1), className, baseName, "{");

            string[] fields = fieldList.Split(", ");
            foreach (string field in fields)
            {
                sb.AppendFormat("{0}public {1};\n", Tab(2), field);
            }

            sb.AppendFormat("{0}public {1}({2})\n{0}{3}\n", Tab(2), className, fieldList, "{");
            foreach (string field in fields)
            {
                string name = field.Split(" ")[1];
                sb.AppendFormat("{0}this.{1} = {1};\n", Tab(3), name);
            }
            sb.AppendFormat("{0}{1}\n", Tab(2), "}");
            sb.AppendFormat("{0}{1}\n", Tab(1), "}");
        }

        private string Tab(int num)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Append("    ");
            }
            return sb.ToString();
        }

        private void WriteToFile(string path, string content)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
