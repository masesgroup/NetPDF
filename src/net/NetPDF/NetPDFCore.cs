/*
*  Copyright 2025 MASES s.r.l.
*
*  Licensed under the Apache License, Version 2.0 (the "License");
*  you may not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*  http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*
*  Refer to LICENSE for more information.
*/

using MASES.CLIParser;
using System;
using System.Collections.Generic;
using System.IO;
using MASES.JNet;
using MASES.JCOBridge.C2JBridge;
using System.Linq;

namespace MASES.NetPDF
{
    /// <summary>
    /// Public entry point of <see cref="NetPDFCore{T}"/>
    /// </summary>
    /// <typeparam name="T">A class which inherits from <see cref="NetPDFCore{T}"/></typeparam>
    public class NetPDFCore<T> : JNetCore<T>
        where T : NetPDFCore<T>
    {
        /// <inheritdoc cref="JNetCoreBase{T}.CommandLineArguments"/>
        public override IEnumerable<IArgumentMetadata> CommandLineArguments
        {
            get
            {
                var lst = new List<IArgumentMetadata>(base.CommandLineArguments);
                lst.AddRange(new IArgumentMetadata[]
                {
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ClassToRun,
                        Help = "The class to be instantiated from CLI.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.CommonLoggingConfiguration,
                        Default = DefaultCommonLoggingConfiguration(),
                        Help = "The file containing the configuration of common logging.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.LogPath,
                        Default = Const.DefaultLogPath,
                        Help = "The path where log will be stored.",
                    },
                });
                return lst;
            }
        }
        /// <summary>
        /// Returns the default configuration file to use when initializing command line defaults
        /// </summary>
        /// <returns>The configuration file to use for logging</returns>
        /// <remarks>Overrides in derived classes to give another default file</remarks>
        protected virtual string DefaultCommonLoggingConfiguration()
        {
            return Const.DefaultCommonLoggingConfigurationPath;
        }

        /// <summary>
        /// Public initializer
        /// </summary>
        public NetPDFCore()
        {
            JCOBridge.C2JBridge.JCOBridge.RegisterExceptions(typeof(NetPDFCore<>).Assembly);
        }

        /// <inheritdoc cref="JNetCoreBase{T}.ProcessCommandLine" />
        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine();

