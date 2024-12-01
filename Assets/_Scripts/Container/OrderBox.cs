
using System.Collections.Generic;
using _Scripts.Market;

namespace _Scripts.Player
{
    public class OrderBox : BaseContainer
    {
        public void Initialize(List<Product> products)
        {
            foreach (var product in products)
            {
                AddProduct(product);
            }
        }
        public override void Interact(Player player)
        {
            transform.parent = player.transform;
            player.SetContainer(this);
        }
    }
}