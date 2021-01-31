using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int index;
    public string itemName;
    public int value;
    public bool target;
    public bool isClaimable = false;
    public ItemManager itemManager;
    // Start is called before the first frame update
    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DropBox")
        {
            isClaimable = true;
        }
    }
}
