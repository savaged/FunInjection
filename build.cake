var target = Argument("target", "Publish");
var conf = "Debug";
var framework = "net6.0";
var confArg = Argument("confArg", conf);
var slnDir = "./";
var operationsLibDir = $"{slnDir}FunInjectionOperations";
var testLibDir = $"{slnDir}FunInjectionTests";
var outDir = $"{slnDir}FunInjection/bin/{conf}/{framework}";
var objDir = $"{slnDir}FunInjection/obj/{conf}/{framework}";
var testOutDir = $"{testLibDir}FunInjectionTests/bin/{conf}/{framework}";
var testObjDir = $"{testLibDir}FunInjectionTests/obj/{conf}/{framework}";
var operationsLibOutDir = $"{outDir}/OperationsLib";

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(outDir);
        CleanDirectory(testOutDir);
    });

Task("DeepClean")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        CleanDirectory(objDir);
        CleanDirectory(testObjDir);
    });

Task("Restore")
    .Does(() =>
    {
        DotNetRestore(slnDir);
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetBuild(slnDir, new DotNetBuildSettings
        {
            NoRestore = true,
            Configuration = confArg
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetTest(slnDir, new DotNetTestSettings
        {
            NoRestore = true,
            Configuration = confArg,
            NoBuild = true
        });
    });

Task("Publish")
    .IsDependentOn("Test")
    .IsDependentOn("PublishOperationsLib")
    .Does(() =>
    {
        DotNetPublish(slnDir, new DotNetPublishSettings
        {
            NoRestore = true,
            Configuration = confArg,
            NoBuild = true,
            OutputDirectory = outDir
        });
    });

Task("PublishOperationsLib")
    .Does(() =>
    {
        DotNetPublish(operationsLibDir, new DotNetPublishSettings
        {
            NoRestore = true,
            Configuration = confArg,
            NoBuild = true,
            OutputDirectory = operationsLibOutDir
        });
    });
    
RunTarget(target);
