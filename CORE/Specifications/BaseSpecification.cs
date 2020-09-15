using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        #region Fields

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        #endregion

        #region Methods 

        #region protected void AddInclude(Expression<Func<T, object>> includeExpression)

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        #endregion

        #region  protected void AddOderBy(Expression<Func<T, object>> orderByExpression)

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        #endregion

        #region  protected void AddOberByDescending(Expression<Func<T, object>> orderByDescExpression)

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        #endregion

        #endregion


    }
}
