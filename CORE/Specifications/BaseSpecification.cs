using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CORE.Specifications
{
   
   public  class BaseSpecification<T> : ISpecification<T>
    {
        #region CONSTRUCTOR

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        #endregion


        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }


    }
}
