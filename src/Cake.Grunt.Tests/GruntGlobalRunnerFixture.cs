using System;

using Cake.Testing.Fixtures;

namespace Cake.Grunt.Tests {
	public class GruntGlobalRunnerFixture : ToolFixture<GruntRunnerSettings> {
		public GruntGlobalRunnerFixture() : base("grunt") { }

		public Action<GruntRunnerSettings> InstallSettings { get; set; }

		protected override void RunTool() {
			var tool = new GruntGlobalRunner(FileSystem, Environment, ProcessRunner, Tools);
			tool.Execute(InstallSettings);
		}
	}
}