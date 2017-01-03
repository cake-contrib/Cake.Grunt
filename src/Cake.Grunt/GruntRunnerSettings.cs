using System;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Grunt
{
    /// <summary>
    /// Grunt settings
    /// </summary>
    public class GruntRunnerSettings : ToolSettings
    {
        /// <summary>
        /// The gruntfile to run
        /// </summary>
        public FilePath GruntFile { get; private set; }

        /// <summary>
        /// Argument string to pass to grunt
        /// </summary>
        public string Arguments { get; private set; }

        /// <summary>
        /// The gruntfile to use
        /// </summary>
        /// <param name="gruntfile">path to gruntfile</param>
        /// <returns>the settings</returns>
        public GruntRunnerSettings WithGruntFile(FilePath gruntfile)
        {
            if (gruntfile.GetExtension() != ".js") throw new ArgumentException("gruntfile should be a javascript file with the .js extension");

            GruntFile = gruntfile;

            return this;
        }

        /// <summary>
        /// The argument string to pass to grunt
        /// </summary>
        /// <param name="arguments">an argument string</param>
        /// <returns>the settings</returns>
        public GruntRunnerSettings WithArguments(string arguments)
        {
            Arguments = arguments;
            return this;
        }

        internal void Evaluate(ProcessArgumentBuilder args)
        {
            if (GruntFile != null) args.AppendSwitchQuoted("--gruntfile", GruntFile.FullPath);
            if (!string.IsNullOrWhiteSpace(Arguments)) args.Append(Arguments);
            EvaluateCore(args);
        }

        /// <summary>
        /// evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {

        }
    }
}
