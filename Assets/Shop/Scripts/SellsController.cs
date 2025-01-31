using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SellsController : MonoBehaviour
{
    public Sprite checkmarkSprite;

    private List<Transform> foodsText = new();

    private void Awake()
    {
        BuyHandler.sellsController = this;
        for (int i = 0; i < transform.childCount; i++)
        {
            foodsText.Add(transform.GetChild(i));
        }
    }

    public void ItemBought(int index)
    {
        foodsText[index].GetChild(1).GetComponent<Image>().sprite = checkmarkSprite;
    }
}
