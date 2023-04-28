using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    public Vector3 distance;
    void Start()
    {
        target = GameObject.Find("MainPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position+distance, Time.deltaTime);
    }
}
