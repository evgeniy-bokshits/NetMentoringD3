﻿namespace ExpressionsAndIQueryable
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
