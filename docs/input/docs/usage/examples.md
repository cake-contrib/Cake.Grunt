# Build Script

You can reference Cake.Grunt in your build script as a cake addin:

```cake
#addin "Cake.Grunt"
```

or nuget reference:

```cake
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.Grunt"
```

Then some examples:

```cake
Task("Default")
    .Does(() => 
    {
        // Executes grunt from a global installation (npm install -g grunt)
        Grunt.Global.Execute();

        // Executes grunt from a local installation (npm install grunt)
        Grunt.Local.Execute();
    });
```