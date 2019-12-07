namespace GrammarSolution.Models
{
    public class Rule
    {
        /// <summary>
        /// Метасимвол
        /// </summary>
        public Symbol NonTerminal { get; private set; }

        /// <summary>
        /// Цепочка
        /// </summary>
        public Chain Chain { get; private set; }

        public Rule(Symbol nonTerminal, Chain chain) => (NonTerminal, Chain) = (nonTerminal, chain);

        public Rule(char nonTerminal, params char[] chain)
        {
            NonTerminal = new Symbol(nonTerminal);
            Chain = new Chain(chain);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
