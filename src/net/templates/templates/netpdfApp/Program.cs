using MASES.NetPDF;
using Org.Apache.Pdfbox;
using System;

namespace MASES.NetPDFTemplate.NetPDFApp
{
    class Program
    {
        class MyJNetCore : NetPDFCore<MyJNetCore> { }

        static void Main(string[] _)
        {
            MyJNetCore.CreateGlobalInstance(); // this call prepares the environment: it is mandatory to initialize the JVM
            var appArgs = MyJNetCore.FilteredArgs; // contains the remaining arguments: the NetPDF, JNet and JCOBridge arguments are discarded
            if (appArgs.Length != 0)
            {
                Console.WriteLine($"Opening {appArgs[0]}");

                var pdfFile = new Java.Io.File(appArgs[0]); // open a Java.Io.File pointing to the argument in input
                using (var pdfObject = Loader.LoadPDF(pdfFile)) // open the PDF file pointed by pdfFile: it is surrounded by using to execute the close on object at the end of operations
                {
                    // do stuff on opened PDF using pdfObject

                    Console.WriteLine($"Saving {appArgs[0]}");
                    pdfObject.Save(appArgs[0]); // finally save the PDF object
                }
            }
        }
    }
}
