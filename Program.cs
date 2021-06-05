using System;
using System.Collections.Generic;


namespace Algorithms_lab_8
{
    class Program
    {
        static void Main(string[] args)
        {

            String ReplaceFirst(String input, String from, String to)
            {
                var index = input.IndexOf(from);
                return input.Remove(index, from.Length).Insert(index, to);
            }

            List<Rule> Rules = new List<Rule>();
            Rules.Add(new Rule("*a", "aA*", false));
            Rules.Add(new Rule("*b", "bB*", false));
            Rules.Add(new Rule("*", "#", false));
            Rules.Add(new Rule("Aa", "aA", false));
            Rules.Add(new Rule("Ab", "bA", false));
            Rules.Add(new Rule("Ba", "aB", false));
            Rules.Add(new Rule("Bb", "bB", false));
            Rules.Add(new Rule("A#", "#a", false));
            Rules.Add(new Rule("B#", "#b", false));
            Rules.Add(new Rule("#", "", true));
            Rules.Add(new Rule("", "*", false));

            Console.WriteLine("Правила:");
            foreach (Rule rule in Rules)
            {
                Console.WriteLine("{0} -> {1}", rule.From, rule.To);
            }

            Console.WriteLine("");

            String input = Console.ReadLine();
            int flag = 1;
            while (flag != 0)
            {
                flag = 0;
                foreach (Rule rule in Rules)
                {
                    if (rule.From == "")
                    {
                        flag++;
                        input = rule.To + input;
                        Console.WriteLine(input);
                        if (rule.Last == true && flag == 1)
                            flag = 0;
                        break;
                    }
                    else if (input.Contains(rule.From))
                    {
                        flag++;
                        input = ReplaceFirst(input, rule.From, rule.To);
                        Console.WriteLine(input);
                        if (rule.Last == true && flag == 1)
                            flag = 0;
                        break;
                    }
                }
            }



        }
    }
}
