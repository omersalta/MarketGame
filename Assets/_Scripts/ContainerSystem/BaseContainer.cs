using System.Collections.Generic;
using System.Linq;
using _Scripts._Player;
using UnityEngine;

namespace _Scripts.ContainerSystem
{
    public abstract class BaseContainer : MonoBehaviour,IProductContainer
    {
        private List<Product> _products;
        private int _maxCount;

        public void Initialize(int maxCount)
        {
            if (maxCount <= 0)
            {
                Debug.LogWarning("Max count Cannot be negative");
                return;
            }
            _maxCount = maxCount;
            _products = new List<Product>(_maxCount);
        }
        
        public void AddProduct(Product product)
        {
            if (!IsFull())
            {
                _products.Add(product);
            }
        }
        
        public void RomoveProduct(Product product)
        {
            _products.Remove(product);
        }
        
        public virtual void SendProductTo(IProductContainer targetContainer)
        {
            if (!targetContainer.IsFull())
            {
                targetContainer.AddProduct(TakeFirstProduct());
            }
        }
        
        public bool IsEmpty()
        {
            return _products.Count >= 1;
        }
        
        public bool IsFull()
        {
            return _products.Count >= _maxCount;
        }
        
        public Product TakeFirstProduct()
        {
            if (_products.Count <= 0)
            {
                Debug.LogWarning("there is no product");
                return null;
            }
            Product product = _products.First();
            return product;
        }
        
        public void ClearMarketObjects()
        {
            _products.Clear();
        }
    }
}