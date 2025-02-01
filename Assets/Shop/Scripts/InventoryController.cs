using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static BuyHandler buyHandler;

    public TextMeshProUGUI cashText, subtitles;
    public Transform inventory;
    public int cash;

    private List<Image> slots = new();
    public List<FoodObject> invContent = new(6);

    private void Awake()
    {
        ItemController.inventoryController = this;
        BuyHandler.inventoryController = this;

        cashText.text = cash.ToString();
        for (int i = 0; i < inventory.childCount; i++)
        {
            slots.Add(inventory.GetChild(i).GetComponent<Image>());
        }
    }

    public bool AddItem(FoodObject food)
    {
        for (int i = 0; i < invContent.Count; i++)
        {
            if (invContent[i] == null)
            {
                invContent[i] = food;
                slots[i].sprite = food.sprite;
                slots[i].color = Color.white;
                buyHandler.UpdateFood(invContent);
                return true;
            }
        }
        return false;
    }

    public void DeleteItem(FoodObject food)
    {
        int index = invContent.FindIndex((FoodObject) => food);
        slots[index].sprite = null;
        slots[index].color = new Color(1f, 1f, 1f, 0f);
        invContent[index] = null;
    }

    public void TypeSorry()
    {
        subtitles.color = Color.white;
        subtitles.DOColor(new Color(1f, 1f, 1f, 0f), 1f);
    }
}
