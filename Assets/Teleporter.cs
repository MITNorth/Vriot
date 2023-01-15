using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Requests;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    ActionBasedController controller; 
    public GameObject xrOrigin;
    private bool changed = false;

    LightsRequest lr;

    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        lr = new LightsRequest();
    }

    // Update is called once per frame
    void Update()
    {
        float trigger =(controller.activateAction.action.ReadValue<float>());
        if(trigger!=0){
            RaycastHit hit;
            int layerMask = 1<<6;
            if(xrOrigin.transform.position==Vector3.zero){
                layerMask = ~layerMask;

            }
            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, 30,layerMask)){
                if(layerMask == 1<<6){
                    if (!changed) {
                        hit.collider.gameObject.GetComponent<Light>().enabled = !hit.collider.gameObject.GetComponent<Light>().enabled;
                        hit.collider.gameObject.GetComponent<AudioSource>().Play();
                        int roomNumber = int.Parse(hit.collider.gameObject.transform.parent.gameObject.name);
                        
                        StartCoroutine(lr.UpdateRequest(roomNumber, hit.collider.gameObject.GetComponent<Light>().enabled));
                    }

                    changed = true;



                }else{

                    xrOrigin.transform.position = hit.collider.transform.GetChild(0).transform.position;

                }

            }
            else{
                Debug.Log("Did not Hit");
            }
        } else {
            changed = false;
        }
        
    }
}
