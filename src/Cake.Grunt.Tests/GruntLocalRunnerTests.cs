using Cake.Testing;
using Shouldly;
using Xunit;

namespace Cake.Grunt.Tests {
	public class GruntLocalRunnerTests {
		private readonly GruntLocalRunnerFixture _fixture;
		private readonly string _gruntFile;

		public GruntLocalRunnerTests()
		{
			this._fixture = new GruntLocalRunnerFixture();
            this._gruntFile = "gruntfile.js";
			const string pathToGruntJs = "node_modules/grunt/lib/grunt.js";
			this._fixture.FileSystem.CreateFile(pathToGruntJs);
            this._fixture.FileSystem.CreateFile("/Working/" +pathToGruntJs);
            this._fixture.FileSystem.CreateFile("/abc");
			this._fixture.FileSystem.CreateFile(this._gruntFile);
            this._fixture.FileSystem.CreateFile("path-to-grunt/grunt.js");
        }

		[Fact]
		public void Install_Settings_With_Grunt_File_Should_Add_Gruntfile_Argument()
		{
			this._fixture.InstallSettings = s => s.WithGruntFile(this._gruntFile);

			var result = this._fixture.Run();

			result.Args.ShouldBe("\"node_modules/grunt/lib/grunt.js\" --gruntfile \"gruntfile.js\"");
		}

		[Fact]
		public void No_Install_Settings_Specified_Should_Execute_Command_Without_Arguments()
		{
			this._fixture.InstallSettings = null;

			var result = this._fixture.Run();

			result.Args.ShouldBe("\"node_modules/grunt/lib/grunt.js\"");
		}

        [Fact]
        public void Custom_Grunt_Path()
        {
            this._fixture.InstallSettings = s => s.SetPathToGruntJs("path-to-grunt/grunt.js");
            var result = this._fixture.Run();

            result.Args.ShouldBe("\"path-to-grunt/grunt.js\"");
        }
    }
}