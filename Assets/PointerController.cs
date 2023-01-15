using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class PointerController : MonoBehaviour
{
    ActionBasedController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.selectAction.action.ReadValue<float>()!=0){
            GetComponent<XRRayInteractor>().enabled = true;
        }else{
            GetComponent<XRRayInteractor>().enabled = false;
        }
        
    }
}
