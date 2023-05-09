using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;

    [SerializeField]
    private float timer = 5;
    private float bullet_time;

    public GameObject enemybullet;

    public Transform spawnPoint;

    public float enemySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer() 
    {
        bullet_time -= Time.deltaTime;

        if (bullet_time > 0) return;

        bullet_time = timer;

        GameObject bulletObj = Instantiate(enemybullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);
   }
}
