namespace StockInfoApp.Core.Services
{
    public interface IObjectMapperService{
    TDestination MapObjects<TSource, TDestination>(TSource source) where TDestination : class, new();   
}

}
