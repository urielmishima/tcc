using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    #region Singleton

    public static ItemHandler instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    #endregion

    [SerializeField] private List<Item> items = new List<Item>();
    private int itemIndex = 0;
    private GameObject currentItemPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentItemPrefab.GetComponent<IToggleable>().Toggle();
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            nextItem();
        }
    }

    private void nextItem()
    {
        if (++itemIndex >= items.Count)
        {
            itemIndex = 0;
        }
        Destroy(currentItemPrefab);
        currentItemPrefab = Instantiate(items[itemIndex].Prefab, transform);
    }

    public void PickUp(Item item)
    {
        items.Add(item);
        if (currentItemPrefab == null)
        {
            nextItem();
        }
    }
}
