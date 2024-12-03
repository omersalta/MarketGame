using _Scripts.ContainerSystem;
using UnityEngine;

namespace _Scripts._Player
{
    public class PlayerHandContainer : BaseContainer,IHolder
    {
        private IHoldable _holdedItem;
        
        public void Initialize(int maxCount)
        {
            base.Initialize(maxCount,null);
        }
        public Transform GetHolderAsParent()
        {
            return transform;
        }
        public void SetHoldingItem(IHoldable item)
        {
            if (item == null)
            {
                _holdedItem = null;
                return;
            }
            else
            {
                if (_holdedItem == null)
                {
                    _holdedItem = item;
                }
                else
                {
                    Debug.Log("Holder already has a item");
                }
            }
            
        }
        public IHoldable GetHoldingItem()
        {
            return _holdedItem;
        }
    }
}