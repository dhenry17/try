﻿using System;
using MLS.Protocol;
using System.Linq;
using DiagnosticSeverity = MLS.Protocol.DiagnosticSeverity;

namespace WorkspaceServer
{
    public static class SerializableDiagnosticArrayExtensions
    {
        public static bool ContainsError(this SerializableDiagnostic[] diagnostics)
        {
            return diagnostics.Any(e => e.Severity == DiagnosticSeverity.Error);
        }

        public static string[] GetCompileErrorMessages(this SerializableDiagnostic[] diagnostics)
        {
            return diagnostics?.Where(d => d.Severity == DiagnosticSeverity.Error)
                              .Select(d => d.Message)
                              .ToArray()?? Array.Empty<string>();
        }
    }
}
