﻿using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Grunt
{
    /// <summary>
    /// grunt local runner
    /// </summary>
    public class GruntLocalRunner : GruntRunner<GruntLocalRunnerSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// creates a new grunt local runner
        /// </summary>
        /// <param name="fileSystem">the file system</param>
        /// <param name="environment">The cake environment</param>
        /// <param name="processRunner">The cake process runner</param>
        /// <param name="tools">The tools locator</param>
        public GruntLocalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes grunt from the local installation
        /// </summary>
        public override void Execute(Action<GruntLocalRunnerSettings> configure = null)
        {
            var settings = new GruntLocalRunnerSettings();
            configure?.Invoke(settings);
            ValidateSettings(settings);

            var args = new ProcessArgumentBuilder();
            args.AppendQuoted(settings.PathToGruntJs.ToString());
            settings.Evaluate(args);

            Run(settings, args);
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>
        /// The tool executable name.
        /// </returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "node.exe";
            yield return "node";
            yield return "nodejs";
        }
    }
}
