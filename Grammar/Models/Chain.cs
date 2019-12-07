using System;
using System.Collections.Generic;
using System.Linq;

namespace GrammarSolution.Models
{
    /// <summary>
    /// Цепочка
    /// </summary>
    public class Chain : ICloneable
    {
        public List<Symbol> Symbols { get; private set; }

        public Chain(List<Symbol> symbols)
        {
            Symbols = symbols;
        }

        public Chain(params char[] symbols)
        {
            Symbols = new List<Symbol>();
            foreach (var symbol in symbols)
            {
                Symbols.Add(new Symbol(symbol));
            }
        }

        public override string ToString()
        {
            return string.Join("", Symbols.Select(s => s.Value));
        }

        public object Clone()
        {
            List<Symbol> symbols = new List<Symbol>();
            foreach(var symbol in Symbols)
            {
                symbols.Add(new Symbol(symbol.Value));
            }
            return new Chain(symbols);
        }
    }
}
