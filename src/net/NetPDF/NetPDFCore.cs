/*
*  Copyright 2024 MASES s.r.l.
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

using MASES.JNet;
using System.Collections.Generic;

namespace MASES.NetPDF
{
    /// <summary>
    /// Public entry point of <see cref="NetPDFCore{T}"/>
    /// </summary>
    public abstract class NetPDFCore<T> : JNetCore<T>
        where T : NetPDFCore<T>
    {
        #region Initialization
        /// <summary>
        /// Public ctor
        /// </summary>
        public NetPDFCore()
        {
            JCOBridge.C2JBridge.JCOBridge.RegisterExceptions(typeof(NetPDFCore<>).Assembly);
        }

        /// <summary>
        /// A list of paths to be used in initialization of JVM ClassPath
        /// </summary>
        protected override IList<string> PathToParse
        {
            get
            {
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
                if (!System.IO.File.Exists(netpdfFile))
                {
                    throw new System.IO.FileNotFoundException("Unable to identify JNet Jar location", netpdfFile);
                }
                var lst = base.PathToParse;
                lst.Add(netpdfFile);
                return lst;
            }
        }
        #endregion
    }
}