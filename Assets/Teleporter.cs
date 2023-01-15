using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    ActionBasedController controller; 
    public GameObject xrOrigin;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float trigger =(controller.activateAction.action.ReadValue<float>());
        if(trigger!=0){
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, 30)){
                xrOrigin.transform.position = hit.collider.transform.GetChild(0).transform.position;
            }
            else{
                Debug.Log("Did not Hit");
            }
        }
        
    }
}
