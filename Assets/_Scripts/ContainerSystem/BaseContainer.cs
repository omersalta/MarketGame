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
        
        public void Initialize(int maxCount, List<Product> productsToAdd)
        {
            if (maxCount <= 0)
            {
                Debug.LogWarning("Max count Cannot be negative");
                return;
            }
            _maxCount = maxCount;
            _products = new List<Product>(_maxCount);
            
            if (productsToAdd != null)
            {
                if (productsToAdd.Count > 0)
                {
                    foreach (var product in productsToAdd)
                    {
                        _products.Add(product);
                        product.SetContainer(this);
                    }
                }
            }
        }
        
        public void AddProduct(Product product)
        {
            if (!IsFull())
            {
                IProductContainer container = product.GetContainer();
                if (container != null)
                {
                    product.GetContainer().RomoveProduct(product);
                }
                
                //Adding
                _products.Add(product);
                product.transform.parent = transform;
                product.transform.localPosition = Vector3.zero;
                product.transform.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.LogWarning("container is Full");
            }
        }
        
        
        public void RomoveProduct(Product product)
        {
            _products.Remove(product);
            Debug.LogWarning(product + "removed");
        }
        
        public bool IsEmpty()
        {
            return TakeFirstProduct() == null;
        }
        
        public bool IsFull()
        {
            return _products.Count >= _maxCount;
        }
        
        public Product TakeFirstProduct()
        {
            if (_products != null)
            {
                if (_products.Count <= 0)
                {
                    Debug.LogWarning("there is no product");
                    return null;
                }
                else
                {
                    Product product = _products.First();
                    return product;
                }
            }
            return null;
        }
        
        public void ClearProducts()
        {
            _products.Clear();
        }
        public Product GetProduct(ProductSO productData)
        {
            Product product = _products.Find(product => product.GetProductSO() == productData);
            if (product != null)
            {
                RomoveProduct(product);
                return product;
            }
            else
            {
                return null;
            }
        }
    }
}