using System;

namespace Labs.ExceptionHandler
{
    class ExceptionHandler
    {
        public static void AddUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (o, e) =>
            {
                Console.Error.WriteLine(((Exception)e.ExceptionObject).Message.ToString());
                Console.ReadKey();
            };
        }
    }
}
