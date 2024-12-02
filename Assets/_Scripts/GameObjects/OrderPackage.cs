using System.Collections.Generic;
using _Scripts._Player;
using _Scripts.ContainerSystem;
using UnityEngine;

namespace _Scripts
{
    public class OrderPackage : BaseContainer,IHoldable
    {
        private bool _hasHolder = false;
        
        public void Initialize(List<Product> products)
        {
            _hasHolder = false;
            foreach (var product in products)
            {
                AddProduct(product);
            }
        }
        
        public void Interact(Player player)
        {
            if (_hasHolder)
            {
                Debug.LogWarning("holded already by anyone");
            }
            else
            {
                OnHold(player);
            }
        }
        
        public void InteractAlternate(Player player)
        {
            if (_hasHolder)
            {
                OnDrop(player);
                
            }
            else
            {
                Debug.LogWarning("there is no holder");
            }
        }
        
        public void OnSelection()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEnable()
        {
            return !_hasHolder;
        }
        
        public virtual void OnHold(Player player)
        {
            transform.parent = player.transform;
            //todo maybe local position set to zero
            _hasHolder = true;
        }
        
        public virtual void OnDrop(Player player)
        {
            transform.parent = null;
            _hasHolder = false;
        }
    }
}