using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_7
{
    public class PostfixExpressions
    {
        private DoubleConnectedStack<char> W = new DoubleConnectedStack<char>();
        private DoubleConnectedStack<double> Q =  new DoubleConnectedStack<double>();

        public PostfixExpressions() { }
        public double Calculate(string input)
        {
            string output = GetExpression(input); 
            double result = Counting(output); 
            return result; 
        }
        private int GetPriority(char s)
        {
            switch(s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

        private bool IsDelimeter(char c)
        {
            if((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        private bool IsOperator(char с)
        {
            if(("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }

        private string GetExpression(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if(IsDelimeter(input[i]))
                    continue;

                if(Char.IsDigit(input[i]))
                {

                    while(!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;
                        if(i == input.Length) break;
                    }
                    output += " ";
                    i--;
                }

                if(IsOperator(input[i]))
                {
                    if(input[i] == '(')
                        W.Push(input[i]);
                    else if(input[i] == ')')
                    {
                        char s = W.Pop();
                        while(s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = W.Pop();
                        }
                    }
                    else
                    {
                        if(W.Count > 0)
                            if(GetPriority(input[i]) <= GetPriority(W.Peek()))
                                output += W.Pop().ToString() + " ";
                        W.Push(char.Parse(input[i].ToString()));
                    }
                }     
            }
            while (W.Count > 0)
                output += W.Pop() + " ";
            return output;
        }
        private double Counting(string input)
        {
            double result = 0; 
            for(int i = 0; i < input.Length; i++)
            {
                if(Char.IsDigit(input[i]))
                {
                    string a = "";
                    while(!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if(i == input.Length) break;
                    }
                    Q.Push(double.Parse(a)); 
                    i--;
                }
                else if (IsOperator(input[i])) 
                {
                    double a = Q.Pop();
                    double b = Q.Pop();
                    switch(input[i]) 
                    {
                        case '+': 
                            result = b + a;
                            break;
                        case '-': 
                            result = b - a;
                            break;
                        case '*': 
                            result = b * a;
                            break;
                        case '/': 
                            result = b / a;
                            break;
                        case '^': 
                            result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString());
                            break;
                    }
                    Q.Push(result); 
                }
            }
            return Q.Peek(); 
        }




    }
}
