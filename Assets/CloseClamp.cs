using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseClamp : MonoBehaviour
{
    BoxCollider2D coll;
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }
    public void CloseAndOpen()
    {
        coll.enabled = !coll.enabled;
    }
}
