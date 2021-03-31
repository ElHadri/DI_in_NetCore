using Castle.DynamicProxy;

using System;
using System.Collections.Generic;
using System.Text;

namespace CastleWindsor_Interceptor
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Console.WriteLine("Log Interceptor Starts");

                // Just calls the underlying method which is supposed to be intercepted. 
                // That means, when any method which is registered to use this interceptor, 
                // it will come to this method, which in turn, calls the same method from here with the Proceed().
                invocation.Proceed();

                Console.WriteLine("Log Interceptor Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Log Interceptor Exception");
                throw;
            }
            finally
            {
                Console.WriteLine("Log Interceptor Exit");
            }
        }
    }
}
