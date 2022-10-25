using System.Linq.Expressions;
using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Repositories.CarEquipmentDecorator
{
    public abstract class CarEquipmentExpressionBase
    {
        public abstract Expression<Func<Car, bool>> GetExpression();
    }
}