using System.Linq.Expressions;
using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Repositories.CarEquipmentDecorator
{
    public class AutomaticGearBoxExpressionDecorator : CarEquipmentExpressionBase
    {
        private readonly Expression<Func<Car, bool>>? _expression;

        public AutomaticGearBoxExpressionDecorator(Expression<Func<Car, bool>>? expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<Car, bool>> GetExpression()
        {
            Expression<Func<Car, bool>> automaticGearBoxExpression =
                                            x => x.Equipment.HasAutomaticGearBox;

            if (this._expression is null)
                return automaticGearBoxExpression;

            var param = Expression.Parameter(typeof(Car), "x");
            var body = Expression.AndAlso(Expression.Invoke(this._expression, param), Expression.Invoke(automaticGearBoxExpression, param));
            var lambda = Expression.Lambda<Func<Car, bool>>(body, param);

            return lambda;
        }
    }
}