using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollection : MonoBehaviour
{
    public ItemManager itemManager;
    public List<GameObject> itemsCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            itemsCollected.Add(collision.gameObject);
            //itemManager.RemoveItem(collision.gameObject.GetComponent<ItemController>().name);
            //Destroy(collision.gameObject);
        }
    }

}
