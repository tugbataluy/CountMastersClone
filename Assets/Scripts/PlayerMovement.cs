using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalSpeed;
    public float verticalSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (this.gameObject.GetComponent<CharacterCreator>().isCollided == false)


        {
            float horizontalAxis = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
            this.transform.Translate(horizontalAxis, 0, verticalSpeed * Time.deltaTime);
        }
        
        else {

            this.transform.Translate(0, 0, verticalSpeed/4f * Time.deltaTime);


        }
                 
       


    }
}
