using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Logic
{
    public static class Parser
    {
        private static readonly Dictionary<string, ExpressionType> Operators = new Dictionary<string, ExpressionType>
        {
            { "!", ExpressionType.Not },
            { "|", ExpressionType.Or },
            { "&", ExpressionType.And },
            { "<->", ExpressionType.Equivalent },
            { "->", ExpressionType.ImpliesRight },
            { "<-", ExpressionType.ImpliesLeft },
            { "+", ExpressionType.Xor }
        };

        /// <summary>
        /// Parses input into an expression.
        /// </summary>
        public static Expression ParseExpression(string input)
        {
            input = input.Replace(" ", "").Replace("\n", "");
            Stack<Expression> expressionStack = new Stack<Expression>();
            Stack<ExpressionType> operatorStack = new Stack<ExpressionType>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(') operatorStack.Push(ExpressionType.Atom);
                else if (input[i] == ')')
                {
                    while (operatorStack.Peek() != ExpressionType.Atom)
                    {
                        ExpressionType op = operatorStack.Pop();
                        if (op == ExpressionType.Not)
                        {
                            if (expressionStack.Count == 0) throw new Exception("Invalid expression.");
                            Expression operand = expressionStack.Pop();
                            expressionStack.Push(new Expression(op, operand));
                        }
                        else
                        {
                            if (expressionStack.Count < 2) throw new Exception("Invalid expression.");
                            Expression right = expressionStack.Pop();
                            Expression left = expressionStack.Pop();
                            expressionStack.Push(new Expression(op, left, right));
                        }
                    }

                    operatorStack.Pop();
                }
                else if (GetOperator(input, i, out ExpressionType operType, out int operLen))
                {
                    if (operType == ExpressionType.Not)
                    {
                        if (i + 1 >= input.Length || input[i + 1] == ')') throw new Exception("Invalid expression.");
                        operatorStack.Push(operType);
                    }
                    else
                    {
                        while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(operType))
                        {
                            ExpressionType op = operatorStack.Pop();
                            if (op == ExpressionType.Not)
                            {
                                if (expressionStack.Count == 0) throw new Exception("Invalid expression.");
                                Expression operand = expressionStack.Pop();
                                expressionStack.Push(new Expression(op, operand));
                            }
                            else
                            {
                                if (expressionStack.Count < 2) throw new Exception("Invalid expression.");
                                Expression right = expressionStack.Pop();
                                Expression left = expressionStack.Pop();
                                expressionStack.Push(new Expression(op, left, right));
                            }
                        }

                        operatorStack.Push(operType);
                    }

                    i += operLen - 1;
                }
                else
                {
                    string atom = input[i].ToString();
                    while (i + 1 < input.Length && !GetOperator(input, i + 1, out _, out _) && input[i + 1] != ')')
                    {
                        atom += input[i + 1];
                        i++;
                    }

                    if (!Regex.IsMatch(atom, "^(?![0-9_\\-])[a-zA-Z0-9_\\-]+$")) throw new Exception("Invalid atom.");
                    expressionStack.Push(new Expression(atom));
                }
            }
            
            while (operatorStack.Count > 0)
            {
                ExpressionType op = operatorStack.Pop();
                if (op == ExpressionType.Not)
                {
                    if (expressionStack.Count == 0) throw new Exception("Invalid expression.");
                    Expression operand = expressionStack.Pop();
                    expressionStack.Push(new Expression(op, operand));
                }
                else
                {
                    if (expressionStack.Count < 2) throw new Exception("Invalid expression.");
                    Expression right = expressionStack.Pop();
                    Expression left = expressionStack.Pop();
                    expressionStack.Push(new Expression(op, left, right));
                }
            }

            if (expressionStack.Count != 1 || operatorStack.Count != 0) throw new Exception("Invalid expression.");
            return expressionStack.Pop();
        }

        /// <summary>
        /// A helper to get the next operator in a string.
        /// </summary>
        private static bool GetOperator(string input, int index, out ExpressionType operType, out int operLen)
        {
            IOrderedEnumerable<KeyValuePair<string, ExpressionType>> ordered = Operators.OrderByDescending(kv => kv.Key.Length);
            string longestSubstr = input.Substring(index, Math.Min(ordered.First().Key.Length, input.Length - index));

            foreach (KeyValuePair<string, ExpressionType> kv in ordered)
            {
                if (longestSubstr.StartsWith(kv.Key))
                {
                    operType = kv.Value;
                    operLen = kv.Key.Length;
                    
                    return true;
                }
            }

            operType = ExpressionType.Atom;
            operLen = -1;
            return false;
        }

        /// <summary>
        /// A helper to check which operator is higher priority.
        /// </summary>
        private static int Precedence(ExpressionType op)
        {
            switch (op)
            {
                case ExpressionType.Not: return 6;
                case ExpressionType.Or: return 5;
                case ExpressionType.And: return 4;
                case ExpressionType.Equivalent: return 3;
                case ExpressionType.ImpliesLeft: return 2;
                case ExpressionType.ImpliesRight: return 1;
                case ExpressionType.Xor: return 0;
            }
            
            return -1;
        }
    }
}