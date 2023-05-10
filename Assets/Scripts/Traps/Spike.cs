using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject trap;
    private float stop_point;
    private float start_point;
    private bool isResetting = false;
    //public GameObject player_hp;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        start_point = this.trap.transform.position.y;
        stop_point = this.transform.parent.position.y + 1.86f;
    }

    // Update is called once per frame
    void Update()
    {
        if (
            trap.GetComponent<Spike_Trap>().isTrapActivated && 
            (this.transform.position.y <= stop_point)
            )
        {
            this.transform.Translate((Vector3.up * 20) * Time.deltaTime, Space.Self);
        }

        if (isResetting)
        {
            if (this.transform.position.y >= start_point)
            {
                this.transform.Translate((Vector3.down * 40) * Time.deltaTime, Space.Self);
            }

            Reset();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //player_hp.GetComponent<HealthController>().ApplyDamage(damage);
            //Debug.Log("Player Hit");
            this.GetComponent<BoxCollider>().enabled = false;

            Invoke("Reset", 2f);
        }
    }

    void Reset()
    {
        if (this.transform.position.y >= start_point)
        {
            isResetting = true;
        }

        if (this.transform.position.y <= start_point)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            trap.GetComponent<Spike_Trap>().isTrapActivated = false;
            isResetting = false;
        }
    }
}
