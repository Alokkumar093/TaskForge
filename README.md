# TaskForge

# 

# Folder \& Solution Setup

##### mkdir src

##### mkdir tests

##### mkdir frontend

##### 

##### 👉 Create main folders for backend, tests, and frontend

##### 

##### dotnet new sln -n ProjectManager

##### 

##### 👉 Create a .NET solution file (container for all projects)

##### 

##### 🧩 📁 Backend Projects

##### cd src

##### 

##### 👉 Move into backend folder

##### 

##### dotnet new classlib -n ProjectManager.Domain

##### 

##### 👉 Create Domain layer (entities, core logic)

##### 

##### dotnet new classlib -n ProjectManager.Application

##### 

##### 👉 Create Application layer (business logic, CQRS)

##### 

##### dotnet new classlib -n ProjectManager.Infrastructure

##### 

##### 👉 Create Infrastructure layer (DB, external services)

##### 

##### dotnet new webapi -n ProjectManager.API

##### 

##### 👉 Create API layer (controllers, endpoints)

##### 

##### 🔗 Add Projects to Solution

##### cd ..

##### 

##### 👉 Go back to root

##### 

##### dotnet sln add src/ProjectManager.Domain

##### dotnet sln add src/ProjectManager.Application

##### dotnet sln add src/ProjectManager.Infrastructure

##### dotnet sln add src/ProjectManager.API

##### 

##### 👉 Register all projects inside solution

##### 

##### 🔗 Project References (Architecture Rules)

##### dotnet add src/ProjectManager.Application reference src/ProjectManager.Domain

##### 

##### 👉 Application depends on Domain

##### 

##### dotnet add src/ProjectManager.Infrastructure reference src/ProjectManager.Application

##### dotnet add src/ProjectManager.Infrastructure reference src/ProjectManager.Domain

##### 

##### 👉 Infrastructure depends on Application + Domain

##### 

##### dotnet add src/ProjectManager.API reference src/ProjectManager.Application

##### dotnet add src/ProjectManager.API reference src/ProjectManager.Infrastructure

##### 

##### 👉 API depends on Application + Infrastructure

##### 

##### 🧪 Test Projects

##### cd tests

##### 

##### 👉 Move into test folder

##### 

##### dotnet new xunit -n ProjectManager.UnitTests

##### 

##### 👉 Create unit tests (logic testing)

##### 

##### dotnet new xunit -n ProjectManager.IntegrationTests

##### 

##### 👉 Create integration tests (API + DB testing)

##### 

##### cd ..

##### dotnet sln add tests/ProjectManager.UnitTests

##### dotnet sln add tests/ProjectManager.IntegrationTests

##### 

##### 👉 Add test projects to solution

##### 

##### 🌐 Frontend (Angular)

##### cd frontend

##### 

##### 👉 Move into frontend folder

##### 

##### npx @angular/cli new app

##### 

##### 👉 Create Angular application

##### 

##### cd app

##### npm start

##### 

##### 👉 Run Angular app (http://localhost:4200

##### )

##### 

##### 🚀 Run Backend

##### dotnet run --project src/ProjectManager.API

##### 

##### 👉 Start your .NET API

##### 

##### 🧠 Git Commands

##### git clone <repo-url>

##### 

##### 👉 Download repo to your machine

##### 

##### git checkout -b develop

##### 

##### 👉 Create and switch to develop branch

##### 

##### git checkout -b feature/your-feature

##### 

##### 👉 Create feature branch from develop

##### 

##### git add .

##### 

##### 👉 Stage all changes

##### 

##### git commit -m "message"

##### 

##### 👉 Save changes locally

##### 

##### git push -u origin develop

##### 

##### 👉 Push branch to GitHub

##### 

##### 🔥 Most Important Concept (Remember This)

##### Domain ← Application ← Infrastructure ← API

##### 

##### 👉 Dependency direction (never break this)

##### 

##### ⚡ Ultra Short Summary

##### mkdir → create folders

##### dotnet new → create projects

##### dotnet sln add → add to solution

##### dotnet add reference → link projects

##### dotnet run → run backend

##### npx @angular/cli new → create frontend

##### npm start → run frontend

git → version control


it Push (Quick Steps)
---

##### git status

##### 

##### 👉 Check changes

##### 

##### git add .

##### 

##### 👉 Stage all files

##### 

##### git commit -m "Initial project setup"

##### 

##### 👉 Save changes

##### 

##### git checkout develop

##### 

##### 👉 Switch to develop branch

##### 

##### git push -u origin develop

##### 

##### 👉 Upload to GitHub

##### 

##### 📁 What gets pushed

##### 

##### ✔ src/ → backend

##### ✔ tests/ → testing

##### ✔ frontend/ → Angular app

##### ✔ .sln → solution file

##### ✔ README.md

##### 

##### ⚠️ Important

##### 

##### 👉 Add .gitignore (once):

##### 

##### dotnet new gitignore

##### 🧠 One-line idea

##### 

##### 👉 “Push your full project structure to GitHub on develop branch”

##### 

##### 🔥 Done when

##### 

##### You see your folders on GitHub ✅

