---
title: Command-line switch of PDFBox suite for .NET
_description: Describes the command-line switch of PDFBox suite for .NET
---

# NetPDF: Command line switches available

_netpdf_ accepts the following command-line switches:

* **LogClassPath**: put in command line the switch to output all Jars found

Plus it accepts from:
* **JCOBridge**:
  * All command-line switches of JCOBridge available at https://www.jcobridge.com/net-examples/command-line-options/

## JVM identification

One of the most important command-line switch is **JVMPath** and it is available in [JCOBridge switches](https://www.jcobridge.com/net-examples/command-line-options/): it can be used to set-up the location of the JVM library if JCOBridge is not able to identify a suitable JRE installation.
If a developer is using NetPDF within its own product it is possible to override the **JVMPath** property with a snippet like the following one:

```c#
    class MyNetPDFCore : NetPDFCore
    {
        public override string JVMPath
        {
            get
            {
                string pathToJVM = "Set here the path to JVM library or use your own search method";
                return pathToJVM;
            }
        }
    }
```

