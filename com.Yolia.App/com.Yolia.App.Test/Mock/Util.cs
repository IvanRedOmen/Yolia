using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Test.Mock
{
    public class Util
    {
        private static Random rand = new Random();
        public static string GenerateWord(int maxChars)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= maxChars; i++)
            {
                int randNumber = rand.Next(97, 122);
                sb.Append((char)randNumber);
            }
            return sb.ToString();
        }

        public static int GenerateNumber(int maxChar)
        {
            StringBuilder sb = new StringBuilder();
            int randoNumber = 0;
            for (int i = 0; i <= maxChar; i++)
            {
                randoNumber = rand.Next(0, 9);
                sb.Append(randoNumber);
            }
            int cadNumero = Int32.Parse(sb.ToString());
            return cadNumero;
        }

        public static string GenerateMail()
        {
            return GenerateWord(5) + "@" + GenerateWord(5) + ".com";
        }
    
    }
}
