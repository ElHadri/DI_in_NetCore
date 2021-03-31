using System;
using System.Collections.Generic;

namespace MyExample_AmbientContext
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintContextTitle();
            using (new Context("outer context"))
            {
                PrintContextTitle();
                using (new Context("inner context"))
                {
                    PrintContextTitle();
                }
                PrintContextTitle();
            }
            PrintContextTitle();

            static void PrintContextTitle()
            {
                // j'en ai besoin je l'appelle directement
                Console.WriteLine("Current Context is {0}", Context.Current != null ? Context.Current.Title : "null"); 
            }
        }
    }

    public class Context : IDisposable
    {
        // Instance property
        public string Title { get; set; }

        // Static Poperties
        private static Stack<Context> stackOfNestedContexts = new Stack<Context>();
        public static Context Current
        {
            get
            {
                if (stackOfNestedContexts.Count == 0)
                    return null;
                return stackOfNestedContexts.Peek();
            }
        }

        // Contructor
        public Context(string title)
        {
            Title = title;
            stackOfNestedContexts.Push(this);
        }

        // Method
        public void Dispose()
        {
            stackOfNestedContexts.Pop();
        }
    }
}
