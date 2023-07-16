namespace Interpreter
{
    public abstract class Expr {}

    public class Binary : Expr
    {
        public Expr left;
        public Token op;
        public Expr right;
        public Binary(Expr left, Token op, Expr right)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }
    }

    public class Grouping : Expr
    {
        public Expr expression;
        public Grouping(Expr expression)
        {
            this.expression = expression;
        }
    }

    public class Literal : Expr
    {
        public object value;
        public Literal(object value)
        {
            this.value = value;
        }
    }

    public class Unary : Expr
    {
        public Token op;
        public Expr right;
        public Unary(Token op, Expr right)
        {
            this.op = op;
            this.right = right;
        }
    }
}
