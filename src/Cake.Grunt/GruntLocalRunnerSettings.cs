using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core.IO;

namespace Cake.Grunt
{
    /// <summary>
    /// Class GruntLocalRunnerSettings.
    /// </summary>
    /// <seealso cref="Cake.Grunt.GruntRunnerSettings" />
    public class GruntLocalRunnerSettings : GruntRunnerSettings
    {
        /// <summary>
        /// Path to node modules
        /// </summary>
        public FilePath PathToGruntJs { get; private set; } = "node_modules/grunt/lib/grunt.js";

        /// <summary>
        /// Overrides the default path to grunt javascript, the current working directory will be prepended to this path
        /// </summary>
        /// <param name="gruntJs">path to grunt if different from './node_modules/grunt/lib/grunt.js'</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public GruntLocalRunnerSettings SetPathToGruntJs(FilePath gruntJs)
        {
            PathToGruntJs = gruntJs;
            return this;
        }
    }
}
