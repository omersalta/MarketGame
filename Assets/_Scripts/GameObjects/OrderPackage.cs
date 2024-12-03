using System;
using System.Collections.Generic;
using _Scripts.ContainerSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.GameObjects
{
    public class OrderPackage : BaseHoldableContainer
    {
        public List<ProductType> ProductTypes;
        
        private void Start()
        {
            List<Product> productsInPackage = new List<Product>();
            
            if (ProductTypes != null)
            {
                foreach (ProductType productType in ProductTypes)
                {
                    if (productType.Quantity > 0 && productType.Quantity < int.MaxValue)
                    {
                        for (int i = 0; i < productType.Quantity; i++)
                        {
                            Product product = ProductSO.SpawnProduct(productType.ProductSO);
                            product.transform.parent = transform;
                            product.transform.localPosition = Vector3.zero;
                            productsInPackage.Add(product);
                        }
                    }
                    else
                    {
                        Debug.LogWarning("productType.Quantity is invalid");
                    }
                    
                }
                
            }
                
            Initialize(productsInPackage.Count,productsInPackage,null);
        }
    }
    
    [Serializable]
    public class ProductType
    {
        public ProductSO ProductSO;
        public int Quantity;
    }
    
}