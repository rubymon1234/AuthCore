﻿using ShoppyWeb.ViewModel;

namespace ShoppyWeb.Models.Repositories.IRepository
{
    public interface ICartDetailsRepository 
    {
        Task<CartDetails> Create(ProductDetailsVm cart);
    }
}
