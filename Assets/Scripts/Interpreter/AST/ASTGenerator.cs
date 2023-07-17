using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AST
{
    public class ASTGenerator
    {
        // TODO: Refactor
        public string DefineDefaultAST()
        {
            string outputDir = "./Assets/Scripts/Interpreter/AST/";
            List<string> typesAST = new List<string>();
            typesAST.Add("Binary   : Expr left, Token op, Expr right");
            typesAST.Add("Grouping : Expr expression");
            typesAST.Add("Literal  : object value");
            typesAST.Add("Unary    : Token op, Expr right");
            DefineAST(outputDir, "Expr", typesAST);

            return outputDir;
        }
        public void DefineAST(string outputDir,
                              string baseName,
                              List<string> types)
        {
            string path = string.Format("{0}/{1}.cs", outputDir, baseName);
            StringBuilder sb = new StringBuilder();
            sb.Append("namespace Interpreter\n{\n");
            int startIndent = 1;
            DefineVisitorClass(sb, startIndent, baseName, types);
            sb.AppendLine();
            DefineBaseAbstractClass(sb, startIndent, baseName, types);
            foreach (string type in types)
            {
                sb.AppendFormat("\n");
                string className = type.Split(":")[0].Trim();
                string fields = type.Split(":")[1].Trim();

                sb.AppendFormat("{0}public class {1} : {2}\n{0}{3}\n", Tab(startIndent), className, baseName, "{");
                DefineType(sb, baseName, className, fields, startIndent + 1);
                sb.AppendLine();
                ImplementVisitor(sb, className, baseName, startIndent + 1);
                sb.AppendFormat("{0}{1}\n", Tab(startIndent), "}");
            };
            sb.Append("}\n");
            WriteToFile(path, sb.ToString());
        }

        private void DefineBaseAbstractClass(StringBuilder sb, int startIndent, string baseName, List<string> types)
        {
            sb.AppendFormat("{0}public abstract class {1}\n{0}{2}\n", Tab(startIndent), baseName, "{");
            sb.AppendFormat("{0}public abstract R Accept<R>(Visitor<R> visitor);\n", Tab(startIndent + 1));
            sb.AppendFormat("{0}{1}\n", Tab(startIndent), "}");
        }

        private void DefineVisitorClass(StringBuilder sb, int startIndent, string baseName, List<string> types)
        {
            sb.AppendFormat("{0}public interface Visitor<R>\n{0}{1}\n", Tab(startIndent), "{");
            foreach (string type in types)
            {
                string typeName = type.Split(":")[0].Trim();
                sb.AppendFormat("{0}public abstract R Visit{1}{2}({1} {3});\n", Tab(startIndent + 1), typeName, baseName, baseName.ToLower());
            }
            sb.AppendFormat("{0}{1}\n", Tab(startIndent), "}");
        }

        private void DefineType(StringBuilder sb, string baseName, string className, string fieldList, int startIndent)
        {
            string[] fields = fieldList.Split(", ");
            foreach (string field in fields)
            {
                sb.AppendFormat("{0}public {1};\n", Tab(startIndent), field);
            }

            sb.AppendLine();
            sb.AppendFormat("{0}public {1}({2})\n{0}{3}\n", Tab(startIndent), className, fieldList, "{");
            foreach (string field in fields)
            {
                string name = field.Split(" ")[1];
                sb.AppendFormat("{0}this.{1} = {1};\n", Tab(startIndent + 1), name);
            }
            sb.AppendFormat("{0}{1}\n", Tab(startIndent), "}");
        }

        private void ImplementVisitor(StringBuilder sb, string className, string baseName, int startIndent)
        {
            sb.AppendFormat("{0}public override R Accept<R>(Visitor<R> visitor)\n{0}{1}\n", Tab(startIndent), "{");
            sb.AppendFormat("{0}return visitor.Visit{1}{2}(this);\n", Tab(startIndent + 1), className, baseName);
            sb.AppendFormat("{0}{1}\n", Tab(startIndent), "}");
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
