using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyHandler : MonoBehaviour
{
    public static InventoryController inventoryController;
    public static SellsController sellsController;

    public Transform player;

    public GameObject content, buyCardPrefab;
    public TextMeshProUGUI allPriceText;
    private int allPrice = 0;

    public List<FoodObject> reqiredFood = new();
    public List<FoodObject> boughtFood = new(6);

    private void Awake()
    {
        ItemController.buyHandler = this;
        InventoryController.buyHandler = this;
    }

    public void ItemAdded(FoodObject food)
    {
        for (int i = 0; i < boughtFood.Count; i++)
        {
            if (boughtFood[i] == null)
            {
                boughtFood[i] = food;
                AddInUI(food, i);
                sellsController.ItemBought(reqiredFood.IndexOf(food));
                break;
            }
        }
    }

    public void AddInUI(FoodObject food, int index)
    {
        GameObject newCard = Instantiate(buyCardPrefab, content.transform);
        newCard.transform.SetSiblingIndex(index);
        newCard.GetComponentInChildren<TextMeshProUGUI>().text = $"{food.ruName} - {food.price}";
        allPrice += food.price;
        allPriceText.text = $"Цена:\n{allPrice}";
        newCard.GetComponentInChildren<Button>().onClick.AddListener(() => RemoveSomething(food));
    }

    public void RemoveSomething(FoodObject food)
    {
        int index = boughtFood.FindIndex((FoodObject) => food);
        Destroy(content.transform.GetChild(index).gameObject);
        boughtFood[index] = null;
        allPrice -= food.price;
        allPriceText.text = $"Цена:\n{allPrice}";

        inventoryController.DeleteItem(food);
    }

    public void OnBuyPressed()
    {
        if (inventoryController.cash >= allPrice)
        {
            inventoryController.cash -= allPrice;
            inventoryController.cashText.text = inventoryController.cash.ToString();

            player.position = new Vector3(-23.5f, 0f, 4f);
        }
    }
}
