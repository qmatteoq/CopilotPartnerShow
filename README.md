# Copilot Partner Show — samples

This repository contains a collection of sample projects featured in the **Copilot Partner
Show** podcast. Each sample demonstrates a different way to extend **Microsoft 365 Copilot**
and **Microsoft Teams** with custom agents, plugins and integrations.

## What's included

| Project | Stack | What it demonstrates |
| --- | --- | --- |
| `M365Agent/TravelAgency` | C#, Semantic Kernel, M365 Agents | A travel-agency agent that uses plugins (`DestinationsPlugin`, `WeatherPlugin`) and typed models to answer travel questions inside Teams / Copilot. |
| `TaskAgent` | TypeScript | An agent sample (VS Code / Teams Toolkit based) showing a different extensibility approach. |

> Each sample folder is self-contained — open the one you are interested in and follow the
> steps below.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (for the C# agent)
- [Node.js](https://nodejs.org/) LTS (for the TypeScript agent)
- A Microsoft 365 tenant with Copilot / Teams extensibility enabled
- An **OpenAI** or **Azure OpenAI** endpoint and key (for the Semantic Kernel samples)
- [Teams Toolkit](https://aka.ms/teams-toolkit) (recommended)

## Getting started

1. Clone the repository.
2. Open the sample folder you want to try (e.g. `M365Agent/TravelAgency`).
3. Provide the required configuration (model endpoint/keys via user-secrets, app settings).
4. Build and run, then sideload the agent into Teams / Copilot to test it.

## Contributing & support

See [`CODE_OF_CONDUCT.md`](CODE_OF_CONDUCT.md), [`SECURITY.md`](SECURITY.md) and
[`SUPPORT.md`](SUPPORT.md).

## License

Released under the [MIT License](LICENSE).
