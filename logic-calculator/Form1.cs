using GraphViewer.TreeGraph;
using Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace logic_calculator
{
    public partial class Form1 : Form
    {
        private bool showingTruthTable = false;
        private TreeGraphNode currRoot = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            taskDropdown.SelectedIndex = 0;
        }

        private void AppendText(string txt)
        {
            int selectionStart = expressionTxtBox.SelectionStart;
            int selectionLength = expressionTxtBox.SelectionLength;

            expressionTxtBox.Text = expressionTxtBox.Text.Insert(selectionStart, txt);
            expressionTxtBox.Select(selectionStart + txt.Length, selectionLength);
            expressionTxtBox.Focus();
        }

        private void notBtn_Click(object sender, EventArgs e) => AppendText("¬");
        private void orBtn_Click(object sender, EventArgs e) => AppendText("∨");
        private void andBtn_Click(object sender, EventArgs e) => AppendText("∧");
        private void impliesRbtn_Click(object sender, EventArgs e) => AppendText("→");
        private void impliesLBtn_Click(object sender, EventArgs e) => AppendText("←");
        private void equivBtn_Click(object sender, EventArgs e) => AppendText("↔");
        private void xorBtn_Click(object sender, EventArgs e) => AppendText("⊕");

        private void clrBtn_Click(object sender, EventArgs e) => expressionTxtBox.Clear();
        private void execBtn_Click(object sender, EventArgs e)
        {
            // pre-processor
            string execStr = expressionTxtBox.Text.Replace("¬", "!").Replace("∨", "|").Replace("∧", "&").Replace("→", "->").Replace("←", "<-").Replace("↔", "<->").Replace("⊕", "+");

            switch (taskDropdown.SelectedIndex)
            {
                case 0: // cnf
                    try
                    {
                        Expression parsed = Parser.ParseExpression(execStr);
                        Expression cnf = Expression.ToCNF(parsed);
                        ShowResPage();
                        resListBox.Items.Add($"{parsed} to CNF:\t {cnf}");
                    }
                    catch (Exception exc) { MessageBox.Show(exc.Message, "Error"); }
                    break;
                case 1: // dnf
                    try
                    {
                        Expression parsed = Parser.ParseExpression(execStr);
                        Expression dnf = Expression.ToDNF(parsed);
                        ShowResPage();
                        resListBox.Items.Add($"{parsed} to DNF:\t {dnf}");
                    }
                    catch (Exception exc) { MessageBox.Show(exc.Message, "Error"); }
                    break;
                case 2: // truth table
                    try
                    {
                        Expression parsed = Parser.ParseExpression(execStr);
                        (List<string> header, List<List<bool>> rows) = TruthTable.Generate(parsed);

                        resListBox.BeginUpdate();
                        try
                        {
                            ShowResPage();
                            showingTruthTable = true;
                            resListBox.Items.Add($"Truth Table for {parsed}");
                            resListBox.Items.Add(string.Join("\t", header));

                            int batchSize = 100;
                            for (int i = 0; i < rows.Count && showingTruthTable; i += batchSize)
                            {
                                int count = Math.Min(batchSize, rows.Count - i);
                                for (int j = 0; j < count && showingTruthTable; j++)
                                {
                                    resListBox.Items.Add(string.Join("\t", rows[i + j]));
                                }

                                Application.DoEvents();
                            }
                        }
                        finally
                        {
                            resListBox.EndUpdate();
                        }
                    }
                    catch (Exception exc) { MessageBox.Show(exc.Message, "Error"); }
                    break;
                case 3: // graph view
                    try
                    {
                        Expression parsed = Parser.ParseExpression(execStr);
                        currRoot = GraphHelper.ListGraph(graphViewer, parsed);
                        tabsControl.SelectTab(2);
                    }
                    catch (Exception exc) { MessageBox.Show(exc.Message, "Error"); }
                    break;
            }

            void ShowResPage()
            {
                showingTruthTable = false;
                resListBox.Items.Clear();
                tabsControl.SelectTab(1);
            }
        }

        private void locatebtn_Click(object sender, EventArgs e)
        {
            if (currRoot != null) TreeGraphBase.GoHome(currRoot, graphViewer);
        }

        private void resListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = resListBox.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    resListBox.SelectedIndex = index;
                    resListBoxMenu.Show(resListBox.PointToScreen(e.Location));
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resListBox.SelectedIndex == ListBox.NoMatches) return;
            Clipboard.SetText(resListBox.SelectedItem.ToString());
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resListBox.SelectedIndex == ListBox.NoMatches) return;
            resListBox.Items.RemoveAt(resListBox.SelectedIndex);
        }
    }
}
