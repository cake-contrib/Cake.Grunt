using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Grunt
{
    /// <summary>
    /// Returns a grunt runner based on either a local or global grunt installation via npm
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
        /// Get a grunt local runner based on a local grunt installation, a local installation is achieved through `npm install grunt`
        /// </summary>
        public GruntRunner<GruntLocalRunnerSettings> Local => new GruntLocalRunner(_fileSystem, _environment, _processRunner, _tools);

        /// <summary>
        /// Get a grunt global runner based on a global grunt installation, a global installation is achieved through `npm install grunt -g`
        /// </summary>
        public GruntRunner<GruntRunnerSettings> Global => new GruntGlobalRunner(_fileSystem, _environment, _processRunner, _tools);
    }
}