using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour

{
    int[] triangles = { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210, 231, 253, 276, 300, 325, 351, 378, 406, 435, 465 };
    public GameObject go;
    int ammo;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        ammo = go.GetComponent<CharacterCreator>().currentAmount;
    }
    void Find() {
        int stop = 0;
        for (int i = 0; i < triangles.Length; i++)
        {
            if (ammo >= triangles[i])
            {
                stop++;

            }



        }
    }
    private void CollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "playerclone") {
            print(ammo);
        }
    }
}
