using OpenAI.Chat;
using OpenAIStructuredOutputsApp.Utils;
using System.Text.Json;

namespace OpenAIStructuredOutputsApp.Helpers;

internal class CountryInfoHelper
{
    /// <summary>
    /// Starts the country info collector asynchronously.
    /// </summary>
    /// <param name="client">The chat client.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task StartCountryInfoCollectorAsync(
        ChatClient client)
    {
        // Create ChatCompletions Options
        ChatCompletionOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "country_info",
                jsonSchema: BinaryData.FromString(@"
                    {
            ""type"": ""object"",
            ""properties"": {
                ""countryInfos"": {
                    ""type"": ""array"",
                    ""items"": {
                        ""type"": ""object"",
                        ""properties"": {
                            ""name"": {
                                ""type"": ""string""
                            },
                            ""twoLetterIsoCode"": {
                                ""type"": ""string""
                            },
                            ""area"": {
                                ""type"": ""number""
                            },
                            ""capital"": {
                                ""type"": ""string""
                            },
                            ""habitants"": {
                                ""type"": ""number""
                            }
                        },
                        ""required"": [
                            ""name"",
                            ""twoLetterIsoCode"",
                            ""area"",
                            ""capital"",
                            ""habitants""
                        ],
                        ""additionalProperties"": false
                    }
                }
            },
            ""required"": [
                ""countryInfos""
            ],
            ""additionalProperties"": false
        }
        "),
                jsonSchemaIsStrict: true)
        };

        // Get the math problem.
        string countries =
            ConsoleHelper.GetString("Please enter a comma-separated list of countries:");

        // Get the chat completion.
        ChatCompletion completion =
            await client.CompleteChatAsync(
                [countries],
                options: options);

        // Display the chat completion.
        using JsonDocument structuredJson =
            JsonDocument.Parse(completion.Content[0].Text);

        foreach (JsonElement country in
            structuredJson.RootElement
                .GetProperty("countryInfos").EnumerateArray())
        {
            ConsoleHelper.WriteCountryInfoToConsole(country);
        }
    }
}
