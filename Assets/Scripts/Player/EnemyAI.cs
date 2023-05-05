using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    HealthController healthController;
    Transform player;
    [SerializeField]
    float enemySpeed, nearbydistance, Gobackspeed;
    Vector3 StartPosition; // Current position of the enemy is stored here

    private RaycastHit hit;
    private string enemyTag;

    [SerializeField]
    private float damage;

    public float damage_player;

    private BetterPlayerMovement playerScript;
    private GameObject sword;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerScript = Player.GetComponent<BetterPlayerMovement>();
        sword = GameObject.FindGameObjectWithTag("Sword");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartPosition = transform.position;
        healthController = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        nearbydistance = Vector3.Distance(transform.position, player.position);
        if(nearbydistance <= 8f) 
        {
            Chase();
        }
        if(nearbydistance > 8f) 
        {
            GoBackToPatrol();
        }
        if(damage_player <= 0) 
        {
            player.position = new Vector3(0, 0, 0);
        }

        Debug.Log(damage_player);
    }

    void Chase() 
    {
        transform.LookAt(player);
        transform.Translate(0, 0, enemySpeed * Time.deltaTime);
    }

    void GoBackToPatrol() 
    {
        transform.LookAt(StartPosition);
        transform.position = Vector3.Lerp(transform.position, StartPosition, Gobackspeed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == sword && playerScript.doAttack)
        {
            healthController.ApplyDamage(damage);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(damage_player);

        }

    }
}
