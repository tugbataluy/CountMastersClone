using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update


    GameObject mc;
    GameObject target;
    NavMeshAgent agent;
    int expected;
    Text smt;
    public bool isMove;
    void Start()
    {
        mc = GameObject.Find("MainPlayer");
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!isMove)
            return;
        if (mc.GetComponent<CharacterCreator>().isCollided && mc.GetComponent<CharacterCreator>().players.Count > 0)
        {

            agent = GetComponent<NavMeshAgent>();
            FindClosest();
            agent.SetDestination(target.transform.position);
            agent.speed = 10;
            foreach (GameObject g in mc.GetComponent<CharacterCreator>().players) {
                g.GetComponent<NavMeshAgent>().enabled = false;
            
            }

        }

        float dist = Vector3.Distance(this.transform.position, target.transform.position);
        if (dist <= 1.5f) {
           // expected = mc.GetComponent<CharacterCreator>().currentAmount - this.transform.parent.childCount - 2;
            this.transform.parent.GetComponent<EnemyCreator>().enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
          
            target.transform.parent.GetComponent<CharacterCreator>().players.Remove(target.gameObject);
          
            Destroy(target);
            

        }
        
      /*  if (this.transform.parent.childCount <= 3)
        {
            Destroy(this.transform.parent.gameObject);
            GameObject gg = mc.GetComponent<CharacterCreator>().players[0];
            mc.GetComponent<CharacterCreator>().players.Remove(gg);
            Destroy(gg);
            mc.GetComponent<CharacterCreator>().isCollided = false;
            mc.GetComponent<CharacterCreator>().MakeThemCircle();
            foreach (GameObject g in mc.GetComponent<CharacterCreator>().players)
            {
                g.GetComponent<NavMeshAgent>().enabled = true;

            }
        }
    */
        //print((this.transform.parent.GetComponent<EnemyCreator>().at.text));

    }

   private void LateUpdate()
    {
        if(!isMove)
            return;
        
    }





    void FindClosest()
    {
        float closest = float.MaxValue;
        if (mc.GetComponent<CharacterCreator>().players.Count > 0)
        {
            for (int i = 0; i < mc.GetComponent<CharacterCreator>().players.Count; i++)
            {
                Transform next = mc.GetComponent<CharacterCreator>().players[i].transform;
                float currdist = Vector3.Distance(this.transform.position, next.position);
                if (currdist < closest)
                {
                    closest = currdist;
                    target = mc.GetComponent<CharacterCreator>().players[i];


                }



            }

        }
    }
  

   
}
