using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public List<Item> uniqueItems;
    public List<GameObject> items;
    public int itemsCount;
    public int target;
    //public Image targetUIImage;
    public GameManager gameManager;
    // The GameObject to instantiate.
    
    public void StartGame()
    {
        Reset(itemsCount);
    }
    void Refill()
    {
        SpawnItems(15);
    }
    public void SetTarget(GameObject go)
    {
        print("Hello" + target);
        go.GetComponent<SpriteRenderer>().color = Color.red;
        go.GetComponent<ItemController>().value = 5;
        //targetUIImage.sprite = items[target].GetComponent<SpriteRenderer>().sprite;
        //targetUIImage.color = go.GetComponent<SpriteRenderer>().color;
        /*
        items[targetNum].target = true;
        items[targetNum].obj.GetComponent<SpriteRenderer>().color = Color.yellow;
        */

    }

    public void CreateItems(int n)
    {
        SpawnItems(n);
    }

    void FillItemList(int num)
    {
        for(int i = 0; i < num; i++)
        {
            // Could be a random number
            items.Add(uniqueItems[Random.Range(0,uniqueItems.Count)].obj);
        }
    }
    public void ClaimStonks()
    {
        //Remove stonks from box

        //Add/sub tokens
        //Reset Play Timer
        gameManager.NewRound(CalculateTokens());
        RemoveStonks();

    }
    int CalculateTokens()
    {
        int sum = 0;
        for (int i = 0; i < dropBox.itemsCollected.Count; i++)
        {
            if (dropBox.itemsCollected[i].GetComponent<ItemController>().isClaimable)
            {
                sum += dropBox.itemsCollected[i].GetComponent<ItemController>().value;
            }
        }
        return sum;
    }

    public BoxCollection dropBox;
    public void RemoveStonks()
    {
        for(int i = 0; i < dropBox.itemsCollected.Count; i++)
        {
            if (dropBox.itemsCollected[i].GetComponent<ItemController>().itemName == items[dropBox.itemsCollected[i].GetComponent<ItemController>().index].GetComponent<ItemController>().itemName)
            {
                GameObject go = dropBox.itemsCollected[i];
                dropBox.itemsCollected.Remove(dropBox.itemsCollected[i]);
                Destroy(go);
                
            }
        }
        
    }
    public void Reset(int num)
    {
        items.Clear();
        FillItemList(num);
        target = Random.Range(0, items.Count);
        SpawnItems(items.Count);
    }
    void SpawnItems(int itemNum)
    {
        for(int i = 0; i < itemNum; i++)
        {
            
            GameObject go = Instantiate(items[i], transform.position + new Vector3(Random.Range(-1.0f,1.0f)/.5f, Random.Range(-1.0f, 1.0f) / 1.0f,0), transform.rotation);
            go.GetComponent<ItemController>().index = i;
            go.GetComponent<ItemController>().value = 1;
            if (i == target)
            {
                go.GetComponent<ItemController>().target = true;
                SetTarget(go);
            }
        }
    }
    
}
