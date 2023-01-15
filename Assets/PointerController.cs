using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class PointerController : MonoBehaviour
{
    ActionBasedController controller;
    public TMP_Text temp;
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
        float rot = controller.rotationAction.action.ReadValue<Quaternion>().eulerAngles.z;
        float ans = 0;
        if(rot<100){
            ans = 68f-rot/4f;


        }else{
            ans = 68f+(360-rot)/4f;
        }
        ans = Mathf.Clamp(ans,50,80);
        temp.text = "Set Temperature: " + ((int)ans).ToString() + " ° F";
        if (ans < 68) {
            temp.color = Color.blue;
        } else {
            temp.color = Color.red;
        }
        

        
    }
}
