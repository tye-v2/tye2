# Tye2

## Intro

Hello tye users!

With last week's reveal of [Aspire](https://github.com/dotnet/aspire), [Project Tye](https://github.com/dotnet/tye) is [truly dead](https://github.com/dotnet/tye/issues/1622).

Regardless, i feel there is still value in a tool like tye that brings a similar local dev orchestration experience while having a lighter, less intrusive footprint that anyone in your team can pick up and use regardless of their stack background.

> In the end **_it's just yaml_**, if you can write docker compose files or kubernetes manifests, you can use tye2.

Therefore i have hard forked tye in this repo under the working name **tye2**.

Initial focus would be on the local development experience and the plan is to move it forward by smoothing out the rough edges around the ui/ux and extend it's capabilities to allow a smoother local dev experience

A rough roadmap would be:

- Publish new tool to nuget
- Review / merge low hanging fruit PRs proposed by users but never approved by the tye team
- Formulate and implement a more flexible / templateable configuration model (maybe with an cascading config model a la Postman)
- Add dependencies between services (a la docker compose)
- Make the dashboard more user-friendly : better logs, better overview of the service run context (configs)
- Deeper out-of-the box support for more stack types (node, python, java)
- Extension points (or some other type of custom action) to allow for example population of a DB, or to execute requests against an API once they are started
- Support other container providers other than docker desktop (podman)

If anyone has interest in using, testing or contributing to this project going forward, you are welcome to reach out in the issues and discussions.

Hoping to see as many of you here!

## Docs
To run docs locally :
npm add -D vitepress
npm run docs:dev
