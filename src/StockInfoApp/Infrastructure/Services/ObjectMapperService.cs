using Microsoft.Extensions.Caching.Memory;

namespace StockInfoApp.Core.Services
{
    public class ObjectMapperService : IObjectMapperService
    {
        private readonly IMemoryCache _memoryCache;

        public ObjectMapperService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TDestination MapObjects<TSource, TDestination>(TSource source) where TDestination : class, new()
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            TDestination destination = new TDestination();
            var sourceProps = source.GetType().GetProperties();
            var destProps = destination.GetType().GetProperties();

            foreach (var sProp in sourceProps)
            {
                var dProp = destProps.FirstOrDefault(p => p.Name == sProp.Name &&
                                                                   p.PropertyType == sProp.PropertyType);
                if (dProp != null && dProp.CanWrite)
                {
                    var value = sProp.GetValue(source, null);
                    dProp.SetValue(destination, value, null);
                }
            }
            return destination;
        }
    }

}
