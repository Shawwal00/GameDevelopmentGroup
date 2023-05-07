using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject player;
    private PowerUp_Handler powerup_handler;

    void Awake()
    {
        powerup_handler = player.GetComponent<PowerUp_Handler>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (this.tag)
            {
                case "Double Jump PU":
                    {
                        if (!powerup_handler.hasDoubleJumpBeenActivated)
                        {
                            powerup_handler.hasDoubleJumpBeenActivated = true;
                        }
                        else
                        {
                            powerup_handler.double_jump_timer = 0;
                        }
                        break;

                    }
                case "Speed Boost PU":
                    {
                        if (!powerup_handler.hasSpeedBoostBeenActivated)
                        {
                            powerup_handler.hasSpeedBoostBeenActivated = true;
                        }
                        else
                        {
                            powerup_handler.speed_boost_timer = 0;
                        }
                        break;
                    }
            }

            //Debug.Log("Powerup obtained!");
            Destroy(this.gameObject);
        }
    }
}
