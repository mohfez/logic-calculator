using System;
using System.Collections.Generic;

namespace Logic
{
    public class Expression
    {
        public ExpressionType Type { get; }
        public string Atom { get; }
        public Expression Left { get; }
        public Expression Right { get; }

        /// <summary>
        /// Make an atom.
        /// </summary>
        public Expression(string atom)
        {
            Type = ExpressionType.Atom;
            Atom = atom;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Make a tree expression.
        /// </summary>
        public Expression(ExpressionType type, Expression left, Expression right = null)
        {
            if (type == ExpressionType.Atom) throw new Exception("Atoms don't have trees.");
            Type = type;
            Atom = null;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Transform an expression to CNF.
        /// </summary>
        public static Expression ToCNF(Expression expression)
        {
            Expression parsed = NFHelper(expression, true);
            if (expression.Equals(parsed)) return expression;
            else return ToCNF(parsed);
        }

        /// <summary>
        /// Transform an expression to DNF.
        /// </summary>
        public static Expression ToDNF(Expression expression)
        {
            Expression parsed = NFHelper(expression, false);
            if (expression.Equals(parsed)) return expression;
            else return ToDNF(parsed);
        }

        /// <summary>
        /// A helper to transform an expression to either CNF or DNF.
        /// </summary>
        private static Expression NFHelper(Expression expr, bool cnf = true)
        {
            switch (expr.Type)
            {
                case ExpressionType.Atom:
                    return expr;
                case ExpressionType.Not:
                    if (expr.Left.Type == ExpressionType.Not) return expr.Left.Left;
                    if (expr.Left.Type == ExpressionType.Or) return NFHelper(new Expression(ExpressionType.And, new Expression(ExpressionType.Not, expr.Left.Left), new Expression(ExpressionType.Not, expr.Left.Right)));
                    if (expr.Left.Type == ExpressionType.And) return NFHelper(new Expression(ExpressionType.Or, new Expression(ExpressionType.Not, expr.Left.Left), new Expression(ExpressionType.Not, expr.Left.Right)));
                    if (expr.Left.Type == ExpressionType.ImpliesRight) return NFHelper(new Expression(ExpressionType.And, expr.Left.Left, new Expression(ExpressionType.Not, expr.Left.Right)));
                    if (expr.Left.Type == ExpressionType.ImpliesLeft) return NFHelper(new Expression(ExpressionType.And, expr.Left.Right, new Expression(ExpressionType.Not, expr.Left.Left)));
                    if (expr.Left.Type == ExpressionType.Xor) return NFHelper(new Expression(ExpressionType.Equivalent, expr.Left, expr.Right));
                    if (expr.Left.Type == ExpressionType.Equivalent) return NFHelper(new Expression(ExpressionType.Xor, expr.Left, expr.Right));
                    return expr;
                case ExpressionType.Or:
                    if (cnf && expr.Left.Type == ExpressionType.And) return NFHelper(new Expression(ExpressionType.And, new Expression(ExpressionType.Or, expr.Left.Left, expr.Right), new Expression(ExpressionType.Or, expr.Left.Right, expr.Right)));
                    if (cnf && expr.Right.Type == ExpressionType.And) return NFHelper(new Expression(ExpressionType.And, new Expression(ExpressionType.Or, expr.Left, expr.Right.Left), new Expression(ExpressionType.Or, expr.Left, expr.Right.Right)));
                    return new Expression(ExpressionType.Or, NFHelper(expr.Left), NFHelper(expr.Right));
                case ExpressionType.And:
                    if (!cnf && expr.Left.Type == ExpressionType.Or) return NFHelper(new Expression(ExpressionType.Or, new Expression(ExpressionType.And, expr.Left.Left, expr.Right), new Expression(ExpressionType.And, expr.Left.Right, expr.Right)));
                    if (!cnf && expr.Right.Type == ExpressionType.Or) return NFHelper(new Expression(ExpressionType.Or, new Expression(ExpressionType.And, expr.Left, expr.Right.Left), new Expression(ExpressionType.And, expr.Left, expr.Right.Right)));
                    return new Expression(ExpressionType.And, NFHelper(expr.Left), NFHelper(expr.Right));
                case ExpressionType.ImpliesRight:
                    return new Expression(ExpressionType.Or, NFHelper(new Expression(ExpressionType.Not, expr.Left)), NFHelper(expr.Right));
                case ExpressionType.ImpliesLeft:
                    return new Expression(ExpressionType.Or, NFHelper(new Expression(ExpressionType.Not, expr.Right)), NFHelper(expr.Left));
                case ExpressionType.Xor:
                    return new Expression(ExpressionType.And, NFHelper(new Expression(ExpressionType.Or, new Expression(ExpressionType.Not, expr.Left), new Expression(ExpressionType.Not, expr.Right))), NFHelper(new Expression(ExpressionType.Or, expr.Left, expr.Right)));
                case ExpressionType.Equivalent:
                    return new Expression(ExpressionType.And, NFHelper(new Expression(ExpressionType.ImpliesRight, expr.Left, expr.Right)), NFHelper(new Expression(ExpressionType.ImpliesLeft, expr.Left, expr.Right)));
            }

            return expr;
        }

        /// <summary>
        /// Evaluate this expression using a set of valuations.
        /// </summary>
        public bool Evaluate(Dictionary<string, bool> valuations)
        {
            switch (Type)
            {
                case ExpressionType.Atom: return valuations.ContainsKey(Atom) && valuations[Atom];
                case ExpressionType.Not: return !Left.Evaluate(valuations);
                case ExpressionType.Or: return Left.Evaluate(valuations) || Right.Evaluate(valuations);
                case ExpressionType.And: return Left.Evaluate(valuations) && Right.Evaluate(valuations);
                case ExpressionType.ImpliesRight: return !Left.Evaluate(valuations) || Right.Evaluate(valuations);
                case ExpressionType.ImpliesLeft: return !Right.Evaluate(valuations) || Left.Evaluate(valuations);
                case ExpressionType.Equivalent: return Left.Evaluate(valuations) == Right.Evaluate(valuations);
                case ExpressionType.Xor: return Left.Evaluate(valuations) ^ Right.Evaluate(valuations);
            }

            throw new Exception("Invalid expression type.");
        }

        /// <summary>
        /// Is this expression equal to another?
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Expression other = (Expression)obj;

            if (Type != other.Type || Atom != other.Atom) return false;
            if (Left == null && other.Left != null || Left != null && !Left.Equals(other.Left)) return false;
            if (Right == null && other.Right != null || Right != null && !Right.Equals(other.Right)) return false;

            return true;
        }

        /// <summary>
        /// Used for hash tables.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 31 + Type.GetHashCode();
                hash = hash * 31 + (Atom?.GetHashCode() ?? 0);
                hash = hash * 31 + (Left?.GetHashCode() ?? 0);
                hash = hash * 31 + (Right?.GetHashCode() ?? 0);

                return hash;
            }
        }

