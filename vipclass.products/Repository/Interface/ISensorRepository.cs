using System;
using System.Collections.Generic;
using vipclass.products.Domain;

namespace vipclass.products.Repository.Interface
{
    public interface ISensorRepository
    {
        public IEnumerable<Sensor> ListAll();
        public int Insert(long sensor);
    }
}
