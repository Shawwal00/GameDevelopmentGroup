using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    [SerializeField]
    private Portal target;

    [SerializeField]
    private Transform spawnPoint;

    public Transform SpawnPoint { get { return spawnPoint; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)) 
        {
            other.transform.position = target.SpawnPoint.position;
        }
    }

}
