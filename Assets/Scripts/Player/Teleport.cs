using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform tp;
    [SerializeField] GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TP());
    }
    IEnumerator TP()
    {
        yield return new WaitForSeconds(0.1f);
        player.transform.position = new Vector3(
            tp.transform.position.x,
            tp.transform.position.y,
            tp.transform.position.z
        );
    }
}
