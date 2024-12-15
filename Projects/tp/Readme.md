# Projet de Gestion d'Événements

Ce projet est une application web de gestion d'événements, permettant aux enseignants de créer et de gérer des événements sur un campus. Les étudiants peuvent s'inscrire et participer à ces événements.

## Prérequis

Avant de commencer, assurez-vous d'avoir installé les éléments suivants :

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://www.mysql.com/downloads/)
- [Visual Studio](https://visualstudio.microsoft.com/) ou un autre éditeur de code de votre choix

## Installation

1. Clonez le dépôt sur votre machine locale :

   ```bash
   git clone https://votre-repo-url.git
   ```

2. Accédez au répertoire du projet :

   ```bash
   cd nom-du-repertoire
   ```

3. Restaurez les dépendances du projet :

   ```bash
   dotnet restore
   ```

4. Configurez votre base de données MySQL. Créez une base de données et mettez à jour la chaîne de connexion dans le fichier `appsettings.json` :

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=nom_de_votre_base;User=root;Password=mot_de_passe;"
   }
   ```

5. Appliquez les migrations pour créer les tables nécessaires dans la base de données :

   ```bash
   dotnet ef database update
   ```

## Démarrage de l'application

Pour démarrer l'application, utilisez la commande suivante :
```bash
dotnet run
```

L'application sera accessible à l'adresse suivante : [https://localhost:5001](https://localhost:5001)

## Utilisation

## Enseignants

1. **Connexion** : Les enseignants peuvent se connecter à l'application pour accéder à toutes leurs fonctionnalités.
   
2. **Création d'événements** : Une fois connectés, les enseignants ont la possibilité de créer de nouveaux événements. Cela inclut la définition des détails essentiels tels que :
   - **Titre**
   - **Description**
   - **Date**
   - **Lieu**
   - **Nombre maximum de participants**

3. **Gestion des événements** : Les enseignants peuvent gérer les événements qu'ils ont créés, ce qui comprend :
   - La mise à jour des informations de l'événement
   - La suppression d'événements existants

4. **Consultation des détails des événements** : Ils peuvent consulter les détails des événements, y compris ceux qu'ils ont créés et ceux qui sont disponibles pour les étudiants.

## Étudiants

1. **Inscription aux événements** : Les étudiants peuvent s'inscrire aux événements disponibles, leur permettant ainsi de participer à des activités organisées sur le campus.

2. **Consultation des événements** : Les étudiants peuvent consulter les détails des événements, ce qui les aide à prendre des décisions éclairées sur les événements auxquels ils souhaitent participer.

## Résumé

En résumé, les enseignants disposent de capacités de gestion et de création d'événements, tandis que les étudiants se concentrent sur l'inscription et la participation à ces événements. Cette structure favorise une interaction fluide entre les deux groupes, améliorant ainsi l'organisation des activités sur le campus.

