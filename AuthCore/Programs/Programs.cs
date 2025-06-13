using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections.Generic;

namespace ShoppyWeb.Programs
{
    public class Programs
    {
        public Programs() {
         
        }
        public string Reverse(string inputString)
        {
            //How to reverse a string? input: hello, output: olleh
            string outputString = null;
            char[] chars = inputString.ToCharArray();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                outputString += chars[i];
            }
            return outputString;
        }
        //palindrome 
        public string palindrome(string inputString)
        {
            string outputString = null, responseText = null;
            char[] chars = inputString.ToCharArray();
            for (int i =chars.Length-1; i >=0; i--)
            {
                outputString += chars[i];
            }
            if (outputString == inputString)
            {
                responseText = outputString + " palindrome";
            }
            else
            {
                responseText = outputString + "not a palindrome";
            }
            return responseText;
        }
    }
}
