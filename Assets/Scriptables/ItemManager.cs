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
    
    // The GameObject to instantiate.
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public ItemSpawnerScriptableObject issoValues;
    private Sprite[] sprites;
    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;
    void SpawnEntities()
    {
        int currentSpawnPointIndex = 0;
        sprites = Resources.LoadAll<Sprite>("art/ArcadeItems/compositefiles/16x16-black-outline.png");
        for (int i = 0; i < issoValues.numberOfPrefabsToCreate; i++)
        {
            // Creates an instance of the prefab at the current spawn point.
            GameObject currentEntity = Instantiate(entityToSpawn, issoValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);

            // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currentEntity.name = issoValues.prefabName + instanceNumber;

            
            currentEntity.GetComponent<SpriteRenderer>().sprite = sprites[0];

            // Moves to the next spawn point index. If it goes out of range, it wraps back to the start.

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % issoValues.spawnPoints.Length;

            instanceNumber++;
        }
    }
    private void Update()
    {
    }
    private void Start()
    {
        //timer = 0.0f;
        //SpawnEntities();
        FillItemList();
        target = Random.Range(0, items.Count);
        SpawnItems(items.Count);

    }
    public void SetTarget(GameObject go)
    {
        print("Hello" + target);
        go.GetComponent<SpriteRenderer>().color = Color.red;
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

    void FillItemList()
    {
        for(int i = 0; i < itemsCount; i++)
        {
            // Could be a random number
            items.Add(uniqueItems[Random.Range(0,uniqueItems.Count)].obj);
        }
    }

    public void RemoveItem(string name)
    {
        //Find item
        for(int i = 0; i < items.Count; i++)
        {
            
            string tempName = name.Substring(0, name.Length - 7);
            print(tempName + " " + items[i].name);
            
            if (items[i].name == tempName)
                if (items[i].name == name)
            {
                items.Remove(items[i]);
            }
        }
        
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
