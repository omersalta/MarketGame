using _Scripts._Player;
using _Scripts.ContainerSystem;
using UnityEngine;

namespace _Scripts
{
    public class Shelf : BaseContainer,IInteractable
    {
        public virtual void Interact(Player player)
        {
            var container = player.GetContainer();

            if (!container.IsEmpty())
            {
                Product product = container.TakeFirstProduct();
                container.RomoveProduct(product);
                AddProduct(product);
                Debug.Log("product added :" + product.name);
            }
            else
            {
                Debug.LogWarning("there is no product to add");
            }
        }
        public virtual void InteractAlternate(Player player)
        {
            var container = player.GetContainer();

            if (!container.IsFull())
            {
                if (!IsEmpty())
                {
                    Product product = TakeFirstProduct();
                    RomoveProduct(product);
                    container.AddProduct(product);
                    Debug.Log("product added :" + product.name);
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
            return !IsEmpty();
        }


    }
}