using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "item")]
public class Item : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    private GameObject itemPickup;

    public GameObject Prefab { get => prefab; set => prefab = value; }
}
