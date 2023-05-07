using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Handler : MonoBehaviour
{
    [HideInInspector] public bool hasDoubleJumpBeenActivated = false;
    [HideInInspector] public bool hasSpeedBoostBeenActivated = false;
    [HideInInspector] public float double_jump_timer = 0;
    [HideInInspector] public float speed_boost_timer = 0;
    private BetterPlayerMovement player;
    private float standard_movement_speed;
    private int standard_max_jumps;
    //public TextMeshProUGUI double_jump_text;
    //public TextMeshProUGUI speed_boost_text;

    void Awake()
    {
        player = this.gameObject.GetComponent<BetterPlayerMovement>();
        standard_movement_speed = player.speed;
        standard_max_jumps = player.jumpMax;
    }

    void FixedUpdate()
    {
        if (hasDoubleJumpBeenActivated)
        {
            player.jumpMax = 2;
            //double_jump_text.text = "Double Jump " + ((int)double_jump_timer).ToString() + "/10";
            double_jump_timer += Time.deltaTime;
            //Debug.Log(timer);
            if (double_jump_timer >= 10)
            {
                //double_jump_text.text = "";
                player.jumpMax = standard_max_jumps;
                hasDoubleJumpBeenActivated = false;
                double_jump_timer = 0;
            }
        }

        if (hasSpeedBoostBeenActivated)
        {
            player.speed = 50;
            //speed_boost_text.text = "Speed Boost " + ((int)speed_boost_timer).ToString() + "/10";
            speed_boost_timer += Time.deltaTime;
            //Debug.Log(timer);
            if (speed_boost_timer >= 10)
            {
                //speed_boost_text.text = "";
                player.speed = standard_movement_speed;
                hasSpeedBoostBeenActivated = false;
                speed_boost_timer = 0;
            }
        }
    }
}
