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

using Java.Io;
using Org.Apache.Pdfbox;
using Org.Apache.Pdfbox.Pdfwriter.Compress;
using Org.Apache.Pdfbox.Pdmodel;
using System;
using System.Management.Automation;

namespace MASES.NetPDF.PowerShell.Cmdlet
{
    [Cmdlet(VerbsData.Save, "PDF")]
    [OutputType(typeof(PDDocument))]
    public class SavePdfCmdletCommand : NetPDFPSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The object containing the PDF")]
        public PDDocument PdfDocument { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The file name of the PDF to write")]
        public String OutputFile { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The compression to apply")]
        public CompressParameters CompressParameter { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin SavePdfCmdletCommand!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessCommand()
        {
            if (CompressParameter == null) 
            {
                CompressParameter = CompressParameters.DEFAULT_COMPRESSION;
            }

            PdfDocument.Save(OutputFile, CompressParameter);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End SavePdfCmdletCommand!");
        }
    }
}
