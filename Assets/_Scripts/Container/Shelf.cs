using UnityEngine;

namespace _Scripts.Market
{
    public class Shelf : BaseContainer
    {

        public override void Interact(Player.Player player)
        {
            if (player.CurrentContainer == null)
            {
                return;
            }
            
            if (player.CurrentContainer.HasMarketObject())
            {
                Product product = player.CurrentContainer.TakeFirstProduct();
                player.CurrentContainer.RomoveProduct(product);
                AddProduct(product);
                Debug.Log("product added :" + product.name);
            }
        }
    }
}