using System;

using Cake.Testing.Fixtures;

namespace Cake.Grunt.Tests {
	public class GruntLocalRunnerFixture : ToolFixture<GruntLocalRunnerSettings>
	{
		public GruntLocalRunnerFixture() : base("node") {}

		public Action<GruntLocalRunnerSettings> InstallSettings { get; set; }

		protected override void RunTool()
		{
            var tool = new GruntLocalRunner(FileSystem, Environment, ProcessRunner, Tools);
			tool.Execute(InstallSettings);
		}
	}
}