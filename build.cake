var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");
var slnFldr = "./";
var outFldr = $"{slnFldr}artifacts";

Task("Restore")
    .Does(() =>
    {
        DotNetRestore(slnFldr);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetBuild(slnFldr, new DotNetBuildSettings
        {
            NoRestore = true,
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetTest(slnFldr, new DotNetTestSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true
        });
    });

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
    {
        DotNetPublish(slnFldr, new DotNetPublishSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = outFldr
        });
    });


RunTarget(target);

