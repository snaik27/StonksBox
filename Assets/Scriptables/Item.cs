using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public int value;
    public bool target;
    public GameObject obj;


}
