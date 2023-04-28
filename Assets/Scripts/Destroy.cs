using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") {

            int no = other.transform.parent.childCount;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            print(no+"B");
           
            
               
            
               
            
            

        }
    }
}

