using System.Linq.Expressions;
using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Repositories.CarEquipmentDecorator
{
    public class BuildInNavigationExpressionDecorator : CarEquipmentExpressionBase
    {
        private readonly Expression<Func<Car, bool>>? _expression;

        public BuildInNavigationExpressionDecorator(Expression<Func<Car, bool>>? expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<Car, bool>> GetExpression()
        {
            Expression<Func<Car, bool>> buildInNavigationExpression =
                                            x => x.Equipment.HasBuildInNavigation;

            if (this._expression is null)
                return buildInNavigationExpression;

            var param = Expression.Parameter(typeof(Car), "x");
            var body = Expression.AndAlso(Expression.Invoke(this._expression, param), Expression.Invoke(buildInNavigationExpression, param));
            var lambda = Expression.Lambda<Func<Car, bool>>(body, param);

            return lambda;
        }
    }
}