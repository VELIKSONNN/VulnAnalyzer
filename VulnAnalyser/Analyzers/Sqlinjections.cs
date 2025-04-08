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

        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            var typeName = node.Type.ToString();
            if (typeName.Contains("SqlCommand"))
            {
                var line = node.GetLocation().GetLineSpan().StartLinePosition.Line + 1;
                Console.WriteLine($"SqlCommand détecté à la ligne {line}");
            }
            base.VisitObjectCreationExpression(node);
        }

    }
}  

