using System;

namespace Neemo.Payments.pp
{
    public class PayPalModelMapping : IMappingConfig
    {
        public void RegisterMapping<TMapper>(TMapper mapper)
        {
            if (typeof(TMapper) != typeof(AutoMapper.IConfiguration))
            {
                throw new ArgumentException("TMapper must be of type AutoMapper.Mapper");
            }


            var config = (AutoMapper.IConfiguration)mapper;
            
        }
    }
}