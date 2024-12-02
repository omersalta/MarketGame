using _Scripts._Player;

namespace _Scripts.ContainerSystem
{
    public interface IHoldable : IInteractable
    {
        public void OnHold(Player player);
        public void OnDrop(Player player);
    }
}