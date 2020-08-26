using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level;
    PlayerController player;
    private void Awake()
    {
        if(GameObject.Find("Player") != null)
            player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "EatCollider")
        {
            if (player.level >= level && player)
            {
                player.score += (level * 100);
                player.hunger += level;
                player.progress += 3 * level;
                player.LevelUp();
                UIManager.instance.SetScore();
                UIManager.instance.SetProgressBar();
                Destroy(gameObject);
            }
            else
            {
                if(player) Destroy(player.gameObject);
            }
        }

        if(col.gameObject.name == "Player"){
            if (player.level < level && player){
                Destroy(player.gameObject);
            }
        }

        if(col.gameObject.name.Contains("Bound")){
            Destroy(gameObject);
        }
    }
}
