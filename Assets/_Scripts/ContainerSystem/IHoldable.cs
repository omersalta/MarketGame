using _Scripts._Player;

namespace _Scripts.ContainerSystem
{
    public interface IHoldable : IInteractable
    {
        public void SetHolder(IHolder holder);
        public IHolder GetHolder();
        public bool HasHolder();
    }
}