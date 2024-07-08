﻿using System;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.CodeAnalysis;

namespace KiotaGenerated;

[Generator]
public class KiotaVersionGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        var mainSyntaxTree = context.Compilation.SyntaxTrees
                            .First(static x => x.HasCompilationUnitRoot);

        var projectDirectory = Path.GetDirectoryName(mainSyntaxTree.FilePath);

        var version = "unknown";
        try {
            XmlDocument csproj = new XmlDocument();
            projectDirectory = Path.Combine(projectDirectory, "..", "..", "..", "..", "Directory.Build.props");
            csproj.Load(projectDirectory);
            version = csproj.GetElementsByTagName("VersionPrefix")[0].InnerText;
        } catch (Exception e)
        {
            throw new FileNotFoundException($"KiotaVersionGenerator expanded in an invalid project, missing 'Directory.Build.props' file in the following directory {projectDirectory}", e);
        }

        string source = $@"// <auto-generated/>
namespace Microsoft.Kiota.Http.Generated
{{
    /// <summary>
    /// The version class
    /// </summary>
    public static class Version
    {{
        /// <summary>
        /// The current version string
        /// </summary>
        public static string Current()
        {{
            return ""{version}"";
        }}
    }}
}}
";

        // Add the source code to the compilation
        context.AddSource($"KiotaVersion.g.cs", source);
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        // No initialization required for this one
    }
}