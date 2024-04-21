using GraphViewer;
using GraphViewer.TreeGraph;
using Logic;
using System.Collections.Generic;

namespace logic_calculator
{
    public static class GraphHelper
    {
        private static readonly Dictionary<ExpressionType, string> Operators = new Dictionary<ExpressionType, string>
        {
            { ExpressionType.Not, "¬" },
            { ExpressionType.Or, "∨" },
            { ExpressionType.And , "∧" },
            { ExpressionType.Equivalent , "↔" },
            { ExpressionType.ImpliesRight , "→" },
            { ExpressionType.ImpliesLeft , "←" },
            { ExpressionType.Xor , "⊕" }
        };

        public static TreeGraphNode ListGraph(GraphView graphViewer, Expression expression)
        {
            Queue<Expression> queue = new Queue<Expression>();
            queue.Enqueue(expression);

            TreeGraphNode root = new TreeGraphNode(expression.Type == ExpressionType.Atom ? expression.Atom : Operators[expression.Type]);
            Queue<TreeGraphNode> treeNodeQueue = new Queue<TreeGraphNode>();
            treeNodeQueue.Enqueue(root);

            while (queue.Count > 0)
            {
                Expression currentExpression = queue.Dequeue();
                TreeGraphNode currentNode = treeNodeQueue.Dequeue();

                if (currentExpression.Left != null)
                {
                    TreeGraphNode leftChild = new TreeGraphNode(currentExpression.Left.Type == ExpressionType.Atom ? currentExpression.Left.Atom : Operators[currentExpression.Left.Type]);
                    currentNode.left = leftChild;

                    queue.Enqueue(currentExpression.Left);
                    treeNodeQueue.Enqueue(leftChild);
                }

                if (currentExpression.Right != null)
                {
                    TreeGraphNode rightChild = new TreeGraphNode(currentExpression.Right.Type == ExpressionType.Atom ? currentExpression.Right.Atom : Operators[currentExpression.Right.Type]);
                    currentNode.right = rightChild;

                    queue.Enqueue(currentExpression.Right);
                    treeNodeQueue.Enqueue(rightChild);
                }
            }

            TreeGraphBase.MakeTree(root, graphViewer);
            return root;
        }
    }
}
