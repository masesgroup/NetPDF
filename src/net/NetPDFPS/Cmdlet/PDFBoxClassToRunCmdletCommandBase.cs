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

using MASES.JCOBridge.C2JBridge;
using MASES.JNet.PowerShell;
using MASES.JNet.Specific.CLI;
using System;
using System.Management.Automation;
using System.Reflection;

namespace MASES.NetPDF.PowerShell.Cmdlet
{
    public class PDFBoxClassToRunCmdletCommandBase<TCmdlet> : StartNetPDFPSCmdletCommandBase<TCmdlet>
        where TCmdlet : PDFBoxClassToRunCmdletCommandBase<TCmdlet>
    {
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The arguments to be sent to the PDFBox command.")]
        public string Arguments { get; set; }

        protected override void OnBeforeCreateGlobalInstance()
        {
            base.OnBeforeCreateGlobalInstance();
            var nounName = JNetPSHelper.NounName<TCmdlet>();
            JNetCLICoreHelper.ApplicationClassToRun = nounName;
        }

        protected override void OnAfterCreateGlobalInstance()
        {
            string[] arguments = Array.Empty<string>();
            if (Arguments != null)
            {
                arguments = Arguments.Split(' ');
            }

            try
            {
                JNetPSHelper<NetPDFPSCore>.Launch(JNetCLICoreHelper.MainClassToRun, arguments);
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
            catch (JCOBridge.C2JBridge.JVMInterop.JavaException je)
            {
                throw je.Convert();
            }
        }
    }
}
