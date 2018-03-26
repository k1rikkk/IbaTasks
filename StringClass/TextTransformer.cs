using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringClass
{
    public class TextTransformer
    {
        public const string Null = "UNSET";
        protected string val;

        public TextTransformer(string s) => val = s;

        public string Process()
        {
            if (string.IsNullOrEmpty(val))
                return Null;
            string result = "";
            foreach (char c in val)
                result += char.ToUpper(c);
            return result;
        }
    }
}
