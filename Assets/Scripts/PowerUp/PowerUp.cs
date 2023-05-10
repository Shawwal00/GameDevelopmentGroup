using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject player;
    private PowerUp_Handler powerup_handler;
    public ParticleSystem burst_particle;
    public GameObject mesh;
    public ParticleSystem particle_effect;

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

            var burst_emission = burst_particle.emission;
            var burst_duration = burst_particle.main.duration;
            var particle_emission = particle_effect.emission;

            burst_emission.enabled = true;
            burst_particle.Play();

            mesh.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            particle_emission.enabled = false;
            //Debug.Log("Powerup obtained!");
            Invoke("DestroyObject", burst_duration);
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
