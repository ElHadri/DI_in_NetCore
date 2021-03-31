using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;

namespace CastleWindsor_Interceptor
{
    public class ExampleRegistration : IRegistration
    {
        public void Register(IKernelInternal kernel)
        {
            // 1. Interceptor Registration
            kernel.Register(
                Component
                .For<LoggingInterceptor>()
                .ImplementedBy<LoggingInterceptor>());

            // 2. Interceptor attached with Example Class. ("Example" will be intercepted by "LoggingInterceptor")
            // Adil: all methods and properties of "Example" will be intercepted when invoced.
            kernel.Register(
                Component
                .For<IExample>()
                .ImplementedBy<Example>()
                .Interceptors(InterceptorReference.ForType<LoggingInterceptor>())
                .Anywhere
                );

            /* If we want attach multiple interceptors to a single class */
            //kernel.Register(
            //    Component.For<IExample>()
            //    .ImplementedBy<Example>()
            //    .Interceptors(new InterceptorReference[] {
            //        InterceptorReference.ForType<LoggingInterceptor>(),
            //        InterceptorReference.ForType<AnotherInterceptor>() })
            //    .Anywhere);
        }
    }
}



