namespace _Scripts.Market
{
    public interface IProductContainer
    {
        public void AddProduct(Product product);
        
        public void RomoveProduct(Product product);
        
        public bool HasMarketObject();
        
        public bool IsFull();

        public Product TakeFirstProduct();
    
        public void ClearMarketObjects();
    }
}