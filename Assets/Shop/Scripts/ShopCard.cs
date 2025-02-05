using UnityEngine;

public class ShopCard : MonoBehaviour
{
    public static BuyHandler buyHandler;

    public FoodObject scriptableInstance;

    public void OnDelete()
    {
        buyHandler.RemoveSomething(scriptableInstance);
    }
}