        /// <summary>
        /// Returns a readable string to represent the expression.
        /// </summary>
        public override string ToString()
        {
            return ShowExpression(this);
        }

        /// <summary>
        /// A helper to transform the expression into a readable format.
        /// </summary>
        private static string ShowExpression(Expression expression)
        {
            switch (expression.Type)
            {
                case ExpressionType.Atom: return expression.Atom;
                case ExpressionType.Not: return "¬" + ShowExpression(expression.Left);
                case ExpressionType.Or: return $"({ShowExpression(expression.Left)} ∨ {ShowExpression(expression.Right)})";
                case ExpressionType.And: return $"({ShowExpression(expression.Left)} ∧ {ShowExpression(expression.Right)})";
                case ExpressionType.ImpliesRight: return $"({ShowExpression(expression.Left)} → {ShowExpression(expression.Right)})";
                case ExpressionType.ImpliesLeft: return $"({ShowExpression(expression.Left)} ← {ShowExpression(expression.Right)})";
                case ExpressionType.Equivalent: return $"({ShowExpression(expression.Left)} ↔ {ShowExpression(expression.Right)})";
                case ExpressionType.Xor: return $"({ShowExpression(expression.Left)} ⊕  {ShowExpression(expression.Right)})";
            }

            throw new Exception("Invalid expression type.");
        }
    }
}