using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Trap : MonoBehaviour
{
    public GameObject player;
    public GameObject rune;
    private PowerUp_Handler powerup_handler;

    void Awake()
    {
        powerup_handler = player.GetComponent<PowerUp_Handler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Trap Activated");
            this.GetComponent<BoxCollider>().enabled = false;
            rune.GetComponent<Renderer>().material.color = Color.black;

            if (!powerup_handler.hasSlowTrapBeenActivated)
            {
                powerup_handler.hasSlowTrapBeenActivated = true;
            }
            else
            {
                powerup_handler.slow_timer = 0;
            }
        }
    }
}
