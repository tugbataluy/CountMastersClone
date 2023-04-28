using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float maxHealth;
    public Slider slider;
    GameObject go;
    Transform target;
   public NavMeshAgent agent;
    private void Start()
    {
        this.transform.position = new Vector3(-148.699997f, 5, -0.899999976f);
        health = maxHealth;
        slider.value = CalculateHealth();
        go = GameObject.Find("MainPlayer");
        agent=this.GetComponent<NavMeshAgent>();
        
     
    }
    private void Update()
    {
        this.transform.position = new Vector3(-148.699997f, 5, -0.899999976f);
        slider.value = CalculateHealth();
        if (health <= 0) { 
        Destroy(gameObject);
            go.GetComponent<CharacterCreator>().isCollided=false;
        }
        agent.SetDestination(go.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.tag == "playerclone")
        {
            other.transform.parent.GetComponent<CharacterCreator>().isCollided = true;
            health-=2;
            Destroy(other.gameObject);

        }
    }
    float CalculateHealth() {
        return health / maxHealth;
    
    }
   
}
