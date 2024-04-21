using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class TruthTable
    {
        /// <summary>
        /// Generate a truth table for an expression.
        /// </summary>
        public static (List<string> header, List<List<bool>> rows) Generate(Expression expression)
        {
            Dictionary<string, bool> atoms = new Dictionary<string, bool>();
            List<Dictionary<string, bool>> preRows = new List<Dictionary<string, bool>>();
            List<List<bool>> postRows = new List<List<bool>>();

            GetAtoms(expression, atoms);
            GenerateRows(atoms, new Dictionary<string, bool>(), preRows);

            List<string> header = atoms.Keys.ToList();
            header.Add(expression.ToString());

            foreach (Dictionary<string, bool> row in preRows)
            {
                List<bool> rowValues = atoms.Keys.Select(atom => row[atom]).ToList();
                rowValues.Add(expression.Evaluate(row));
                postRows.Add(rowValues);
            }

            return (header, postRows);
        }

        /// <summary>
        /// A helper to get all the atoms in an expression.
        /// </summary>
        private static void GetAtoms(Expression expression, Dictionary<string, bool> atoms)
        {
            if (expression.Type == ExpressionType.Atom)
            {
                if (!atoms.ContainsKey(expression.Atom)) atoms.Add(expression.Atom, false);
            }
            else
            {
                GetAtoms(expression.Left, atoms);
                if (expression.Type != ExpressionType.Not) GetAtoms(expression.Right, atoms);
            }
        }

        /// <summary>
        /// A helper to generate truth table rows.
        /// </summary>
        private static void GenerateRows(Dictionary<string, bool> atoms, Dictionary<string, bool> currentRow, List<Dictionary<string, bool>> rows)
        {
            if (currentRow.Count == atoms.Count)
            {
                rows.Add(new Dictionary<string, bool>(currentRow));
                return;
            }

            var remainingAtoms = atoms.Keys.Except(currentRow.Keys).ToList();
            var atom = remainingAtoms.First();

            currentRow.Add(atom, true);
            GenerateRows(atoms, currentRow, rows);
            currentRow[atom] = false;
            GenerateRows(atoms, currentRow, rows);

            currentRow.Remove(atom);
        }
    }
}