using GrammarSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrammarSolution.Services
{
    public class GrammarTerminalOutputService
    {
        /// <summary>
        /// Вывод цепочек
        /// </summary>
        public void ShowTerminalStringOutput(Grammar grammar)
        {
            List<Output> outputs = TerminalStringOutputs(grammar);

            Console.WriteLine("Варианты вывода цепочек");

            for (var i = 0; i < outputs.Count; i++)
            {
                Console.WriteLine($"Вывод {i}");
                Console.WriteLine(outputs[i]);
            }
            Console.WriteLine("Вывод окончен");
            Console.ReadLine();
        }

        /// <summary>
        /// Получение цепочек
        /// </summary>
        private List<Output> TerminalStringOutputs(Grammar grammar)
        {
            if (grammar == null) return null;
            if (!HaveStartRule(grammar)) throw new ArgumentException("Грамматика не содержит цеопчку с начальным символом");

            List<Rule> startRules = StartRules(grammar);
            List<Output> allOutputs = new List<Output>();

            foreach (var startRule in startRules)
            {
                Output output = TerminalStringOutput(grammar, startRule);
                allOutputs.Add(output);
            }

            return allOutputs;
        }

        /// <summary>
        /// Получить вариант вывода цепочки
        /// </summary>
        /// <param name="grammar"></param>
        /// <param name="startRule"></param>
        /// <returns></returns>
        private Output TerminalStringOutput(Grammar grammar, Rule startRule)
        {
            //вариант цепочки вывода
            Output output = new Output();

            //стартовый символ
            output.Insert(grammar.StartChain);
            //вывод из стартового правила
            output.Insert(startRule.Chain);

            while (TryAddChain(grammar.Rules, output, 0, 10))
            {
                Console.WriteLine($"Обновлен вывод {output.ToString()}");
                Console.WriteLine();
            }
            return output;
        }

        private bool TryAddChain(List<Rule> rules, Output output, int currentStep, int maxSteps)
        {
            if (currentStep++ >= maxSteps) return false;
            //в выводе есть нетерминальный символ и правило для него?

            Symbol terminalSymbol = output.Chains.LastOrDefault().Symbols.FirstOrDefault(s => s.IsNonTerminal);
            Rule rule = rules.FirstOrDefault(r => r.NonTerminal.Equals(terminalSymbol));

            if (rule != null)
            {
                output.Insert(rule.Chain, terminalSymbol);

                List<Symbol> lastNonTerminals = output.LastOrDefault().Symbols.Where(s => s.IsNonTerminal).ToList();
                List<Symbol> prevNonTerminals = output.Chains
                    .TakeWhile(c => c != output.LastOrDefault())
                    .SelectMany(c => c.Symbols.Where(s => s.IsNonTerminal))
                    .ToList();

                var inersectSymbols = lastNonTerminals.Intersect(prevNonTerminals);
                if (inersectSymbols.Any())
                {
                    Console.WriteLine($"Грамматика имеет бесконечные циклы для нетерминалов {string.Join(" ", inersectSymbols)}");
                    Console.WriteLine($"Вывод прекращен на шаге {currentStep}");
                    currentStep = maxSteps;
                    //Console.WriteLine($"Вывод цепочек будет ограничен через {maxSteps} итераций");
                }
                TryAddChain(rules, output, currentStep, maxSteps);
            }
            return false;
        }


        /// <summary>
        /// Получить правила для начального символа
        /// </summary>
        /// <param name="grammar"></param>
        /// <returns></returns>
        private List<Rule> StartRules(Grammar grammar)
        {
            return grammar.Rules.Where(r => r.NonTerminal.Value == grammar.StartSymbol).ToList();
        }

        private bool HaveStartRule(Grammar grammar)
        {
            return grammar.Rules.Any(r => r.NonTerminal.Value == grammar.StartSymbol);
        }
    }
}
