using OpenAI.Chat;
using OpenAIStructuredOutputsApp.Utils;
using System.Text.Json;

namespace OpenAIStructuredOutputsApp.Helpers;

internal static class MathProblemHelper
{
    /// <summary>
    /// Starts the math problem solver asynchronously.
    /// </summary>
    /// <param name="client">The chat client.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task StartMathProblemSolverAsync(
        ChatClient client)
    {
        // Create ChatCompletions Options
        ChatCompletionOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "math_reasoning",
                jsonSchema: BinaryData.FromString(@"
        {
            ""type"": ""object"",
            ""properties"": {
                ""steps"": {
                    ""type"": ""array"",
                    ""items"": {
                    ""type"": ""object"",
                    ""properties"": {
                        ""explanation"": { ""type"": ""string"" },
                        ""output"": { ""type"": ""string"" }
                    },
                    ""required"": [""explanation"", ""output""],
                    ""additionalProperties"": false
                    }
                },
                ""final_answer"": { ""type"": ""string"" }
            },
            ""required"": [""steps"", ""final_answer""],
            ""additionalProperties"": false
        }
        """),
                jsonSchemaIsStrict: true)
        };

        // Get the math problem.
        string mathProblem =
            ConsoleHelper.GetString("Please enter a math problem:");

        // Get the chat completion.
        ChatCompletion completion = await client.CompleteChatAsync(
           [mathProblem],
           options: options);

        // Display the chat completion.
        using JsonDocument structuredJson
            = JsonDocument.Parse(completion.Content[0].Text);

        ConsoleHelper.WriteMathProblemInfoToConsole(structuredJson);
    }
}
