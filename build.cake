var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");
var slnDir = "./";
var outDir = $"{slnDir}artifacts";

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(outDir);
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
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetTest(slnDir, new DotNetTestSettings
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
        DotNetPublish(slnDir, new DotNetPublishSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = outDir
        });
    });


RunTarget(target);

