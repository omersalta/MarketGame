using UnityEngine;

namespace _Scripts.ContainerSystem
{
    public interface IHolder
    {
        public Transform GetHolderAsParent();
        public void SetHoldingItem (IHoldable item);
        public IHoldable GetHoldingItem ();
    }
}