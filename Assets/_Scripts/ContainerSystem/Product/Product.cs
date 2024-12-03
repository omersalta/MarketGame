using UnityEngine;

namespace _Scripts.ContainerSystem
{
    public class Product : MonoBehaviour
    {
        private IProductContainer _container;
        [SerializeField] private ProductSO _ProductSo;
    
        public ProductSO GetProductSO()
        {
            return _ProductSo;
        }
        public void SetContainer(IProductContainer container)
        {
            if (container == null)
            {
                _container = null;
                Debug.LogError("container is null for product Object");
                return;
            }
            else
            {
                if (_container != null)
                {
                    if (container.IsFull())
                    {
                        Debug.LogWarning("container is full");
                        return;
                    }
                }
                
                _container?.RomoveProduct(this);
                _container = container;
                _container.AddProduct(this);
            }
        }
        // Start is called before the first frame update
        public IProductContainer GetContainer()
        {
            return _container;
        }
        


    
    }
}
