using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class HouseController : MonoBehaviour
{
 
    public GameObject rc;
    ActionBasedController controller;
    // Start is called before the first frame update
    void Start()
    {
         controller= rc.GetComponent<ActionBasedController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float xAxis = controller.rotateAnchorAction.action.ReadValue<Vector2>().x;

        if(xAxis!=0){
            transform.Rotate(new Vector3(0,Mathf.Sign(xAxis),0));
        }
        
    }
    void highlight(){
        
    }
}
