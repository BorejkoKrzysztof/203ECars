using System.Linq.Expressions;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;

namespace _2035Cars_Infrastructure.Repositories.CarDriveTypeDecorator
{
    public class ElectricDriveTypeExpressionDecorator : CarDriveTypeExpressionBase
    {
        private readonly Expression<Func<Car, bool>>? _expression;

        public ElectricDriveTypeExpressionDecorator(Expression<Func<Car, bool>>? expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<Car, bool>> GetExpression()
        {
            Expression<Func<Car, bool>> electricDriveTypeExpression =
                                            x => x.DriveType == DriveOfCar.Electric;

            if (this._expression is null)
                return electricDriveTypeExpression;

            var param = Expression.Parameter(typeof(Car), "x");
            var body = Expression.OrElse(Expression.Invoke(this._expression, param), Expression.Invoke(electricDriveTypeExpression, param));
            var lambda = Expression.Lambda<Func<Car, bool>>(body, param);

            return lambda;
        }
    }
}