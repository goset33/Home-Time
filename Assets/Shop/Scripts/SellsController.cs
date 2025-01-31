using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SellsController : MonoBehaviour
{
    public Sprite checkmarkSprite;

    public List<FoodObject> reqiredFood = new List<FoodObject>();
    private List<Transform> foods = new();

    public UnityEvent onAllBought;

    private void Awake()
    {
        ItemController.sellsController = this;
        for (int i = 0; i < transform.childCount; i++)
        {
            foods.Add(transform.GetChild(i));
        }
    }

    public void ItemBought(FoodObject food)
    {
        if (reqiredFood.Contains(food))
        {
            int index = reqiredFood.IndexOf(food);
            foods[index].GetChild(1).GetComponent<Image>().sprite = checkmarkSprite;
            reqiredFood.Remove(food);

            if (reqiredFood.Count == 0)
            {
                onAllBought?.Invoke();
            }
        }
    }

}
