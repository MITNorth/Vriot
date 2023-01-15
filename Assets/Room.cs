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
    public GameObject XROrigin;
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
   
    public void hoverEnterRoom(){
        if(XROrigin.transform.position==Vector3.zero){
            renderer.material = trans;
        }else{
            renderer.material=orig;
        }
    
    }
    public void hoverExitRoom(){
        renderer.material = orig;
    }
}
