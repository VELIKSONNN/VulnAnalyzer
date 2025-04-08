using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VulnAnalyser.Analyzers;

namespace VulnAnalyser
{
    internal class Program
    {

        public static SyntaxNode CreationNoeud(string file)
        {
            var code = File.ReadAllText(file);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = syntaxTree.GetRoot(); // Racine de l'arbre syntaxique (SyntaxNode)
            return root;
        }

        static void Main(string[] args)
        {
            string file = "NomDuFichier.cs"; // Remplacez par le nom de votre fichier source

            // Création de l'arbre syntaxique depuis le fichier
            SyntaxNode root = CreationNoeud(file);

            // Créer une instance du visiteur et parcourir l'arbre
            var analyzer = new Sqlinjections();
            analyzer.Visit(root);
        }
    }
}
