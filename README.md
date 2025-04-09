# VulnAnalyser

**VulnAnalyser** est un outil d'analyse de vulnérabilités écrit en C# et basé sur le compilateur Roslyn. Ce projet permet d'examiner des fichiers source C# pour détecter des patterns potentiellement dangereux, notamment l'utilisation incorrecte de `SqlCommand` qui peut introduire des failles d'injection SQL.

---

## Table des matières

- [Prérequis](#prérequis)
- [Installation](#installation)
- [Utilisation](#utilisation)
- [Structure du Projet](#structure-du-projet)
- [Exemple](#exemple)
- [Évolution future](#évolution-future)
- [Licence](#licence)

---

## Prérequis

- **.NET SDK** : Assurez-vous d'avoir la dernière version du .NET SDK installée sur votre machine.  
- **NuGet Packages** :
  - `Microsoft.CodeAnalysis.CSharp`
  - `Microsoft.CodeAnalysis.Analyzers`

Ces packages sont utilisés pour charger et analyser le code C# en générant un arbre syntaxique (AST) exploitable.

---

## Installation

1. Clonez le dépôt sur votre machine :
    ```bash
    git clone https://github.com/VotreNomUtilisateur/VulnAnalyser.git
    cd VulnAnalyser
    ```

2. Restaurez les packages NuGet :
    ```bash
    dotnet restore
    ```

3. Compilez le projet :
    ```bash
    dotnet build
    ```

---

## Utilisation

Le projet est une application console qui analyse un fichier C# et repère les utilisations dangereuses de `SqlCommand`.

1. Placez le fichier source C# à analyser dans le répertoire du projet. Par défaut, le fichier à analyser est référencé dans `Program.cs` (modifiez la variable `file` si nécessaire).

2. Exécutez l'application :
    ```bash
    dotnet run
    ```

3. Le programme parcourt le fichier et affiche en console les emplacements (lignes) où un objet `SqlCommand` est détecté.

---

## Structure du Projet

```
VulnAnalyser/
├── Analyzers/
│   └── Sqlinjections.cs      # Classe détectant les instanciations de 'SqlCommand'
├── Program.cs                # Point d'entrée de l'application (création de l'arbre syntaxique et lancement du visiteur)
├── VulnAnalyser.csproj       # Fichier projet .NET
└── README.md                 # Documentation du projet
```

- **Program.cs**  
  Contient la méthode `Main` qui lit le fichier source, génère l'arbre syntaxique via Roslyn et lance le visiteur `Sqlinjections` pour parcourir l'AST.

- **Analyzers/Sqlinjections.cs**  
  Hérite de `CSharpSyntaxWalker` et surchage la méthode `VisitObjectCreationExpression` afin de détecter les appels à `new SqlCommand(...)` et d'afficher l'emplacement dans le code source.

---

## Exemple

Supposons que le fichier `NomDuFichier.cs` contienne :

```csharp
using System.Data.SqlClient;

class Test {
    void Foo() {
        var cmd = new SqlCommand("SELECT * FROM Users");
    }
}
```

Lors de l'exécution, l'application affichera une alerte comme :

```
⚠️ SqlCommand détecté à la ligne 5
```

---

## Évolution future

- **Support de plusieurs fichiers** : Permettre l'analyse récursive d'un répertoire contenant plusieurs fichiers C#.
- **Plus de vulnérabilités** : Ajouter des analyzers pour détecter d'autres types de vulnérabilités (mauvaise gestion des accès fichiers, utilisation non sécurisée de Process.Start, etc.).
- **Rapports** : Générer des rapports détaillés au format JSON ou HTML.
- **Intégration IDE** : Développer un analyzers NuGet pour Visual Studio pour un feedback en temps réel.

---

## Licence

Ce projet est sous licence [MIT](LICENSE).

---

N'hésitez pas à adapter ce README pour refléter les spécificités et l'évolution de votre projet.
