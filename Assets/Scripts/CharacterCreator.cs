using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class CharacterCreator : MonoBehaviour
{
    // Start is called before the first frame update
   public  int currentAmount;
    Text amounttext;
    public GameObject go;
    GameObject ec;
    public List<GameObject> players=new List<GameObject>();
    public bool isCollided=false;
    public int index;
    public List<Transform> positions=new List<Transform>();
    Animator animator;
    public List<GameObject> levels=new List<GameObject>();
    GameObject go2;
    public bool isFinished = false;
    int[] triangles = { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 };
    int call;
   
   
    void Start()
    {
      
        GameObject c = Instantiate(go, this.transform.position, Quaternion.identity, this.transform);
        c.transform.localRotation = Quaternion.Euler(0, 0, 0);
        players.Add(c);
        ec = GameObject.FindGameObjectWithTag("MainEnemy");      
        amounttext= (this.transform.GetChild(0)).GetChild(0).gameObject.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAmount = this.transform.childCount-2;
       
        amounttext.text = currentAmount.ToString();
        if (currentAmount == 0 && !isFinished) {
            SceneManager.LoadScene("SampleScene");
        
        }
        if (this.transform.position.x <= -190.9) {
            isFinished = true;
           
           
            this.transform.GetChild(0).gameObject.SetActive(false);
            if (call == 0) {
                this.transform.position = new Vector3(-190.9f,2,0);

                if (currentAmount < triangles[Find()]) {
                    CreateCharacters(triangles[Find()] - currentAmount);
                    
                    
                    
                }
              
                call++;
               StartCoroutine( MakeEmTriangle(Find()));
                
                
            
            }
            if (this.transform.childCount ==2) {
                this.GetComponent<PlayerMovement>().enabled = false;
            
            }
            
        }
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stop")
        {
            isCollided = true;
            
            foreach (GameObject go in other.gameObject.transform.parent.gameObject.GetComponent<EnemyCreator>().enemies)
            {
                //go.AddComponent<EnemyController>();
                go.GetComponent<EnemyController>().isMove=true;
                Debug.Log("Collision detected.");
            }




        }
        if(other.tag=="Move"){
            if(other.gameObject.transform.parent.childCount<=3){
                Destroy(other.transform.parent.gameObject);
                isCollided=false;
                MakeThemCircle();
                foreach(GameObject go in players){
                    go.GetComponent<NavMeshAgent>().enabled=true;


                }

            }



        }
    }
    private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Door")
        {
            
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            TMP_Text number = other.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
            string text = number.text;
            char process = text[0];

            int amount = int.Parse(text.Substring(1));

            if (process.Equals('X'))
            {
                CreateCharacters((currentAmount * amount) - currentAmount);

            }

            else if (process.Equals('+'))
            {
                CreateCharacters((currentAmount + amount) - currentAmount);

            }

        }

       
      
       






    }
    

      public  void  CreateCharacters(int no) { 
        
        for (int i = 0; i < no; i++) {

            
            
                GameObject c = Instantiate(go, this.transform.position + Random.insideUnitSphere, Quaternion.identity, this.transform);
            c.transform.localRotation = Quaternion.Euler(0,0,0);
                players.Add(c);
            
        }
       //yield return new WaitForSeconds(3);
        
    
    }
     public void MakeThemCircle() {
        foreach (GameObject g in players) {
            g.transform.localPosition=Random.insideUnitSphere;
        
        }
    
    
    }

    public int Find()
    {
        int stop = 0;
        for (int i = 0; i < triangles.Length; i++)
        {
            if (currentAmount >= triangles[i])
            {
                stop++;

            }



        }
        return stop;
    }
   IEnumerator MakeEmTriangle(int rows) {
        Vector3 targetPosition = new Vector3(-190.9f, 2,2-rows);
        int yOffset = -2;
        float zOffset = -1f;
        float xOffset = -2.5f;
        for (int i = rows; i >0; i--) {
            
            Instanter(i - 1, targetPosition);
            targetPosition = new Vector3(targetPosition.x+xOffset, targetPosition.y - yOffset, targetPosition.z - zOffset);
            yield return new WaitForSeconds(.25f);
            if (i == 1) {
                for (int k = 0; k < players.Count; k++) {
                    Destroy(players[k]);
                
                }
            
            
            }
        }
    
    }
    void  Instanter(int index, Vector3 pos) {
      
        GameObject g = Instantiate(levels[index],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity,this.transform);
        for (int i = 0; i < index; i++) {
            Destroy(players[i]);
            players.RemoveAt(i);
        
        }
        g.transform.rotation = Quaternion.Euler(0,270,0);
       


    }
    
    
}

