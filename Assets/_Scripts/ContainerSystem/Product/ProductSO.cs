using UnityEngine;

namespace _Scripts.ContainerSystem
{
    [CreateAssetMenu]
    public class ProductSO : ScriptableObject
    {
        public Transform prefab;
        public Sprite sprite;
        public string ObjectNames;
        
        public static Product SpawnProduct(ProductSO productSO)
        {
            Product product = Instantiate(productSO.prefab).GetComponent<Product>();
            return product;
        }
    }
}