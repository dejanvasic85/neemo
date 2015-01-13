using System;
using AutoMapper;

namespace Neemo.CarParts.EntityFramework
{
    public class EntityFrameworkMappingConfig : IMappingConfig
    {
        public void RegisterConfigs<TMapper>(TMapper mapper) 
        {
            if (typeof (TMapper) != typeof (AutoMapper.IConfiguration))
            {
                throw new ArgumentException("TMapper must be of type AutoMapper.Mapper");
            }


            var config = (IConfiguration)mapper;
            
        }
    }
}
