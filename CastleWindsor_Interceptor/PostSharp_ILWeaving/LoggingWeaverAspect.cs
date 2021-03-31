using PostSharp.Aspects;
using System;

namespace PostSharp_ILWeaving
{
    [Serializable]
    class LoggingWeaverAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Inside OnEntry");
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Inside OnExit");
        }
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("Inside OnException");
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("Inside OnSuccess");
        }
    }
}
