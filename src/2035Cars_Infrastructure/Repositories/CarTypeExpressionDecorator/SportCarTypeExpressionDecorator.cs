using System.Linq.Expressions;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;

namespace _2035Cars_Infrastructure.Repositories.CarTypeExpressionDecorator
{
    public class SportCarTypeExpressionDecorator : CarTypeExpressionBase
    {
        private readonly Expression<Func<Car, bool>>? _expression;

        public SportCarTypeExpressionDecorator(Expression<Func<Car, bool>>? expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<Car, bool>> GetExpression()
        {
            Expression<Func<Car, bool>> expressionSport = x => x.CarType == CarType.Sport;

            if (this._expression is null)
                return expressionSport;

            var param = Expression.Parameter(typeof(Car), "x");
            var body = Expression.OrElse(Expression.Invoke(this._expression, param), Expression.Invoke(expressionSport, param));
            var lambda = Expression.Lambda<Func<Car, bool>>(body, param);

            return lambda;
        }
    }
}