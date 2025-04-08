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
    internal class Sqlinjections : CSharpSyntaxWalker
    {
        Program.Creationnoeud;


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
