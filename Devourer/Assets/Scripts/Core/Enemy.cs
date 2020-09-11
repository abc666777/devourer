using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level;
    public float value;
    public float score;
    private PlayerController player;

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
                player.anim.SetTrigger("isEating");
                player.score += (score * (player.playerStatus.hasBonus ? 2 : 1));
                player.hunger += 5 * level;
                player.progress += (value / player.level);
                player.LevelUp();
                UIManager.instance.SetScore();
                UIManager.instance.SetProgressBar();
                PlayerPrefs.SetFloat("Score", player.score);
                AudioManager.instance.PlaySFX(AssetsLoader.instance.GetSFX(GlobalReferences.SFXReferences.Eat));
                Destroy(gameObject);
                return;
            }
            else
            {
                if (player.playerStatus.isImmune)
                {
                    DebuffManager.instance.DispelShieldBuff();
                    UIManager.instance.RemoveBuffIcon(GlobalReferences.UIReferences.shieldIconBuff);
                    Destroy(gameObject);
                    return;
                }
                else
                    Destroy(player.gameObject);
                    AudioManager.instance.PlaySFX(AssetsLoader.instance.GetSFX(GlobalReferences.SFXReferences.Death));
                    AudioManager.instance.PlaySFX(AssetsLoader.instance.GetSFX(GlobalReferences.SFXReferences.Eat));
                    AudioManager.instance.PlayBGM(AssetsLoader.instance.GetBGM(GlobalReferences.BGMReferences.Ending));
                    SceneManager.instance.LoadScene("Ending");
            }
        }

        if (col.gameObject.name.Contains(GlobalReferences.bound))
        {
            Destroy(gameObject);
        }
    }
}
