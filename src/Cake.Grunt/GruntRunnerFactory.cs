using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Grunt
{
    /// <summary>
    /// Returns a gulp runner based on either a local or global gulp installation via npm
    /// </summary>
    public class GruntRunnerFactory
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IProcessRunner _processRunner;
        private readonly IToolLocator _tools;

        internal GruntRunnerFactory(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _processRunner = processRunner;
            _tools = tools;
        }

        /// <summary>
        /// Get a gulp local runner based on a local gulp installation, a local installation is achieved through `npm install gulp`
        /// </summary>
        public GruntRunner<GruntLocalRunnerSettings> Local => new GruntLocalRunner(_fileSystem, _environment, _processRunner, _tools);

        /// <summary>
        /// Get a gulp global runner based on a global gulp installation, a global installation is achieved through `npm install gulp -g`
        /// </summary>
        public GruntRunner<GruntRunnerSettings> Global => new GruntGlobalRunner(_fileSystem, _environment, _processRunner, _tools);
    }
}