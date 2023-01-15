using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class OrbController : MonoBehaviour
{
    // Start is called before the first frame update

    ActionBasedController controller;
    public GameObject rc;
    Transform orbs;
    void Start()
    {
        controller = GetComponent<ActionBasedController>(); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(orbs==null&&rc.transform.GetChild(0).childCount!=0){
            orbs = rc.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).Find("Menu Orbs");
            return;
            
        }
        if(orbs==null){
            return;
        }
        float xAxis = controller.rotateAnchorAction.action.ReadValue<Vector2>().x;
        if (xAxis!=0){
            orbs.Rotate(new Vector3(0,0,1.3f*Mathf.Sign(xAxis)));
        }

        
    }
}
