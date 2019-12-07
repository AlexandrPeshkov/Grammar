using System.Collections.Generic;
using System.Linq;

namespace GrammarSolution.Models
{
    public class Output
    {
        private readonly string _arrow = " -> ";

        public List<Chain> Chains { get; set; }

        private string StringView => string.Join(_arrow, Chains);

        public Output()
        {
            Chains = new List<Chain>();
        }

        public void Insert(Chain chain, Symbol forReplace = null)
        {
            Chain newChain = Chains.LastOrDefault()?.Clone() as Chain;
            List<Symbol> symbols = newChain?.Symbols;

            if (symbols != null && symbols.Any() && forReplace != null)
            {
                foreach (var symbol in symbols.ToList())
                {
                    if (symbol.Equals(forReplace))
                    {
                        int index = symbols.LastIndexOf(symbol);
                        symbols.InsertRange(index, chain.Symbols);
                        symbols.Remove(symbol);
                        newChain = new Chain(symbols);
                    }
                    break;
                }
            }
            else
            {
                newChain = chain;
            }
            Chains.Add(newChain);
        }

        public Chain LastOrDefault()
        {
            return Chains.LastOrDefault();
        }

        public override string ToString()
        {
            return StringView;
        }
    }
}
