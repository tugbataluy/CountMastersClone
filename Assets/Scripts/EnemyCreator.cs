using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnemyCreator : MonoBehaviour
{
    // Start is called before the first frame update
    public  int amount;
    public Vector3 position;
    public GameObject go;
    public Text at;
    int current;
    Animator anim;
    GameObject charcreator;
    public List<GameObject> enemies=new List<GameObject>();
    void Start()
    {
       
        charcreator = GameObject.Find("MainPlayer");
        at=(this.transform.GetChild(0)).GetChild(0).gameObject.GetComponent<Text>();
       
        CreateEnemies(amount );
        at.text =(this.transform.childCount-2).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        at.text = (this.transform.childCount - 2).ToString();
        
            
          
            
         
        

    }
    public void CreateEnemies(int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject en = Instantiate(go,this.transform.position+Random.insideUnitSphere, Quaternion.identity, this.transform);
            
            current++;
            enemies.Add(en);         
        }
    
    
    }
  
    public void GaveThemAnimation()
     {
       
        foreach (GameObject enemy in enemies)
        {
            
            Animator anim = enemy.GetComponent<Animator>();
            anim.SetBool("Run", true);
            
        }
       
    
    
    }

}
