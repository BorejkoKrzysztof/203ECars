using System.Linq.Expressions;
using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Repositories.CarDriveTypeDecorator
{
    public abstract class CarDriveTypeExpressionBase
    {
        public abstract Expression<Func<Car, bool>> GetExpression();
    }
}