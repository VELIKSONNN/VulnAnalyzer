using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace VulnAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "NomDuFichier.cs"; // Remplacez par le nom de votre fichier
            static SyntaxNode Creationnoeud(string file)
            {
                var code = File.ReadAllText(file);
                var syntaxTree = CSharpSyntaxTree.ParseText(code); // permet d'avoir un arbres de toutes la syntax d'un fichiers ( déclaration d'une variable, assignation de valeur etc)
                var root = syntaxTree.GetRoot(); // SyntaxNode
                return root;
            }
        }
    }
}
