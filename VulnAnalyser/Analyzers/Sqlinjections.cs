using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulnAnalyser.Analyzers
{
    internal class Sqlinjections
    {
      

        static SyntaxNode Creationnoeud()
        {
            var code = File.ReadAllText("Test.cs");
             var syntaxTree = CSharpSyntaxTree.ParseText(code); // permet d'avoir un arbres de toutes la syntax d'un fichiers ( déclaration d'une variable, assignation de valeur etc)
              var root = syntaxTree.GetRoot(); // SyntaxNode
            return root;
        }

        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            var typeName = node.Type.ToString();
            if (typeName.Contains("SqlCommand"))
            {
                Console.WriteLine($"⚠️ SqlCommand détecté : {node.GetLocation().GetLineSpan().StartLinePosition}");
            }
            base.VisitObjectCreationExpression(node);
        }

    }
}
