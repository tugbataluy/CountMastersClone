using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowMainChar : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent agent;
   
    Animator animator;
    GameObject target;
   
    void Start()
    {
       agent = this.GetComponent<NavMeshAgent>();
  
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent.GetComponent<CharacterCreator>().positions.Count > this.transform.parent.GetComponent<CharacterCreator>().index)

        {

            agent.SetDestination(this.transform.parent.GetChild(1).gameObject.transform.position);
            
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stop")
        {
            this.transform.parent.GetComponent<CharacterCreator>().isCollided = true;
            other.transform.parent.gameObject.GetComponent<EnemyCreator>().GaveThemAnimation();
          


        }
        if (other.gameObject.tag == "Obstacle") {
            this.transform.parent.GetComponent<CharacterCreator>().players.Remove(this.gameObject);
            Destroy(this.gameObject);
            

        }

      
        
    }
    void FindClosest()
    {
        float closest = float.MaxValue;
        if (this.transform.parent.GetComponent<CharacterCreator>().players.Count > 0)
        {
            for (int i = 0; i < this.transform.parent.GetComponent<CharacterCreator>().players.Count; i++)
            {
                Transform next = this.transform.parent.GetComponent<CharacterCreator>().players[i].transform;
                float currdist = Vector3.Distance(this.transform.position, next.position);
                if (currdist < closest)
                {
                    closest = currdist;
                    target = this.transform.parent.GetComponent<CharacterCreator>().players[i];


                }



            }

        }
    }
   

}
