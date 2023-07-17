namespace Interpreter
{
    public interface Visitor<R>
    {
        public abstract R VisitBinaryExpr(Binary expr);
        public abstract R VisitGroupingExpr(Grouping expr);
        public abstract R VisitLiteralExpr(Literal expr);
        public abstract R VisitUnaryExpr(Unary expr);
    }

    public abstract class Expr
    {
        public abstract R Accept<R>(Visitor<R> visitor);
    }

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

        public override R Accept<R>(Visitor<R> visitor)
        {
            return visitor.VisitBinaryExpr(this);
        }
    }

    public class Grouping : Expr
    {
        public Expr expression;

        public Grouping(Expr expression)
        {
            this.expression = expression;
        }

        public override R Accept<R>(Visitor<R> visitor)
        {
            return visitor.VisitGroupingExpr(this);
        }
    }

    public class Literal : Expr
    {
        public object value;

        public Literal(object value)
        {
            this.value = value;
        }

        public override R Accept<R>(Visitor<R> visitor)
        {
            return visitor.VisitLiteralExpr(this);
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

        public override R Accept<R>(Visitor<R> visitor)
        {
            return visitor.VisitUnaryExpr(this);
        }
    }
}
