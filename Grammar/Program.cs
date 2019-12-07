using GrammarSolution.Models;
using GrammarSolution.Services;
using System.Collections.Generic;

namespace GrammarSolution
{
    public class Program
    {
        public static void Main()
        {
            GrammarTerminalOutputService grammarTools = new GrammarTerminalOutputService();

            Grammar grammar_16 = new Grammar
            {
                NonTerminals = new List<Symbol>
                {
                    new Symbol('A'),
                    new Symbol('B'),
                },

                Terminals = new List<Symbol>
                {
                    new Symbol('a'),
                    new Symbol('b'),
                    new Symbol('c'),
                },

                Rules = new List<Rule>
                {
                    new Rule('S', 'A','b'),
                    new Rule('S', 'c'),
                    new Rule('A', 'B','a'),
                    new Rule('B', 'c','S'),
                }
            };

            Grammar grammar_5 = new Grammar
            {
                NonTerminals = new List<Symbol>
                {
                    new Symbol('B'),
                },

                Terminals = new List<Symbol>
                {
                    new Symbol('a'),
                    new Symbol('b'),
                },

                Rules = new List<Rule>
                {
                    new Rule('S', 'a'),
                    new Rule('S', 'B','a'),
                    new Rule('B', 'B','b'),
                    new Rule('B', 'b'),
                }
            };

            grammarTools.ShowTerminalStringOutput(grammar_5);
        }
    }
}
