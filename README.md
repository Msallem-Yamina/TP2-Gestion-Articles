# Gestion des Articles

Application web **ASP.NET Core MVC (.NET 8)** de gestion d'articles et de catégories, avec accès aux données via **Entity Framework Core (approche Code First)** et gestion des utilisateurs avec **ASP.NET Core Identity**.

> Enseignant : Malek Zribi
> TP N°2 : Entity Framework Core (Code First) | TP N°3 : Authentification et autorisation (ASP.NET Identity)

## Fonctionnalités

### TP2 : Gestion des articles et catégories

- CRUD complet des **catégories** (liste, création, modification, détails, suppression)
- CRUD complet des **articles** (liste en cartes, création, modification, détails, suppression)
- **Upload d'image** pour chaque article (stockée dans `wwwroot/images`)
- **Recherche** par nom d'article ou par nom de catégorie (barre de navigation)
- Relation **Category 1 - N Product** (liste déroulante de catégories dans les formulaires)
- Validation des champs (DataAnnotations)
- Interface responsive avec le thème Bootswatch **Flatly**, cartes cliquables, badges de stock

### TP3 : Authentification et autorisation

- **Inscription, connexion et déconnexion** (Register, Login, Logout)
- Menu dynamique : *Register / Login* ou *Logout + email* selon l'état de connexion
- **Gestion des rôles** (Admin, Manager, User) : créer, modifier, supprimer, avec confirmation avant suppression
- **Affectation des utilisateurs aux rôles** (interrupteurs)
- **Autorisation par rôle** avec `[Authorize]` et `[AllowAnonymous]`
- Page **Accès refusé** et menu *Administration* visible uniquement pour l'Admin
- Interface Login / Register modernisée (labels flottants, icône œil pour afficher le mot de passe)

## Droits par profil

| Profil | Consulter les listes | Détails / créer / modifier / supprimer | Administration (rôles) |
|---|:---:|:---:|:---:|
| Visiteur (non connecté) | Oui | Non (redirigé vers Login) | Non |
| User | Oui | Non (Accès refusé) | Non |
| Manager | Oui | Oui | Non |
| Admin | Oui | Oui | Oui |

## Technologies

| Élément | Technologie |
|---|---|
| Framework | ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core 8 (Code First, migrations) |
| Authentification | ASP.NET Core Identity (`Microsoft.AspNetCore.Identity.EntityFrameworkCore`) |
| Base de données | SQLite (fichier `MyBaseDB.db`) |
| Front | Bootstrap 5 (thème Bootswatch Flatly), Bootstrap Icons, Razor |
| Patterns | Repository, Injection de dépendances, ViewModels |

> Le TP original utilise SQL Server LocalDB (Windows uniquement). Le projet a été réalisé sous Ubuntu avec SQLite : le code EF Core est identique, seul le fournisseur change (`UseSqlite` au lieu de `UseSqlServer`).

## Structure du projet

```
TP_Product/
├── Controllers/        ProductController, CategoryController, HomeController,
│                       AccountController (Register, Login, Logout, AccessDenied),
│                       AdminController (gestion des rôles)
├── Models/
│   ├── Product.cs, Category.cs, AppDbContext.cs (IdentityDbContext)
│   └── Repositories/   IProductRepository, ICategorieRepository + implémentations
├── ViewModels/         CreateViewModel, EditViewModel, RegisterViewModel, LoginViewModel,
│                       CreateRoleViewModel, EditRoleViewModel, UserRoleViewModel
├── Views/              Product/, Category/, Account/, Admin/, Shared/
├── Migrations/         Migrations EF Core (dont MajIdentity)
├── wwwroot/            css, js, images
└── Program.cs          Configuration, injection de dépendances, Identity
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
| `Add-Migration MajIdentity` | `dotnet ef migrations add MajIdentity` |
| `Update-Database` | `dotnet ef database update` |

## Créer le premier administrateur

Le rôle Admin est nécessaire pour accéder à l'administration, mais il faut être Admin pour créer des rôles. Pour amorcer :

1. Lancer l'application et créer un compte via **Register**.
2. Dans `AdminController`, mettre temporairement en commentaire `[Authorize(Roles = "Admin")]`.
3. Ouvrir `/Admin/CreateRole` et créer les rôles **Admin**, **Manager** et **User**.
4. Dans la liste des rôles : *Modifier* le rôle Admin, puis *Ajouter ou retirer des utilisateurs*, et s'attribuer Admin.
5. Remettre l'attribut `[Authorize(Roles = "Admin")]`, relancer l'application, puis **Logout / Login** (les rôles sont lus à la connexion).

## Utilisation

1. Créer quelques **catégories** (menu *Catégories*).
2. Créer des **articles** avec une image (menu *Liste d'articles > Nouvel Article*).
3. Cliquer sur une carte pour voir les **détails**, ou utiliser **Edit** / **Delete**.
4. Utiliser la barre **Search** pour filtrer par nom d'article ou de catégorie.
5. Gérer les rôles et les utilisateurs depuis le menu **Administration** (Admin uniquement).

## Auteur

**Yamina Msallem**
- TP N°2 : Accès à une base de données avec Entity Framework Core (Code First)
- TP N°3 : Gestion des utilisateurs, authentification et autorisation avec ASP.NET Identity
