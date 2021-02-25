using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZyliaSettings : MonoBehaviour
{

    public GameObject transparentSphere;
    public GameObject axes;
    // Start is called before the first frame update
    void Start()
    {

        transparentSphere = GameObject.Find("Sphere");
        axes = GameObject.Find("Zylia Axes");


        transparentSphere.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
