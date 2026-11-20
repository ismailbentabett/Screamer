# Contributing to Screamer

Thanks for your interest in improving Screamer. This guide explains how to propose changes and what reviewers look for.

By participating you agree to follow the [Code of Conduct](CODE_OF_CONDUCT.md).

## Ways to contribute

- **Report a bug** using the [bug report form](https://github.com/ismailbentabett/Screamer/issues/new?template=bug_report.yml).
- **Suggest a feature** using the [feature request form](https://github.com/ismailbentabett/Screamer/issues/new?template=feature_request.yml).
- **Improve the docs**: typos, clarifications and missing setup steps are always welcome.
- **Submit code**: pick an open issue, or open one first to discuss larger changes.

Security problems should **not** be reported in public issues. See [SECURITY.md](SECURITY.md).

## Development setup

1. Install the prerequisites listed in the [README](README.md#-quick-start): .NET SDK 7.0, SQL Server, Node.js 18 and the `dotnet-ef` tool.
2. Configure `Screamer.WebApi/appsettings.Development.json` (or environment variables) with your own development credentials. Never commit real secrets.
3. Apply migrations: `dotnet ef database update --project Screamer.Presistance --startup-project Screamer.WebApi`
4. Run the API: `dotnet run --project Screamer.WebApi --launch-profile api`
5. Run the client: `cd Screamer.AngularUI && npm install --force && npm start`

## Workflow

1. Fork the repository and create a branch from the default branch:
   `git checkout -b feat/short-description`
2. Make focused commits. Keep unrelated refactors out of feature or fix PRs.
3. Run the checks below before pushing.
4. Open a pull request and fill in the template. Link the issue it resolves (`Closes #123`).

### Branch names

| Prefix | Use for |
| --- | --- |
| `feat/` | New features |
| `fix/` | Bug fixes |
| `docs/` | Documentation only |
| `refactor/` | Code changes that neither fix a bug nor add a feature |
| `chore/` | Tooling, dependencies, configuration |

### Commit messages

Use [Conventional Commits](https://www.conventionalcommits.org/):

```text
feat(feed): add hashtag filter to trending view
fix(auth): refresh token before it expires
docs: clarify database setup
```

## Before you open a pull request

- Backend: `dotnet build Screamer.sln` succeeds and `dotnet test` passes.
- Formatting: C# is formatted with [CSharpier](https://csharpier.com/) (`dotnet tool restore && dotnet csharpier .`).
- Frontend: `npm run build` succeeds in `Screamer.AngularUI`, and `npm test` passes for any specs you touched.
- No secrets, API keys or personal data in the diff.
- Documentation is updated when behaviour or configuration changes.

## Project conventions

- **Clean Architecture boundaries**: `Domain` has no dependencies; `Application` depends only on `Domain` and its own contracts; infrastructure concerns live in `Presistance`, `Identity` and `Infrastructure`; `WebApi` composes everything.
- **One feature, one folder**: new use cases go under `Screamer.Application/Features/<Feature>Request/{Commands,Queries}` with a MediatR request, a handler and, where needed, a FluentValidation validator.
- **Thin controllers and hubs**: controllers and SignalR hubs dispatch MediatR requests and should not contain business logic.
- **Migrations**: add EF Core migrations with a descriptive name and commit them with the model change.
- **Angular**: keep feature code inside `src/app/features/<feature>`, shared UI in `src/app/shared`, and cross-cutting services, guards and interceptors in `src/app/core`.

## Review process

A maintainer will review your pull request, may ask for changes, and will merge it once it is ready. Small, well-described PRs are reviewed fastest.

## Questions

Open a [discussion-style issue](https://github.com/ismailbentabett/Screamer/issues) or reach the maintainer via [GitHub](https://github.com/ismailbentabett).
