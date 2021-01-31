using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public List<Item> uniqueItems;
    public List<GameObject> items;
    //public Item item;
    public int itemsCount;
    public int target;
    public Image targetUIImage;
    private void Start()
    {
        FillItemList();
        target = Random.Range(0, items.Count);
        SpawnItems();

    }
    public void SetTarget(GameObject go)
    {
        print("Hello" + target);
        go.GetComponent<SpriteRenderer>().color = Color.red;
        //targetUIImage.sprite = items[target].GetComponent<SpriteRenderer>().sprite;
        targetUIImage.color = go.GetComponent<SpriteRenderer>().color;
        /*
        items[targetNum].target = true;
        items[targetNum].obj.GetComponent<SpriteRenderer>().color = Color.yellow;
        */

    }

    public void CreateItems()
    {
        SpawnItems();
    }

    void FillItemList()
    {
        for(int i = 0; i < itemsCount; i++)
        {
            // Could be a random number
            items.Add(uniqueItems[Random.Range(0,uniqueItems.Count)].obj);
        }
    }

    public void RemoveItem(Item item)
    {
        bool removedItem = false;
        for(int i = 0; i < items.Count; i++)
        {
            if(true)//items[i].itemName == item.itemName)
            {
                items.Remove(items[i]);
                removedItem = true;
                i = items.Count + 1;
            }
        }
        if (removedItem)
        {
            
        }
    }

    void SpawnItems()
    {
        for(int i = 0; i < items.Count; i++)
        {
            
            GameObject go = Instantiate(items[i], transform.position + new Vector3(Random.Range(-1.0f,1.0f)/1.0f, Random.Range(-1.0f, 1.0f) / 1.0f,0), transform.rotation);
            if (i == target) { SetTarget(go); }
        }
    }
    
}
