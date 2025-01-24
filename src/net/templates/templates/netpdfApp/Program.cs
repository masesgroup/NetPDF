using MASES.NetPDF;
using Org.Apache.Pdfbox;
using Org.Apache.Pdfbox.Io;
using Org.Apache.Pdfbox.Pdmodel;
using System;
using System.IO;

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

                using (var pdfObject = Loader.LoadPDF(new RandomAccessReadBufferedFile(appArgs[0]))) // open the PDF file referenced from command line: it is surrounded by using to execute the close on object at the end of operations
                {
                    // do stuff on opened PDF using pdfObject
                    foreach (PDPage page in pdfObject.Pages)
                    {
                        // do stuff on pages of opened PDF using page variable
                    }
                    string outputFile;
                    if (appArgs.Length > 1)
                    {
                        outputFile = appArgs[1];
                    }
                    else
                    {
                        outputFile = Path.Combine(Path.GetDirectoryName(appArgs[0]), $"{Path.GetFileNameWithoutExtension(appArgs[0])}_new.{Path.GetExtension(appArgs[0])}");
                    }
                    Console.WriteLine($"Saving on {outputFile}");
                    pdfObject.Save(outputFile); // finally save the PDF object using the second parameter: writing on the original PDF file can create corruption
                }
            }
        }
    }
}
