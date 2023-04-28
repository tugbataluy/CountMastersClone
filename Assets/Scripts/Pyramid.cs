using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 0);
        for (int i = 0; i < this.transform.childCount; i++) { 
        this.transform.GetChild(i).gameObject.transform.Rotate(0,0,0);
        
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder") {
            
            this.transform.parent=null;
        }
    }
}
