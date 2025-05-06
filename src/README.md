## Generated classes

The command used to build the classes is the following:

1. Download the latest version of reflection utility:

```cmd
dotnet tool update -g MASES.JNetReflector
```

2. Run the reflection utility:

```cmd
jnetreflector -TraceLevel 0 -OriginRootPath .\jars -DestinationRootPath .\src\ -ConfigurationFile .\src\configuration.json
```

The configuration is:

```json
{
  "JVMOptions": [
    {
      "Name": "pdfbox.fontcache",
      "Value": "$(FONTCACHE_FOLDER)"
    }
  ],
  "RelativeDestinationCSharpClassPath": "net\\NetPDF\\Generated",
  "RelativeDestinationJavaListenerPath": "jvm\\netpdf\\src\\main\\java",
  "JavaListenerBasePackage": "org.mases.netpdf.generated",
  "PreferMethodWithSignature": true,
  "OnlyPropertiesForGetterSetter": true,
  "DisableInterfaceMethodGeneration": true,
  "CreateInterfaceInheritance": true,
  "JarList": [
    "pdfbox-3.0.5.jar",
    "pdfbox-io-3.0.5.jar",
    "fontbox-3.0.5.jar"
  ],
  "OriginJavadocJARVersionAndUrls": [
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.pdfbox/pdfbox/3.0.5/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.pdfbox/pdfbox-io/3.0.5/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.pdfbox/fontbox/3.0.5/"
    }
  ],
  "NamespacesToAvoid": [
    "org.apache.commons.logging"
  ],
  "ClassesToBeListener": [
    "org.apache.pdfbox.pdmodel.common.function.type4.Parser$SyntaxHandler"
  ],
  "ClassesToAvoid": [
    "org.apache.pdfbox.pdmodel.common.function.type4.Parser$AbstractSyntaxHandler"
  ],
  "ClassesManuallyDeveloped": [
    "org.apache.pdfbox.text.TextPositionComparator"
  ],
  "NamespacesInConflict": [
    "java.lang.module",
    "java.awt.color",
    "java.awt.desktop",
    "java.awt.image",
    "java.awt.event",
    "java.awt.font"
  ]
}
```