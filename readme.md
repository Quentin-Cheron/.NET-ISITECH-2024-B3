# Commande

- dotnet new mvc -n mvc -o mvcTemplate : pour créer un projet MVC dans un dossier mvcTemplate

- dotnet run : à lancer dans un dossier contenant un fichier .csproj  pour lancer un projet .NET Core

- dotnet build : à lancer dans un dossier contenant un fichier .csproj pour compiler un projet .NET Core

# MVC

## Pattern MVC

- Model : données
- View : affichage
- Controller : contrôleur

## Espaces de noms

Namespacee : Un espace de noms est une sorte de dossier qui contient des classes.

## Files

Models : classes qui représentent les données

Views : fichiers HTML qui sont affichés par les controllers, il doit avoir le nom de la méthode du controller

Controllers : classes qui gèrent les requêtes HTTP et retournent des réponses HTTP

WWWRoot : fichiers statiques (css, js, images)

## Utils

- `comment`: @* comment *@

## Commandes

- dotnet new mvc -n mvc -o mvcTemplate : pour créer un projet MVC dans un dossier mvcTemplate
- dotnet run : à lancer dans un dossier contenant un fichier .csproj  pour lancer un projet .NET Core
- dotnet build : à lancer dans un dossier contenant un fichier .csproj pour compiler un projet .NET Core
- dotnet watch run : pour lancer un projet .NET Core et le recharger à chaque modification
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer : pour ajouter le package Entity Framework Core SQL Server
- dotnet ef migrations add InitialCreate : pour créer une migration
- dotnet ef database update : pour appliquer les migrations

Objet métier : les acteurs qui représentent les données

## Prompt

- authentification : Présenter des informations uniques pour identifier un utilisateur

## Authentification 

- download : 
  - Microsoft.AspNetCore.Identity.EntityFrameworkCore
  - Microsoft.AspNetCore.Identity.UI

Remplacer le DBContext par le IdentityUser

program.cs : app.useAuthentication();

View model : structure de données pour la vue