using System;
using _Scripts._Player;
using _Scripts.ContainerSystem;
using _Scripts.Customer;
using UnityEngine;

namespace _Scripts
{
    public class Shelf : BaseContainer,IInteractable,ICustomerShelf
    {
        [SerializeField] protected int maxCount;
        
        private void Start()
        {
            Initialize(maxCount,null);
        }
        public virtual void Interact(Player player)
        {
            var container = player.GetContainer();

            if (!container.IsEmpty())
            {
                Product product = container.TakeFirstProduct();
                if (product != null)
                {
                    AddProduct(product);
                    Debug.Log("product added :" + product.name);
                }
                else
                {
                    Debug.LogWarning("player has no product");
                }
            }
            else
            {
                Debug.LogWarning("there is no product to add");
            }
        }
        public virtual void InteractAlternate(Player player)
        {
            var playerContainer = player.GetContainer();

            if (!playerContainer.IsFull())
            {
                if (!IsEmpty())
                {
                    Product product = TakeFirstProduct();
                    if (product != null)
                    {
                        player.GetContainer().AddProduct(product);
                        Debug.Log("product added :" + product.name);
                    }
                    else
                    {
                        Debug.LogWarning("Shelf is Empty or something went wrong");
                    }
                   
                }
                else
                {
                    Debug.LogWarning("Shelf is Empty");
                }
            }
            else
            {
                Debug.LogWarning("container is full");
            }
        }
        public virtual void OnSelection()
        {
            throw new System.NotImplementedException();
        }
        public bool IsEnable()
        {
            return true;
        }
        public Product TakeProduct(ProductSO productData)
        {
            return GetProduct(productData);
        }
        public bool IsThereProduct(ProductSO productData)
        {
            return TakeProduct(productData) != null;
        }
    }
}