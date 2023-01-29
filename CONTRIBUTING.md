# Contributing to GGJ 2023

## Table of contents

- 📦 [Prerequisites](#prerequisites)
- 🚀 [Installation](#installation)
- 🤝 [Requirements](#requirements)
- 🎉 [CI/CD](#ci-cd)

## Prerequisites

- [Git](https://git-scm.com/): software for distributed version control
- [Unity](https://unity3d.com/get-unity/download/): game development platform

## Installation

```shell
git clone git@github.com:marc-gavanier/GGJ-2023.git
```

You can now open the project with Unity

## Requirements

### Feature branch workflow

- Create your Feature Branch (git checkout -b feat/amazing-feature)
- Commit your Changes (git commit -m "feat: add some amazing feature")
- Push to the Branch (git push origin feat/amazing-feature)
- Open a Pull Request

### Branches naming rules

- Must be up-to-date with main (rebased, linear history)
- Must be prefixed with follow the `build/`, `chore/`, `ci/`, `docs/`, `feat/`, `fix/`, `perf/`, `refactor/`, `revert/`, `style/` or `test/` according to their content. See [Conventional Commits cheat sheet](https://kapeli.com/cheat_sheets/Conventional_Commits.docset/Contents/Resources/Documents/index)

### Commits rules

#### Format

Must follow conventional commits specification: [Commits Conventionnels](https://www.conventionalcommits.org/fr)

#### Verified

Commits must be verified: [About commit signature verification](https://docs.github.com/en/authentication/managing-commit-signature-verification/about-commit-signature-verification)

#### Continuous integration check

All validation checks in workflow [Validate](.github/workflows/validate.yml) must pass without failure

## CI/CD

### Pipeline

- [GitHub Actions](https://docs.github.com/en/actions) is the continuous integration and deployment tool provided by GitHub
- Repository secrets
  - `BUTLER_API_KEY`: API key to publish builds on itch.io. [API key is available in account settings page](https://itch.io/user/settings/api-keys)
  - `UNITY_EMAIL`: Email for Unity account associated with the license to activate
  - `UNITY_PASSWORD`: Password for Unity account associated with the license to activate
  - `UNITY_LICENSE`: Unity licence you can find in `Unity_v20XX.X.X.alf`. You can acquire this file after running [activation](.github/workflows/activation.yml) workflow

### Publish

Publishing on [itch.io game page](https://marc-gavanier.itch.io/ggj-2023) is fully automated on merge on master.

Available platforms are : WebGL, Linux, Windows and Mac OS X
