using YTRKDotNetCore.ConsoleAppRefitExamples;


try
{

    RefitExample refitExample = new RefitExample();
    await refitExample.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}