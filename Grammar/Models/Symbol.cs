namespace GrammarSolution.Models
{
    public class Symbol
    {
        /// <summary>
        /// Символ
        /// </summary>
        public char Value { get; private set; }

        /// <summary>
        /// Метасимвол?
        /// </summary>
        public bool IsNonTerminal => char.IsUpper(Value);

        public Symbol(char value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Symbol symbol)
            {
                return this.Value == symbol.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
