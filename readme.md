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