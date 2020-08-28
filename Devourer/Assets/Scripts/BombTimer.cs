﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController player;
    void Awake() {
        Destroy(gameObject, 5f);
    }
    void Update() {
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "EatCollider" || col.gameObject.name == "Player")
        {
            if(GameObject.Find("Player") != null)
                player = GameObject.Find("Player").GetComponent<PlayerController>();
            Destroy(player.gameObject);
            Destroy(gameObject);
        }

        if(col.gameObject.name.Contains("Bound")){
            Destroy(gameObject);
        }
    }
}
