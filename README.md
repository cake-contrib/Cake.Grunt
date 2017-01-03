# cake-gulp

## Usage

```c#
    #addin "Cake.Grunt"

    Task("Default")
        .Does(() => 
        {
            // Executes gulp from a global installation (npm install -g gulp)
            Grunt.Global.Execute();

            // Executes gulp from a local installation (npm install gulp)
            Grunt.Local.Execute();
        });
```

## Scope

Cake.Grunt currently supports the following npm commands:

* Executing gulp from a local installation with arguments
* Executing gulp from a global installation with arguments

My primary goal for the project is to support the build workflow I need as a .NET developer.

Cake.Grunt will most likely be paired with [Cake.Npm](https://github.com/Philo/cake-npm) to support the installation of gulp itself along with any dependencies your gulp file requires.

## Tests

Cake.Grunt is covered by a set of unit tests contributed by @nengberg

## I cant do _<insert-function-here_

See above, the initial release supports only the most basic functionality I need, if you have feature requests please submit them as issues
