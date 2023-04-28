using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gmMobile : MonoBehaviour
{
    // Start is called before the first frame update
    Touch t;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<CharacterCreator>().isCollided == false && !this.gameObject.GetComponent<CharacterCreator>().isFinished)
        {
            if (Input.touchCount > 0)
            {
                t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z + t.deltaPosition.x * 0.02f);

                }
            }
        }
       
    }
}
