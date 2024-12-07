using System;
using System.Collections.Generic;
using _Scripts.ContainerSystem;
using UnityEngine;

namespace _Scripts.GameObjects
{
    public class OrderPackage : BaseHoldableContainer
    {
        public List<ProductType> ProductTypesIncluded;

        private void Start()
        {
            List<Product> productsInPackage = new List<Product>();
            
            if (ProductTypesIncluded != null)
            {
                foreach (ProductType productType in ProductTypesIncluded)
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
            
            Initialize(productsInPackage);
        }

        private void Initialize(List<Product> productsInPackage)
        {
            base.Initialize(productsInPackage.Count,productsInPackage,null);
        }
    }
    
    [Serializable]
    public class ProductType
    {
        public ProductSO ProductSO;
        public int Quantity;
    }
    
}