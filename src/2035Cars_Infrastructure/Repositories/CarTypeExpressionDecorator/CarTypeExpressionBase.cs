using System.Linq.Expressions;
using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Repositories.CarTypeExpressionDecorator
{
    public abstract class CarTypeExpressionBase
    {
        public abstract Expression<Func<Car, bool>> GetExpression();
    }
}