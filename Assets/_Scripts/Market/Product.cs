using System.ComponentModel;
using _Scripts.Market;
using UnityEngine;

public class Product : MonoBehaviour
{
    private IProductPool _container;
    
    // Start is called before the first frame update
    public IProductPool GetContainer()
    {
        return _container;
    }
    
    public void SetContainer(IProductPool container)
    {
        if (container == null)
        {
            _container = null;
            return;
        }
        
        if (container.IsFull())
        {
            Debug.LogWarning("container is full");
        }
        else
        {
            _container = container;
            _container.AddProduct(this);
        }
    }
    
}
