using CastleWindsor_Interceptor;

namespace PostSharp_ILWeaving
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Example example = new Example();
                example.PrintName("Gobinda", "Dash");
                example.PrintSomethingElse();
            }
            catch
            { }
        }
    }
}
