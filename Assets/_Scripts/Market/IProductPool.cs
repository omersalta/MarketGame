namespace _Scripts.Market
{
    public interface IProductPool
    {
        public void AddProduct(Product product);
    
        public bool HasMarketObject();
        
        public bool IsFull();

        public Product TakeFirstProduct();
    
        public void ClearMarketObjects();
    }
}