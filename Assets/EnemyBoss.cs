using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;

    HealthController healthcontroller;

    [SerializeField]
    public float damage;

    public float damage_player;

    private BetterPlayerMovement playerScript;
    private GameObject sword;

    private GameObject Player;

    public float enemySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerScript = Player.GetComponent<BetterPlayerMovement>();
        sword = GameObject.FindGameObjectWithTag("Sword");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthcontroller = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == sword && playerScript.doAttack) 
        {
            healthcontroller.ApplyDamage(damage);
        }

        if (other.CompareTag("Player")) 
        {
            other.GetComponent<PlayerStats>().TakeDamage(damage_player);
        }
    }


}
