using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public static class Program1 
    {
        public static string kek = "((5+3)(5+14+24))";
        public static void Main1() 
        {
           
           Test test = new Test(kek);
        }
    }
    
    public class Test
    {
        Stack<char> testStack = new Stack<char>();
        
        public string Text {get;set;}
        
        public Test(string text)
        {
            Text = text;
            Fu();
            
        }
        
        public void Fu()
        {
            for(int i = 0;i<Text.Length;i++)
            {
                if(Text[i] == '(')
                {
                    testStack.Push(Text[i]);
                }
                else if(Text[i] == ')')
                {    //если количество элементтв нуль то выдать ошибку
                    if(testStack.Count != 0 && testStack.Peek() == '(')
                    {
                        testStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Выражение неверное");
                        return;
                    }
                }
                
            }
            if(testStack.Count != 0)
            Console.WriteLine("Выражение неверное");
            else
                Console.WriteLine("Выражение верное");
            
        }
        
    }
}