﻿namespace _Scripts.ContainerSystem
{
    public interface IProductContainer
    {
        public void AddProduct(Product product);
        
        public void RomoveProduct(Product product);
        
        public bool IsEmpty();
        
        public bool IsFull();

        public Product TakeFirstProduct();
    
        public void ClearMarketObjects();
    }
}