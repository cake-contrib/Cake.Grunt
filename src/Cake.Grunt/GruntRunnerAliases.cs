using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;

namespace Cake.Grunt
{
    /// <summary>
    /// contains functionality to interact with grunt
    /// </summary>
    [CakeAliasCategory("Node")]
    public static class GruntRunnerAliases
    {
        /// <summary>
        /// Allows access to the grunt task orchestrator for either the local or global installation
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <returns></returns>
        /// <example>
        /// <para>Run 'grunt' from your local grunt installation</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Grunt")
        ///     .Does(() =>
        /// {
        ///     Grunt.Local.Execute();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'grunt' from your global grunt installation</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Grunt")
        ///     .Does(() =>
        /// {
        ///     Grunt.Global.Execute();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'grunt --gruntfile gruntbuild.js'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Grunt")
        ///     .Does(() =>
        /// {
        ///     Grunt.Local.Execute(settings => settings.WithGruntFile("gruntbuild.js"));
        ///     
        ///     Grunt.Global.Execute(settings => settings.WithGruntFile("gruntbuild.js"));
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'grunt ci'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Grunt")
        ///     .Does(() =>
        /// {
        ///     Grunt.Local.Execute(settings => settings.WithArguments("ci"));
        ///     Grunt.Global.Execute(settings => settings.WithArguments("ci"));
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'grunt ci --dist=./artifacts/dist'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Grunt")
        ///     .Does(() =>
        /// {
        ///     Grunt.Local.Execute(settings => settings.WithArguments("ci --dist=./artifacts/dist"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias(Cache = true)]
        public static GruntRunnerFactory Grunt(this ICakeContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new GruntRunnerFactory(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}
