# Logic Calculator

This program is designed to facilitate the evaluation of propositional logic expressions.

**Features:**
- Input Parser: Users can input propositional logic expressions using standard logical operators such as AND (&), OR (|), NOT (!), etc, and parentheses for grouping.
- Truth Table Generation: The program generates a truth table for the input expression, displaying all possible combinations of variable assignments along with the corresponding truth values of the expression.
- Graph View: Visualises a parse tree for the input expression, illustrating its hierarchical structure for better understanding and analysis.
- CNF/DNF Converter: Offers the ability to translate expressions into Conjunctive Normal Form (CNF) or Disjunctive Normal Form (DNF).

## Overview

![image](https://github.com/mohfez/logic-calculator/assets/150836596/b0f914a2-905b-4ad5-bb75-19be78b2bac0)

![image](https://github.com/mohfez/logic-calculator/assets/150836596/7ef7d3e2-2cd1-4bee-88cc-4e0b6fc1f6f9)

Offers flexibility to input expressions using either unicode symbols or simplified notations like !, |, <->, etc.

## Tasks

![image](https://github.com/mohfez/logic-calculator/assets/150836596/91a1d17b-f610-472b-b66d-dbd9884d1a19)

Lets you translate expressions into Conjunctive Normal Form (CNF) or Disjunctive Normal Form (DNF). It also gives the ability to generates comprehensive truth tables and visualises parse trees.

## Results Tab

![image](https://github.com/mohfez/logic-calculator/assets/150836596/b7a57896-0318-4784-b1e2-cc06bffd7aa5)

Displays all recent results into the listbox.

![image](https://github.com/mohfez/logic-calculator/assets/150836596/86e0f832-5cf3-4d82-a4e9-069738e88d34)

Also gives the ability to copy or remove things from the listbox.

![image](https://github.com/mohfez/logic-calculator/assets/150836596/9f66e85f-6cd7-453a-b446-8ebb39167a4b)

Example of simplified notations from before being parsed `(a|b)<->c`.

![image](https://github.com/mohfez/logic-calculator/assets/150836596/4973fef8-ade0-4f3a-8e16-56ba6ec0d595)

Truth table spaced out and organised.

## Graph View (Parse Tree)

![image](https://github.com/mohfez/logic-calculator/assets/150836596/bfea6a1e-82d8-48b7-8db4-de2963b11215)

`Graph View` - A feature which generates a parse tree for the input expression. This graphical representation illustrates the hierarchical structure of the expression, showing how operators and operands are organised.

Using https://github.com/mohfez/winform-graph-visualiser to draw the graphs.
