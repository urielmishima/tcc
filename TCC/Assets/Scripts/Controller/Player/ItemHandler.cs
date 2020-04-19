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

    public GameObject CurrentItem { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(CurrentItem)
                CurrentItem.GetComponent<IToggleable>().Toggle();
            
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

        Destroy(CurrentItem);
        CurrentItem = Instantiate(items[itemIndex].prefab, transform);
        Destroy(CurrentItem.GetComponent<Rigidbody>());
    }

    public void PickUp(ItemScriptableObject item)
    {
        items.Add(item);
        if (CurrentItem == null)
        {
            nextItem();
        }
    }

    public ItemScriptableObject useItem ()
    {
        if (items.Count < 1)
            return null;

        ItemScriptableObject currentItem = items[itemIndex];
        items.RemoveAt(itemIndex--);
        Destroy(CurrentItem);
        nextItem();

        return currentItem;
    }
}
