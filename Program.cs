using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IsPalindromeWithRegex
{
    public class Program
    {
        public static bool IsPalindrome(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("String is Null");
            }
            
            if(s.Length < 2)
            {
                return true;
            }
            
            var regex = new Regex(@"^(?'letter'[a-z0-9])+[a-z0-9]?(?:\k'letter'(?'-letter'))+(?(letter)(?!))$");
            return regex.Match(s).Success;
        }
        
        public static void Main(string[] args)
        {
            Func<bool> nullCheck = () => {
                try
                {
                    IsPalindrome(null);
                    return false;
                }
                catch (ArgumentException ex)
                {
                    return true;
                }
            };
            
            Func<bool> emptyCheck = () => {
                try
                {
                    IsPalindrome("");
                    return false;
                }
                catch (ArgumentException ex)
                {
                    return true;
                }
            };
            
            var testPassed = new []
            {
                // Exception tests
                nullCheck() == true,
                emptyCheck() == true,
                
                // Positive tests
                IsPalindrome("a") == true,
                IsPalindrome("aa") == true,
                IsPalindrome("aba") == true,
                IsPalindrome("abba") == true,
                IsPalindrome("121") == true,
                IsPalindrome("ab121ba") == true,
                
                // Negative tests
                IsPalindrome("abc") == false,
                IsPalindrome("cba") == false,
                IsPalindrome("ca") == false,
                IsPalindrome("ccca") == false,
                IsPalindrome("abA") == false,
            }.All(result => result == true);
            
            if(testPassed)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}