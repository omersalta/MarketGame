using _Scripts._Player;

namespace _Scripts.ContainerSystem
{
    public interface IInteractable
    {
        public void Interact (Player player);
        public void InteractAlternate (Player player);
        public void OnSelection();
        public bool IsEnable();
    }
}