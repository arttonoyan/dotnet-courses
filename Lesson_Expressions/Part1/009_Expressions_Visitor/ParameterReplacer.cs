using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _009_Expressions_Visitor
{
    internal sealed class ParameterReplacer : ExpressionVisitor
    {
        internal ParameterReplacer(params ParameterExpression[] parameters)
        {
            _parametersDic = parameters.ToDictionary(p => p.Type.Name, p => p);
        }

        private readonly Dictionary<string, ParameterExpression> _parametersDic;

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (_parametersDic.TryGetValue(node.Type.Name, out ParameterExpression parameter))
                return base.VisitParameter(parameter);
            return base.VisitParameter(node);
        }
    }
}
