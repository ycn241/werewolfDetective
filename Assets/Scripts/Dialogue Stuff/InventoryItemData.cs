using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : MonoBehaviour
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
}
