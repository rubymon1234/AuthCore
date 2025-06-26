using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections;
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
        public async Task<List<KeyValuePair<int, string>>> Collections()
        {
            string[] str = { "a", "b", "c", "d", "e", "f" };
            List<KeyValuePair<int,string>> myList = new List<KeyValuePair<int, string>>();
            int i = 0;
            foreach (string str2 in str)
            {
                myList.Add(new KeyValuePair<int, string>(i, str2));
                i++;
            }
            await Task.Delay(1);
            return myList;

        }
    }
}
