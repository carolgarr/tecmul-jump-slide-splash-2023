using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedController : MonoBehaviour
{
    public TMP_Text speedText;

    private bool checkSpeed;

    private Player player;

    void Start()
    {
        speedText.text = "00.00 m/s";
        checkSpeed = true;
        player = GameObject.Find("Player").GetComponent<Player>();;
    }

    void LateUpdate()
    {
        if (checkSpeed)
        {
            
            speedText.text = string.Format("{0:0.00} m/s", player.getVelocity().magnitude);
        }
    }
}
