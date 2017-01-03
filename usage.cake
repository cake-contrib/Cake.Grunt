// #addin "Cake.Grunt"
#r "artifacts\build\Cake.Grunt.dll"

Task("Default")
    .Does(() => 
    {
        try {
            Information("Running Global Grunt");
            // Executes grunt from a global installation (npm install -g grunt)
            Grunt.Global.Execute();
        } catch(Exception ex) {
            Error(ex.ToString());
        }
        
        try {
            Information("Running Local Grunt");
            // Executes grunt from a local installation (npm install grunt)
            Grunt.Local.Execute(settings => settings.WithGruntFile("gruntfile.js"));
        } catch(Exception ex) {
            Error(ex.ToString());
        }
    });
        
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

RunTarget(target);    