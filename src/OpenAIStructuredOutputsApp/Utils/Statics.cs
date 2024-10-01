namespace OpenAIStructuredOutputsApp.Utils;

internal class Statics
{
    /// <summary>
    ///     The key for Azure OpenAI.
    /// </summary>
    public const string AzureOpenAIKey
        = "Azure OpenAI";

    /// <summary>
    ///     The key for OpenAI.
    /// </summary>
    public const string OpenAIKey
        = "OpenAI";

    /// <summary>
    ///     The key for GPT-4o-mini.
    /// </summary>
    public static string GPT4oMiniKey
        = "gpt-4o-mini";

    /// <summary>
    ///     The key for GPT-4o-2024-08-06.
    /// </summary>
    public static string GPT4oKey
        = "gpt-4o-2024-08-06";

    /// <summary>
    ///     Prompt for getting the OpenAI API key.
    /// </summary>
    public static string OpenAIKeyPrompt
        = $"Please insert your [yellow]OpenAI[/] API key:";

    /// <summary>
    ///     The key for Math Problem.
    /// </summary>
    public const string MathProblemKey
        = $"Math Problem";

    /// <summary>
    ///     The key for Country Info.
    /// </summary>
    public const string CountryInfoKey
        = $"Country Info";
}
