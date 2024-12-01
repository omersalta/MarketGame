using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.Market
{
    public class AbstractProductPool : MonoBehaviour,IProductPool
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
            _products.Add(product);
        }
        
        public bool HasMarketObject()
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
            _products.Remove(product);
            return product;
        }
        
        public void ClearMarketObjects()
        {
            _products.Clear();
        }
    }
}