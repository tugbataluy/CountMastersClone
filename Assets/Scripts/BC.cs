using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go;
    void Start()
    {
        Instantiate(go, this.transform.position, Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
