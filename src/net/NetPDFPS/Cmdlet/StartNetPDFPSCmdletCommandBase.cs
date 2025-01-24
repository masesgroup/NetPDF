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

using MASES.JNetPSCore.Cmdlet;
using MASES.NetPDF;
using System.Management.Automation;

namespace MASES.NetPDFPS.Cmdlet
{
    public class StartNetPDFPSCmdletCommandBase<TCmdlet> : StartJNetPSCmdletCommandBase<TCmdlet, NetPDFPSCore>
        where TCmdlet : StartNetPDFPSCmdletCommandBase<TCmdlet>
    {
        /// <inheritdoc cref="NetPDFCore{T}.ApplicationCommonLoggingPath" />
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The file containing the configuration of log4j.")]
        public string CommonLoggingPath { get; set; }

        /// <inheritdoc cref="NetPDFCore{T}.ApplicationLogPath" />
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The path where log will be stored.")]
        public string LogPath { get; set; }

        protected override void OnBeforeCreateGlobalInstance()
        {
            NetPDFPSHelper<NetPDFPSCore>.SetCommonLoggingPath(CommonLoggingPath);
            NetPDFPSHelper<NetPDFPSCore>.SetLogPath(LogPath);
        }
    }
}
