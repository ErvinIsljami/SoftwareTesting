using OTS2019_ConvertorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2019_ConvertorDemo
{
    public class CustomMoneyConvertor : IMoneyConvertor
    {
        public char inputSymbol;
        public char outputSymbol;
        public string inputAmount;

        public CustomMoneyConvertor(string input)
        {
            try
            {
                string[] symbols = input.Split(' ');
                outputSymbol = Char.Parse(symbols[2]);
                string inputString = symbols[0];
                inputSymbol = inputString[inputString.Length - 1];

                for (int i = 0; i < inputString.Length - 1; i++)
                {
                    inputAmount += inputString[i];
                }
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        public decimal Convert(decimal input)
        {
            if (inputSymbol == '$')
            {
                return input * 0.89M;
            }
            else if (inputSymbol == '€')
            {
                if (outputSymbol == '$')
                {
                    return input / 0.89M;
                }
                else if (outputSymbol == '£')
                {
                    return input * 0.86M;
                }
            }
            else if (inputSymbol == '£')
            {
                return input / 0.86M;
            }
            return 0;
        }
    }
}
