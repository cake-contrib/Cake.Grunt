using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Grunt
{
    /// <summary>
    /// Class GruntGlobalRunner.
    /// </summary>
    public class GruntGlobalRunner : GruntRunner<GruntRunnerSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// creates a new grunt global runner
        /// </summary>
        /// <param name="fileSystem">the file system</param>
        /// <param name="environment">The cake environment</param>
        /// <param name="processRunner">The cake process runner</param>
        /// <param name="tools">The tools locator</param>
        public GruntGlobalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes grunt from the global installation
        /// </summary>
        public override void Execute(Action<GruntRunnerSettings> configure = null)
        {
            var settings = new GruntRunnerSettings();
            configure?.Invoke(settings);
            ValidateSettings(settings);

            var args = new ProcessArgumentBuilder();
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
            yield return "grunt.cmd";
            yield return "grunt";
        }
    }
}
