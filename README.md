# Integricode Demo

A small C# repository where [Integricode](https://github.com/GabrielBels/integricode), an AI pull-request reviewer, reviews a real pull request.

- **The requirement:** [REQ-001](docs/requirements.md) caps a number search at 100 numbers.
- **The pull request:** [#1](https://github.com/GabrielBels/integricode-demo/pull/1) implements it. The change was written for this demo; the summary comment and the inline comments on it are Integricode's unedited output.
- **The wiring:** [`.github/workflows/integricode.yml`](.github/workflows/integricode.yml) is the caller workflow from the Integricode README. It runs when a pull request is marked ready for review, or when someone with write access comments `@integricode review`.

## Build and Test

```bash
dotnet build IntegricodeDemo.slnx
dotnet test IntegricodeDemo.slnx
```
