using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour
{
    public GameObject statsPanel;
    public GameObject tempPanel;
    public GameObject rc;

    public GameObject notifs;
    
    public static GlobalContainer instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
