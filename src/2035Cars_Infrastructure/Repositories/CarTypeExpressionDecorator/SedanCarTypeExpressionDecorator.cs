using System.Linq.Expressions;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;

namespace _2035Cars_Infrastructure.Repositories.CarTypeExpressionDecorator
{
    public class SedanCarTypeExpressionDecorator : CarTypeExpressionBase
    {
        private readonly Expression<Func<Car, bool>>? _expression;

        public SedanCarTypeExpressionDecorator(Expression<Func<Car, bool>>? expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<Car, bool>> GetExpression()
        {
            Expression<Func<Car, bool>> expressionSedan = x => x.CarType == CarType.Sedan;

            if (this._expression is null)
                return expressionSedan;

            var param = Expression.Parameter(typeof(Car), "x");
            var body = Expression.OrElse(Expression.Invoke(this._expression, param), Expression.Invoke(expressionSedan, param));
            var lambda = Expression.Lambda<Func<Car, bool>>(body, param);

            return lambda;
        }
    }
}