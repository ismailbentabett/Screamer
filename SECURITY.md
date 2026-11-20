# Security Policy

## Supported versions

Screamer is developed on its default branch. Security fixes are applied to the latest code on that branch only.

| Version | Supported |
| --- | --- |
| Default branch (latest) | Yes |
| Older commits and forks | No |

## Reporting a vulnerability

**Please do not report security vulnerabilities through public GitHub issues, discussions or pull requests.**

Report them privately through GitHub's private vulnerability reporting:

1. Go to the [Security tab](https://github.com/ismailbentabett/Screamer/security) of this repository.
2. Click **Report a vulnerability**.
3. Fill in the advisory form.

Please include as much of the following as you can:

- The type of issue (for example injection, broken authentication, exposed secret, XSS)
- The affected file paths, endpoints or components
- Steps to reproduce, ideally with a minimal proof of concept
- The potential impact and how an attacker might exploit it

## What to expect

- An acknowledgement of your report as soon as the maintainer is able to review it.
- An assessment of the issue and, if confirmed, a plan for a fix.
- Credit in the advisory once the fix is published, unless you prefer to stay anonymous.

Please give the maintainer a reasonable amount of time to address the issue before any public disclosure.

## Scope

In scope:

- The ASP.NET Core Web API, including authentication, JWT handling and external login (Google, Facebook)
- SignalR hubs (presence, messages, posts, notifications)
- The Angular client
- Configuration and Docker files in this repository

Out of scope: vulnerabilities in third-party services (hosting providers, OAuth providers, SaaS APIs) and in dependencies that are already publicly known. Those should be reported to the respective vendor or project.
