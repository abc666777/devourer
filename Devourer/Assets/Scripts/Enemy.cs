using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level;
    public float value;
    PlayerController player;
    private void Awake()
    {
        if (GameObject.Find(GlobalReferences.player) != null)
            player = GameObject.Find(GlobalReferences.player).GetComponent<PlayerController>();
    }
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == GlobalReferences.player)
        {
            if (player.level >= level && player)
            {
                player.score += (value / player.level);
                player.hunger += level;
                player.progress += (value / player.level);
                player.LevelUp();
                UIManager.instance.SetScore();
                UIManager.instance.SetProgressBar();
                Destroy(gameObject);
            }
            else
            {
                if (player) Destroy(player.gameObject);
            }
        }

        if (col.gameObject.name.Contains(GlobalReferences.bound))
        {
            Destroy(gameObject);
        }
    }
}
