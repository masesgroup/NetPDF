# NetPDF: .NET suite for [PDFBox™](https://pdfbox.apache.org)

NetPDF is a comprehensive suite of libraries and tools to use [PDFBox™](https://pdfbox.apache.org) and .NET side-by-side.

### Libraries and Tools

|NetPDF | NetPDF.Templates | NetPDFCLI | NetPDFPS |
|:---:	|:---:	|:---:	|:---:	|
|[![NetPDF nuget](https://img.shields.io/nuget/v/MASES.NetPDF)](https://www.nuget.org/packages/MASES.NetPDF)<br/>[![downloads](https://img.shields.io/nuget/dt/MASES.NetPDF)](https://www.nuget.org/packages/MASES.NetPDF) | [![NetPDF.Templates nuget](https://img.shields.io/nuget/v/MASES.NetPDF.Templates)](https://www.nuget.org/packages/MASES.NetPDF.Templates)<br/>[![downloads](https://img.shields.io/nuget/dt/MASES.NetPDF.Templates)](https://www.nuget.org/packages/MASES.NetPDF.Templates)| [![NetPDFCLI nuget](https://img.shields.io/nuget/v/MASES.NetPDFCLI)](https://www.nuget.org/packages/MASES.NetPDFCLI)<br/>[![downloads](https://img.shields.io/nuget/dt/MASES.NetPDFCLI)](https://www.nuget.org/packages/MASES.NetPDFCLI)|[![NetPDFPS](https://img.shields.io/powershellgallery/v/MASES.NetPDFPS.svg?style=flat-square&label=MASES.NetPDFPS)](https://www.powershellgallery.com/packages/MASES.NetPDFPS/)|

### Pipelines

[![CI_BUILD](https://github.com/masesgroup/NetPDF/actions/workflows/build.yaml/badge.svg)](https://github.com/masesgroup/NetPDF/actions/workflows/build.yaml) 
[![CodeQL](https://github.com/masesgroup/NetPDF/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/masesgroup/NetPDF/actions/workflows/codeql-analysis.yml)
[![CI_RELEASE](https://github.com/masesgroup/NetPDF/actions/workflows/release.yaml/badge.svg)](https://github.com/masesgroup/NetPDF/actions/workflows/release.yaml) 

### Project disclaimer

NetPDF is a suite for [PDFBox™](https://pdfbox.apache.org), curated by MASES Group, can be supported by the open-source community.

Its primary scope is to support other, public or internal, MASES Group projects: open-source community and commercial entities can use it for their needs and support this project, moreover there are dedicated community and commercial subscription plans.

The repository code and releases may contain bugs, the release cycle depends from critical discovered issues and/or enhancement requested from this or other projects.

Looking for the help of experts? MASES Group can help you design, build, deploy, and manage applications managing PDF documents.

---

## Scope of the project

This project aims to create a set of libraries and tools to direct access, from .NET, all the features available in the [PDFBox™](https://pdfbox.apache.org).

See [NetPDF usage](src/documentation/articles/usage.md) for a comprehensive example.

### Community and Contribution

Do you like the project? 
- Request your free [community subscription](https://www.jcobridge.com/pricing-25/).

Do you want to help us?
- put a :star: on this project
- open [issues](https://github.com/masesgroup/NetPDF/issues) to request features or report bugs :bug:
- improves the project with Pull Requests

This project adheres to the Contributor [Covenant code of conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to coc_reporting@masesgroup.com.

## Summary

* [Roadmap](src/documentation/articles/roadmap.md)
* [Current state](src/documentation/articles/currentstate.md)
* [Usage](src/documentation/articles/usage.md)
* [Performance tips](https://jnet.masesgroup.com/articles/performancetips.html)
* [APIs extensibility](https://jnet.masesgroup.com/articles/API_extensibility.html)
* [JVM™ callbacks](https://jnet.masesgroup.com/articles/jvm_callbacks.html)
* [NetPDF CLI usage](src/documentation/articles/usageCLI.md)
* [NetPDF Docker usage](src/documentation/articles/docker.md)
* [NetPDF PowerShell usage](src/documentation/articles/usagePS.md)
* [NetPDF Command-line switches](src/documentation/articles/commandlineswitch.md)

### News

* V3.0.0+: First version based on [PDFBox™](https://pdfbox.apache.org) 3.0.4

---

## Runtime engine

NetPDF uses [JNet](https://github.com/masesgroup/JNet), and indeed [JCOBridge](https://www.jcobridge.com/) with its [features](https://www.jcobridge.com/features/), to obtain many benefits:
* **Cyber-security**: 
  * [JVM™](https://en.wikipedia.org/wiki/Java_virtual_machine) and [CLR, or CoreCLR,](https://en.wikipedia.org/wiki/Common_Language_Runtime) runs in the same process, but are insulated from each other;
  * JCOBridge does not make any code injection into JVM™;
  * JCOBridge does not use any other communication mechanism than JNI;
  * .NET (CLR) inherently inherits the cyber-security levels of running JVM™; 
* **Direct access the JVM™ from any .NET application**: 
  * Any Java/Scala/Kotlin/... class can be directly managed;
  * No need to learn new APIs: we try to expose the same APIs in C# style;
  * No extra validation cycle on protocol and functionality: bug fix, improvements, new features are immediately available;
  * Documentation is shared;
* **Dynamic code**: it helps to write a Java/Scala/Kotlin/etc seamless language code directly inside a standard .NET application written in C#/VB.NET: look at this [simple example](https://www.jcobridge.com/net-examples/dotnet-examples/) and [APIs extensibility](https://jnet.masesgroup.com/articles/API_extensibility.html).

[JCOBridge 2.6.*](https://www.jcobridge.com) can be used for free without any obligations; you need to purchase a commercial license, or uninstall the software, if you have direct or indirect incomes from the product usage.

### JCOBridge resources

Have a look at the following JCOBridge resources:

|JCOBridge | 2.5.* series | 2.6.* series |
|:---:	|:---:	|:---:	|
|NetPDF | > 3.0.* series | > 3.0.6 series |
|Release notes|[Link](https://www.jcobridge.com/release-notes/)| [Link](https://www.jcobridge.com/release-notes/)|
|Community Edition|[Conditions](https://www.jcobridge.com/pricing-25/)|[Conditions](https://www.jcobridge.com/pricing-25/)|
|Commercial Edition|[Information](https://www.jcobridge.com/pricing-26/)|[Information](https://www.jcobridge.com/pricing-26/)|

Latest release: [![JCOBridge nuget](https://img.shields.io/nuget/v/MASES.JCOBridge)](https://www.nuget.org/packages/MASES.JCOBridge)
