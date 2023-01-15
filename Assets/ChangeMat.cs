using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    public Material trans;
    public Material oldMat;
    // Start is called before the first frame update
    Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        oldMat = renderer.material;
        
    }

    // Update is called once per frame
    void transp()
    {
        renderer.material = trans;
        
    }
    void untransp(){
        renderer.material = oldMat;
    }
}
