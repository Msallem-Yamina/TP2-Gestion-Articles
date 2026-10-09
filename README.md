# TP2 - Gestion des Articles

Application web **ASP.NET Core MVC (.NET 8)** de gestion d'articles et de catégories, avec accès aux données via **Entity Framework Core (approche Code First)**.

> Enseignant : Malek Zribi

## Fonctionnalités

- CRUD complet des **catégories** (liste, création, modification, détails, suppression)
- CRUD complet des **articles** (liste en cartes, création, modification, détails, suppression)
- **Upload d'image** pour chaque article (stockée dans `wwwroot/images`)
- **Recherche** par nom d'article ou par nom de catégorie (barre de navigation)
- Relation **Category 1 - N Product** (liste déroulante de catégories dans les formulaires)
- Validation des champs (DataAnnotations)
- Interface responsive avec le thème Bootswatch **Flatly**, cartes cliquables, badges de stock

## Technologies

| Élément | Technologie |
|---|---|
| Framework | ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core 8 (Code First, migrations) |
| Base de données | SQLite (fichier `MyBaseDB.db`) |
| Front | Bootstrap 5 (thème Bootswatch Flatly), Razor |
| Patterns | Repository, Injection de dépendances, ViewModels |

> Le TP original utilise SQL Server LocalDB (Windows uniquement). Le projet a été réalisé sous Ubuntu avec SQLite : le code EF Core est identique, seul le fournisseur change (`UseSqlite` au lieu de `UseSqlServer`).

## Structure du projet

```
TP_Product/
├── Controllers/        ProductController, CategoryController, HomeController
├── Models/
│   ├── Product.cs, Category.cs, AppDbContext.cs
│   └── Repositories/   IProductRepository, ICategorieRepository + implémentations
├── ViewModels/         CreateViewModel, EditViewModel (upload d'image)
├── Views/              Product/, Category/, Shared/
├── Migrations/         Migrations EF Core
├── wwwroot/            css, js, images
└── Program.cs          Configuration et injection de dépendances
```

## Prérequis

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- Outil EF Core (pour les migrations) :

```bash
dotnet tool install --global dotnet-ef --version 8.0.*
```

## Lancer le projet

```bash
git clone https://github.com/Msallem-Yamina/TP2-Gestion-Articles.git
cd TP2-Gestion-Articles
dotnet restore
dotnet ef database update
dotnet run
```

Puis ouvrir l'adresse affichée dans le terminal (par exemple `http://localhost:5062`).

Pour le rechargement automatique pendant le développement : `dotnet watch run`.

## Base de données et migrations

La chaîne de connexion se trouve dans `appsettings.json` :

```json
"ConnectionStrings": {
  "ProductDBConnection": "Data Source=MyBaseDB.db"
}
```

Équivalents des commandes du TP (console NuGet de Visual Studio) :

| Visual Studio | Terminal |
|---|---|
| `Add-Migration InitialCreate` | `dotnet ef migrations add InitialCreate` |
| `Update-Database` | `dotnet ef database update` |

## Utilisation

1. Créer quelques **catégories** (menu *Catégories*).
2. Créer des **articles** avec une image (menu *Liste d'articles > Nouvel Article*).
3. Cliquer sur une carte pour voir les **détails**, ou utiliser **Edit** / **Delete**.
4. Utiliser la barre **Search** pour filtrer par nom d'article ou de catégorie.

## Auteur

**Yamina Msallem** - TP N°2 : Accès à une base de données avec Entity Framework Core (Code First).
