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

    [SerializeField] private List<ItemScriptableObject> items = new List<ItemScriptableObject>();
    private int itemIndex = 0;
    private ItemPickup currentItemPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentItemPrefab)
                currentItemPrefab.GetComponent<IToggleable>().Toggle();
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            nextItem();
        }
    }

    private void nextItem()
    {
        if (items.Count < 1)
            return;

        if (++itemIndex >= items.Count)
        {
            itemIndex = 0;
        }
        Destroy(currentItemPrefab);
        currentItemPrefab = Instantiate(items[itemIndex].prefab, transform);
        Destroy(currentItemPrefab.GetComponent<Rigidbody>());
    }

    public void PickUp(ItemScriptableObject item)
    {
        items.Add(item);
        if (currentItemPrefab == null)
        {
            nextItem();
        }
    }
}
