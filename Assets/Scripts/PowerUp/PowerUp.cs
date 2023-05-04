using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    BetterPlayerMovement playerMovement;
    [SerializeField] GameObject player;

    // Awake is called before the first frame update
    void Awake()
    {
        playerMovement = player.GetComponent<BetterPlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (this.tag)
            {
                case "JumpPU":
                    {
                        break;
                    }
            }
        }
    }
}
