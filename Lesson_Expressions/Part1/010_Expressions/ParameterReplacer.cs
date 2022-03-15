using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _010_Expressions
{
    internal sealed class ParameterReplacer : ExpressionVisitor
    {
        internal ParameterReplacer(params ParameterExpression[] parameters)
            : this((IEnumerable<ParameterExpression>)parameters)
        { }

        internal ParameterReplacer(IEnumerable<ParameterExpression> parameters)
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
