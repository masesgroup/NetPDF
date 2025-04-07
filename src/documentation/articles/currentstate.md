---
title: Current state of .NET suite for PDFBox™
_description: Describes the current development state of .NET suite for PDFBox™
---

# NetPDF development state

This release comes with some ready made classes:

* NetPDF:
  * Reflected almost all classes of a Temurin JDK 11 with the limits imposed from JNetReflector
  * Manually made some classes, or extended some of reflected one, due to limitations of JNetReflector
  * If something is not available use [API extensibility](API_extensibility.md) to cover missing classes.
* NetPDFCLI: added REPL shell, run Main-Class and execute C# scripts
* NetPDFPS: some PowerShell cmdlets