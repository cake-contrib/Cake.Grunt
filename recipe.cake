#load nuget:?package=Cake.Recipe&version=3.0.1

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Grunt",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.Grunt",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunInspectCode: false,
                            shouldRunDotNetCorePack: true,
                            shouldRunCoveralls: false); // Disabled because it's currently failing


BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
