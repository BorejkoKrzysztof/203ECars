using System.Linq.Expressions;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;

namespace _2035Cars_Infrastructure.Repositories.CarDriveTypeDecorator
{
    public class HybridDriveTypeExpressionDecorator : CarDriveTypeExpressionBase
    {
        private readonly Expression<Func<Car, bool>>? _expression;

        public HybridDriveTypeExpressionDecorator(Expression<Func<Car, bool>>? expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<Car, bool>> GetExpression()
        {
            Expression<Func<Car, bool>> hybridDriveTypeExpression =
                                            x => x.DriveType == DriveOfCar.Hybrid;

            if (this._expression is null)
                return hybridDriveTypeExpression;

            var param = Expression.Parameter(typeof(Car), "x");
            var body = Expression.OrElse(Expression.Invoke(this._expression, param), Expression.Invoke(hybridDriveTypeExpression, param));
            var lambda = Expression.Lambda<Func<Car, bool>>(body, param);

            return lambda;
        }
    }
}