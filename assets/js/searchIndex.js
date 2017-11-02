
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"GruntGlobalRunner",
        content:"GruntGlobalRunner",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"GruntRunner",
        content:"GruntRunner",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"GruntLocalRunner",
        content:"GruntLocalRunner",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"GruntRunnerSettings",
        content:"GruntRunnerSettings",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"GruntRunnerAliases",
        content:"GruntRunnerAliases",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"GruntRunnerFactory",
        content:"GruntRunnerFactory",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"GruntLocalRunnerSettings",
        content:"GruntLocalRunnerSettings",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Grunt/api/Cake.Grunt/GruntGlobalRunner',
        title:"GruntGlobalRunner",
        description:""
    });

    y({
        url:'/Cake.Grunt/api/Cake.Grunt/GruntRunner_1',
        title:"GruntRunner<TSettings>",
        description:""
    });

    y({
        url:'/Cake.Grunt/api/Cake.Grunt/GruntLocalRunner',
        title:"GruntLocalRunner",
        description:""
    });

    y({
        url:'/Cake.Grunt/api/Cake.Grunt/GruntRunnerSettings',
        title:"GruntRunnerSettings",
        description:""
    });

    y({
        url:'/Cake.Grunt/api/Cake.Grunt/GruntRunnerAliases',
        title:"GruntRunnerAliases",
        description:""
    });

    y({
        url:'/Cake.Grunt/api/Cake.Grunt/GruntRunnerFactory',
        title:"GruntRunnerFactory",
        description:""
    });

    y({
        url:'/Cake.Grunt/api/Cake.Grunt/GruntLocalRunnerSettings',
        title:"GruntLocalRunnerSettings",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
