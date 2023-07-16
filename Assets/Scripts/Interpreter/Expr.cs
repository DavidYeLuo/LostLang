namespace Interpreter
{
    public abstract class Expr
    {
        public Expr left;
        public Token op;
        public Expr right;
    }

    public class BinaryExpr : Expr
    {
        public BinaryExpr(Expr left, Token op, Expr right)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }
    }
}
