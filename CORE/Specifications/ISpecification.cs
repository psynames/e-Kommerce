﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CORE.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get;}
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }



    }
}
