using Azure.AI.OpenAI;
using OpenAI.Chat;
using OpenAIStructuredOutputsApp.Helpers;
using OpenAIStructuredOutputsApp.Utils;
using System.ClientModel;

// Show the header.
ConsoleHelper.ShowHeader();

// Select whether to use Azure OpenAI or OpenAI
string host =
    ConsoleHelper.SelectFromOptions(
        [Statics.AzureOpenAIKey, Statics.OpenAIKey]);

// Create ChatClient
ChatClient? client = null;


// Create the appropriate ChatClient based on the user's selection
if (host == Statics.AzureOpenAIKey)
{
    string azureEndpoint =
        ConsoleHelper.GetUrl(
            "Please insert your [yellow]Azure OpenAI endpoint[/]:");

    string azureOpenAIKey =
        ConsoleHelper.GetString(
            $"Please insert your [yellow]{Statics.AzureOpenAIKey}[/] API key:");

    string azureDeploymentName =
        ConsoleHelper.GetString(
            "Please insert the [yellow]deployment name[/] of the model:");

    AzureOpenAIClient azureClient = new(
        new Uri(azureEndpoint),
        new ApiKeyCredential(azureOpenAIKey));

    client = azureClient.GetChatClient(azureDeploymentName);
}
else if (host == Statics.OpenAIKey)
{
    string openAIKey =
        ConsoleHelper.GetString(
            $"Please insert your [yellow]{Statics.OpenAIKey}[/] API key:");

    string openAIDeploymentName =
        ConsoleHelper.SelectFromOptions(
            [Statics.GPT4oKey, Statics.GPT4oMiniKey]);

    client = new ChatClient(
        openAIDeploymentName,
        new ApiKeyCredential(openAIKey));
}


// Exit if no client could be created
if (client == null)
{
    ConsoleHelper.WriteToConsole("Client creation failed.");
    return;
}

while (true)
{
    ConsoleHelper.ShowHeader();

    // Select mode
    string mode =
        ConsoleHelper.SelectFromOptions(
        [
            Statics.MathProblemKey,
            Statics.CountryInfoKey
        ]);


    switch (mode)
    {
        case Statics.MathProblemKey:
            await MathProblemHelper
                .StartMathProblemSolverAsync(client);
            break;

        case Statics.CountryInfoKey:
            await CountryInfoHelper
                .StartCountryInfoCollectorAsync(client);
            break;
    }

    Console.ReadKey();
}

