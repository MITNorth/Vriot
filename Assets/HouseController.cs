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
        float yAxis = controller.translateAnchorAction.action.ReadValue<Vector2>().y;

        if(xAxis!=0){
            transform.Rotate(new Vector3(0,Mathf.Sign(xAxis),0));
        }
        if(yAxis!=0){
            transform.Rotate(new Vector3(0,0,Mathf.Sign(yAxis)));
        }
        transform.Rotate(0,0,Mathf.LerpAngle(0,transform.rotation.eulerAngles.z,Time.deltaTime));


        
    }
    void highlight(){
        
    }
}
