using System.Linq.Expressions;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;

namespace _2035Cars_Infrastructure.Repositories.CarTypeExpressionDecorator
{
    public class SuvCarTypeExpressionDecorator : CarTypeExpressionBase
    {
        private readonly Expression<Func<Car, bool>>? _expression;

        public SuvCarTypeExpressionDecorator(Expression<Func<Car, bool>>? expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<Car, bool>> GetExpression()
        {
            Expression<Func<Car, bool>> expressionSuv = x => x.CarType == CarType.Suv;

            if (this._expression is null)
                return expressionSuv;

            var body = Expression.OrElse(this._expression.Body, expressionSuv.Body);
            var lambda = Expression.Lambda<Func<Car, bool>>(body, this._expression.Parameters[0]);

            return lambda;
        }
    }
}