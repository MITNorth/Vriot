using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    Material orig;
    Renderer renderer;
    public Material trans;
    public GameObject xrOrigin;
    BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        orig = renderer.material;
        box = GetComponent<BoxCollider>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void portToRoom(){
        xrOrigin.transform.position = box.center;

    }
    public void hoverEnterRoom(){
        renderer.material = trans;
    
    }
    public void hoverExitRoom(){
        renderer.material = orig;
    }
}
