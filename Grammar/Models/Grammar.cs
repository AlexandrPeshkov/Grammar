using System.Collections.Generic;

namespace GrammarSolution.Models
{
    /// <summary>
    /// Грамматика
    /// </summary>
    public class Grammar
    {
        /// <summary>
        /// Невыводимые символы
        /// </summary>
        public List<Symbol> Terminals { get; set; }

        /// <summary>
        /// Начальные метасимволы
        /// </summary>
        public List<Symbol> NonTerminals { get; set; }

        /// <summary>
        /// Правила
        /// </summary>
        public List<Rule> Rules { get; set; }

        /// <summary>
        /// Начальный символ
        /// </summary>
        public char StartSymbol { get; set; }

        public Chain StartChain { get; private set; }

        public Grammar(List<Symbol> terminals = null, List<Symbol> nonTerminals = null, List<Rule> rules = null, char startSymbol = 'S')
        {
            Terminals = terminals ?? new List<Symbol>();
            NonTerminals = nonTerminals ?? new List<Symbol>();
            Rules = rules ?? new List<Rule>();
            StartSymbol = startSymbol;
            StartChain = new Chain(new List<Symbol> { new Symbol(StartSymbol) });
        }
    }
}
