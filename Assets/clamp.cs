using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clamp : MonoBehaviour
{
    public OnScreenStickCustom controlstick;
    public Transform clampTop, wire;
    public SkinnedMeshRenderer skin;
    // Start is called before the first frame update
    void Start()
    {
        if(controlstick == null)
        {
            controlstick = FindObjectOfType<OnScreenStickCustom>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        clampTop.position += new Vector3(controlstick.stickPosition.x, 0f, 0f) * Time.fixedDeltaTime;
        wire.position += new Vector3(0f, controlstick.stickPosition.y, 0f) * Time.fixedDeltaTime;
        ClampClamp();
    }
    public float xBound, yBound, zBound;
    void ClampClamp()
    {
        //Clamp Top
        clampTop.position = new Vector3(Mathf.Clamp(clampTop.position.x, -4, 4), clampTop.position.y, clampTop.position.z);
        wire.position = new Vector3(wire.position.x, Mathf.Clamp(wire.position.y, -.5f, 2), wire.position.z);
        

    }
    public void ToggleClamps()
    {
        if(skin.GetBlendShapeWeight(0) == 100f)
        {
            skin.SetBlendShapeWeight(0, 0f);
        }
        else
        {
            skin.SetBlendShapeWeight(0, 100f);
        }
        
    }
}
