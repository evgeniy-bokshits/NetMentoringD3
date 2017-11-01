namespace ExpressionsAndIQueryable
{
    public interface IMappingGenerator
    {
        IMapper<TSource, TDestination> Generate<TSource, TDestination>();
    }
}
