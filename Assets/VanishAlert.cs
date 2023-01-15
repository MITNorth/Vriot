using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishAlert : MonoBehaviour
{
    float totalTime=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime+=Time.deltaTime;
        Vector3 vec = new Vector3(Mathf.Abs(Mathf.Sin(totalTime*0.9f)), Mathf.Abs(Mathf.Sin(totalTime*0.9f)), Mathf.Abs(Mathf.Sin(totalTime*0.9f)));
        transform.localScale = vec; 
       if(totalTime>3){
        gameObject.SetActive(false);
        totalTime = 0;
        transform.localScale = Vector3.zero;

       }
    }
}
