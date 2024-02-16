// See https://aka.ms/new-console-template for more information

using TestsAutomation;

TestAutomation t = new TestAutomation();

try
{
    var testresult = await t.RunTestOne();
    
    if (testresult)
    {
        Console.WriteLine("Test executed with success!");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Test ended with an error!\n Error Message: " + ex.Message);
}

try
{
    var testresult = await t.RunTestTwo();

    if (testresult)
    {
        Console.WriteLine("Test executed with success!");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Test ended with an error!\n Error Message: " + ex.Message);
}

try
{
    var testresult = await t.RunTestThree();

    if (testresult)
    {
        Console.WriteLine("Test executed with success!");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Test ended with an error!\n Error Message: " + ex.Message);
}

