using System.Collections.Generic;
using _Scripts._Player;
using UnityEngine;

namespace _Scripts.ContainerSystem
{
    public abstract class BaseHoldableContainer : BaseContainer,IHoldable
    {
        private IHolder _holder;
        
        public void Initialize(int maxCount, List<Product> products,IHolder holder)
        {
            base.Initialize(maxCount,products);
            _holder = holder;
        }
        public void Interact(Player player)
        {
            if (_holder != null)
            {
                Debug.LogWarning("holded already by anyone");
            }
            else
            {
                SetHolder(player.GetContainer() as PlayerHandContainer);
            }
        }
        public void InteractAlternate(Player player)
        { 
            Debug.LogWarning("there is no InteractAlternate action in this object");
        }
        public void OnSelection()
        {
            throw new System.NotImplementedException();
        }
        public bool IsEnable()
        {
            return !HasHolder();
        }
        public void SetHolder(IHolder holder)
        {
            if (holder == null)
            {
                if (HasHolder())
                {
                    Debug.Log(gameObject.name + " Item is droped");
                }
            }
            else
            {
                if (HasHolder())
                {
                    Debug.LogWarning(gameObject.name + " Item is already has a holder");
                }
                else
                {
                    gameObject.layer = LayerMask.NameToLayer("NonInterractable");
                    _holder = holder;
                    _holder.SetHoldingItem(this);
                    transform.parent = _holder.GetHolderAsParent();
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.identity;
                    
                }
            }
        }
        public IHolder GetHolder()
        {
            return _holder;
        }
        public bool HasHolder()
        {
            return GetHolder() != null;
        }
    }
}