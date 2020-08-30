using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController player;
    private void Awake()
    {
        if (GameObject.Find(GlobalReferences.player) != null)
            player = GameObject.Find(GlobalReferences.player).GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == GlobalReferences.player)
        {
            player.score += (1 * (player.playerStatus.hasBonus ? 2 : 1));
            player.hunger += 15;
            player.progress += (1 / player.level);
            DebuffManager.instance.SetHungerBuff(5f);
            Destroy(gameObject);
        }
    }
}
