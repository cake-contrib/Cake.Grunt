
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"GruntRunner",
            content:"GruntRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Grunt/api/Cake.Grunt/GruntRunner_1',
            title:"GruntRunner<TSettings>",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"GruntLocalRunnerSettings",
            content:"GruntLocalRunnerSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Grunt/api/Cake.Grunt/GruntLocalRunnerSettings',
            title:"GruntLocalRunnerSettings",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"GruntRunnerSettings",
            content:"GruntRunnerSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Grunt/api/Cake.Grunt/GruntRunnerSettings',
            title:"GruntRunnerSettings",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"GruntRunnerFactory",
            content:"GruntRunnerFactory",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Grunt/api/Cake.Grunt/GruntRunnerFactory',
            title:"GruntRunnerFactory",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"GruntGlobalRunner",
            content:"GruntGlobalRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Grunt/api/Cake.Grunt/GruntGlobalRunner',
            title:"GruntGlobalRunner",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"GruntRunnerAliases",
            content:"GruntRunnerAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Grunt/api/Cake.Grunt/GruntRunnerAliases',
            title:"GruntRunnerAliases",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"GruntLocalRunner",
            content:"GruntLocalRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Grunt/api/Cake.Grunt/GruntLocalRunner',
            title:"GruntLocalRunner",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