            _classToRun = ParsedArgs.Get<string>(CLIParam.ClassToRun);
            _commonLoggingPath = ParsedArgs.Get<string>(CLIParam.CommonLoggingConfiguration);
            if (!Path.IsPathRooted(_commonLoggingPath)) // it is not a full path
            {
                var absolutePath = Path.Combine(Const.DefaultConfigurationPath, _commonLoggingPath);
                if (File.Exists(absolutePath))
                {
                    _commonLoggingPath = absolutePath;
                }
                else
                {
                    throw new ArgumentException($"{_commonLoggingPath} is not an absolute path and there is no file under {Const.DefaultConfigurationPath} whose absolute path is {absolutePath}");
                }
            }
            _logPath = ParsedArgs.Get<string>(CLIParam.LogPath);
            return result;
        }
        /// <summary>
        /// Prepare <see cref="MainClassToRun"/> property
        /// </summary>
        /// <param name="className">The class to search</param>
        /// <exception cref="ArgumentException">If <paramref name="className"/> does not have a corresponding implemented <see cref="Type"/></exception>
        protected virtual void PrepareMainClassToRun(string className)
        {
            if (string.IsNullOrWhiteSpace(className)) return;
            var invariantLowClassName = className.ToLowerInvariant();
            Type type = null;
            foreach (var item in typeof(NetPDFCore<>).Assembly.ExportedTypes)
            {
                if (item.Name.ToLowerInvariant() == invariantLowClassName
                    || item.FullName.ToLowerInvariant() == invariantLowClassName)
                {
                    type = item;
                    break;
                }
            }
            MainClassToRun = type ?? throw new ArgumentException($"Requested class {className} is not a valid class name.");
        }

        /// <summary>
        /// Sets the <see cref="Type"/> to be invoked at startup
        /// </summary>
        public static Type MainClassToRun { get; protected set; }

        /// <summary>
        /// Sets the global value of class to run
        /// </summary>
        public static string ApplicationClassToRun { get; set; }

        /// <summary>
        /// Sets the global value of log4j path
        /// </summary>
        public static string ApplicationCommonLoggingPath { get; set; }

        /// <summary>
        /// Sets the global value of log path
        /// </summary>
        public static string ApplicationLogPath { get; set; }

        /// <summary>
        /// value can be overridden in subclasses
        /// </summary>
        protected string _classToRun;
        /// <summary>
        /// The class to run in CLI version
        /// </summary>
        public virtual string ClassToRun { get { return ApplicationClassToRun ?? _classToRun; } }

        string _commonLoggingPath;
        /// <summary>
        /// The log4j folder
        /// </summary>
        public virtual string Log4JPath { get { return ApplicationCommonLoggingPath ?? _commonLoggingPath; } }

        string _logPath;
        /// <summary>
        /// The log folder
        /// </summary>
        public virtual string LogDir { get { return ApplicationLogPath ?? _logPath; } }

        /// <summary>
        /// The log4j configuration
        /// </summary>
        public virtual string CommonLoggingOpts { get { return string.Format("file:{0}", Path.Combine(Const.DefaultRootPath, "config", "tools-log4j.properties")); } }

        /// <inheritdoc cref="JNetCore{T}.PerformanceOptions"/>
        protected override IList<string> PerformanceOptions
        {
            get
            {
                var lst = new List<string>(base.PerformanceOptions);
                lst.AddRange(new string[]
                {
                    // "-server", <- Disabled because it avoids starts of embedded JVM
                    "-XX:+UseG1GC",
                    "-XX:MaxGCPauseMillis=20",
                    "-XX:InitiatingHeapOccupancyPercent=35",
                    "-XX:+ExplicitGCInvokesConcurrent",
                });
                return lst;
            }
        }

        /// <inheritdoc cref="JNetCore{T}.Options"/>
        protected override IDictionary<string, string> Options
        {
            get
            {
                if (!Directory.Exists(LogDir)) Directory.CreateDirectory(LogDir);

                IDictionary<string, string> options = new Dictionary<string, string>(base.Options)
                {
                    //{ "log4j.configuration", string.IsNullOrEmpty(Log4JPath) ? ((JarRootPath == Const.DefaultRootPath) ? Log4JOpts : null) : $"file:{Log4JPath}"},
                    { "java.awt.headless", "true" },
                };

                return options;
            }
        }

        /// <inheritdoc cref="JNetCore{T}.PathToParse"/>
        protected override IList<string> PathToParse
        {
            get
            {
                var lst = new List<string>(base.PathToParse);
                var assembly = typeof(NetPDFCore<>).Assembly;
                var version = assembly.GetName().Version.ToString();
                // 1. check first full version
                var netpdfFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assembly.Location), JARsSubFolder, $"netpdf-{version}.jar");
                if (!System.IO.File.Exists(netpdfFile) && version.EndsWith(".0"))
                {
                    // 2. if not exist remove last part of version
                    version = version.Substring(0, version.LastIndexOf(".0"));
                    netpdfFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assembly.Location), JARsSubFolder, $"netpdf-{version}.jar");
                }
                // 3. check if netpdf jar exist...
                if (!System.IO.File.Exists(netpdfFile))
                {
                    throw new System.IO.FileNotFoundException("Unable to identify NetPDF Jar location", netpdfFile);
                }
                // 4. add netpdf jar at this version first...
                lst.Add(netpdfFile);
                // 5. ...then add everything else
                lst.Add(Path.Combine(Const.DefaultJarsPath, "*.jar"));
                return lst;
            }
        }

#if DEBUG
        /// <inheritdoc cref="JNetCoreBase{T}.EnableDebug"/>
        public override bool EnableDebug => true;
#endif
    }
}