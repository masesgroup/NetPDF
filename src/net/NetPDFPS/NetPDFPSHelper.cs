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

using MASES.JNetPSCore;
using MASES.NetPDF;

namespace MASES.NetPDFPS
{
    /// <summary>
    /// Public Helper class
    /// </summary>
    public static class NetPDFPSHelper<TClass> where TClass : NetPDFCore<TClass>
    {
        public static void SetClassToRun(string classToRun) { JNetPSHelper<TClass>.Set(typeof(NetPDFCore<>), nameof(NetPDFPSCore.ApplicationClassToRun), classToRun); }

        public static void SetCommonLoggingPath(string commonLoggingath) { JNetPSHelper<TClass>.Set(typeof(NetPDFCore<>), nameof(NetPDFPSCore.ApplicationCommonLoggingPath), commonLoggingath); }

        public static void SetLogPath(string logPath) { JNetPSHelper<TClass>.Set(typeof(NetPDFCore<>), nameof(NetPDFPSCore.ApplicationLogPath), logPath); }
    }
}