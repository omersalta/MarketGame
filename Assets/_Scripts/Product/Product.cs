using System.ComponentModel;
using _Scripts.Market;
using UnityEngine;

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
        
        if (container.IsFull())
        {
            Debug.LogWarning("container is full");
        }
        else
        {
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
