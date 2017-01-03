using Cake.Testing;

using Shouldly;

using Xunit;

namespace Cake.Grunt.Tests {
	public class GruntGlobalRunnerTests {
		private readonly GruntGlobalRunnerFixture fixture;
		private readonly string gruntFile;

		public GruntGlobalRunnerTests()
		{
			this.fixture = new GruntGlobalRunnerFixture();
			this.gruntFile = "../gruntfile.js";
			this.fixture.FileSystem.CreateFile(this.gruntFile);
		}

		[Fact]
		public void Install_Settings_With_Grunt_File_Should_Add_Gruntfile_Argument()
		{
			this.fixture.InstallSettings = s => s.WithGruntFile(this.gruntFile);

			var result = this.fixture.Run();

			result.Args.ShouldBe("--gruntfile \"../gruntfile.js\"");
		}

		[Fact]
		public void Install_Settings_With_Grunt_File_and_Arguments_Should_Add_Grunt_File_And_Additional_Arguments()
		{
			this.fixture.InstallSettings = s => s.WithGruntFile(this.gruntFile).WithArguments("--production");

			var result = this.fixture.Run();

			result.Args.ShouldBe("--gruntfile \"../gruntfile.js\" --production");
		}

		[Fact]
		public void No_Install_Settings_Specified_Should_Execute_Command_Without_Arguments()
		{
			this.fixture.InstallSettings = null;

			var result = this.fixture.Run();

			result.Args.ShouldBe("");
		}
	}
}