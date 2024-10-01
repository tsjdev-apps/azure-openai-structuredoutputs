# Using Structured Outputs to Generate JSON responses with OpenAI

Explore the Structured Outputs functionality within the Azure.AI.OpenAI NuGet package to implement custom logic in your .NET AI project.

![Header](/docs/header.png)

In some scenarios, receiving a structured JSON response is essential for your Azure OpenAI project. To meet this requirement, OpenAI introduced Structured Outputs, a feature that ensures the Large Language Model (LLM) generates responses that adhere to a provided JSON schema. This way, you don’t have to worry about the model omitting required keys or producing invalid enum values.

In this blog post, we’ll create a simple .NET console application to demonstrate two use cases of Structured Outputs. In the first example, we’ll solve a mathematical problem step-by-step, with explanations and the current state of the problem at each step. In the second example, we’ll generate a list of country information.

## Usage

To test our application, you’ll need either a valid OpenAI API key or access to an active Azure OpenAI Service.

## Screenshots

The first screenshot demonstrates the host selection process.

![Screenshot01](/docs/structured-outputs-01.png)

Based on your selection, you will be prompted to enter the necessary parameters.

![Screenshot02](/docs/structured-outputs-02.png)

Finally, the user selects between solving a math problem or retrieving country information.

![Screenshot03](/docs/structured-outputs-03.png)

Let’s start with a math problem. Simply enter your equation, and the Large Language Model will solve it, providing a step-by-step explanation.

![Screenshot04](/docs/structured-outputs-04.png)

When selecting country information, the user enters a comma-separated list of countries and receives a list of countries with the specified properties.

![Screenshot05](/docs/structured-outputs-05.png)

## Blog Posts

If you are more interested into details, please see the following posts on [medium.com](https://medium.com/@tsjdevapps) or in my [personal blog](https://www.tsjdev-apps.de/):

- [Using Structured Outputs to Generate JSON responses with OpenAI](https://medium.com/medialesson/using-structured-outputs-to-generate-json-responses-with-openai-e01f591b740f)
- [Einrichtung von OpenAI](https://www.tsjdev-apps.de/einrichtung-von-openai/)
- [Einrichtung von Azure OpenAI](https://www.tsjdev-apps.de/einrichtung-von-azure-openai/)
