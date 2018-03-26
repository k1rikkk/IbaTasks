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
            StringBuilder result = new StringBuilder();
            foreach (char c in val)
                result.Append(char.ToUpper(c));
            return result.ToString();
        }
    }
}
