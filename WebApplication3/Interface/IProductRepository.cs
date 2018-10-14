﻿using System.Collections.Generic;

namespace ElectronicsStore.Repository
{
    public interface IProductRepository<T> where T :class
    {
        IEnumerable<T> GetAllProduct();
        T GetById(int productid);
    }
}
