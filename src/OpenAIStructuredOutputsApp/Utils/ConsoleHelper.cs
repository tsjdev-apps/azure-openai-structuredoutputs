using Spectre.Console;
using System.Text.Json;

namespace OpenAIStructuredOutputsApp.Utils;

internal static class ConsoleHelper
{
    /// <summary>
    ///     Clears the console and creates the header for the application.
    /// </summary>
    public static void ShowHeader()
    {
        AnsiConsole.Clear();

        Grid grid = new();
        grid.AddColumn();
        grid.AddRow(new FigletText("Structured Outputs").Centered().Color(Color.Red));
        grid.AddRow(Align.Center(new Panel("[red]Sample by Thomas Sebastian Jensen ([link]https://www.tsjdev-apps.de[/])[/]")));

        AnsiConsole.Write(grid);
        AnsiConsole.WriteLine();
    }

    /// <summary>
    ///     Displays a prompt with the provided options and returns the selected option.
    /// </summary>
    /// <param name="options">The list of options to choose from.</param>
    /// <returns>The selected option.</returns>
    public static string SelectFromOptions(List<string> options)
    {
        ShowHeader();

        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select from the following [yellow]options[/]?")
            .AddChoices(options));
    }

    /// <summary>
    ///     Displays a prompt with the provided message and returns the user input.
    /// </summary>
    /// <param name="prompt">The prompt message.</param>
    /// <returns>The user input.</returns>
    public static string GetString(string prompt)
    {
        ShowHeader();

        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("white")
            .ValidationErrorMessage("[red]Invalid prompt[/]")
            .Validate(prompt =>
            {
                if (prompt.Length < 3)
                {
                    return ValidationResult.Error("[red]Value too short[/]");
                }

                if (prompt.Length > 200)
                {
                    return ValidationResult.Error("[red]Value too long[/]");
                }

                return ValidationResult.Success();
            }));
    }

    /// <summary>
    ///     Displays a prompt with the provided message and validates the user input as an URL.
    /// </summary>
    /// <param name="prompt">The prompt message.</param>
    /// <returns>The user input.</returns>
    public static string GetUrl(string prompt)
    {
        ShowHeader();

        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("white")
            .ValidationErrorMessage("[red]Invalid prompt[/]")
            .Validate(prompt =>
            {
                if (prompt.Length < 3)
                {
                    return ValidationResult.Error("[red]URL too short[/]");
                }

                if (prompt.Length > 250)
                {
                    return ValidationResult.Error("[red]URL too long[/]");
                }

                if (Uri.TryCreate(prompt, UriKind.Absolute, out Uri? uri)
                    && uri.Scheme == Uri.UriSchemeHttps)
                {
                    return ValidationResult.Success();
                }

                return ValidationResult.Error("[red]No valid URL[/]");
            }));
    }

    /// <summary>
    ///     Writes the specified text to the console.
    /// </summary>
    /// <param name="text">The text to write.</param>
    public static void WriteToConsole(string text)
    {
        AnsiConsole.Markup($"[white]{text}[/]");
        AnsiConsole.WriteLine();
    }

    /// <summary>
    ///     Writes the math problem information to the console.
    /// </summary>
    /// <param name="structuredJson">The structured JSON document.</param>
    public static void WriteMathProblemInfoToConsole(JsonDocument structuredJson)
    {
        WriteToConsole($"Final answer: " +
            $"{structuredJson.RootElement.GetProperty("final_answer").GetString()}");
        WriteToConsole("Reasoning steps:");

        foreach (JsonElement stepElement in
            structuredJson.RootElement.GetProperty("steps").EnumerateArray())
        {
            WriteToConsole($"  - Explanation: " +
                $"{stepElement.GetProperty("explanation").GetString()}");
            WriteToConsole($"    Output: " +
                $"{stepElement.GetProperty("output")}");
        }
    }

    /// <summary>
    ///     Writes country information to the console.
    /// </summary>
    /// <param name="country">The country information.</param>
    public static void WriteCountryInfoToConsole(JsonElement country)
    {
        WriteToConsole($"Name: " +
            $"{country.GetProperty("name").GetString()}");
        WriteToConsole($"Code: " +
            $"{country.GetProperty("twoLetterIsoCode")}");
        WriteToConsole($"Area: " +
            $"{country.GetProperty("area").GetDouble():N0} km²");
        WriteToConsole($"Capital: " +
            $"{country.GetProperty("capital")}");
        WriteToConsole($"Habitants: " +
            $"{country.GetProperty("habitants").GetDouble():N0}");
        WriteToConsole("---");
    }
}
