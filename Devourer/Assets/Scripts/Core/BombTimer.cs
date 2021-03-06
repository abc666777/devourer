﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController player;
    void Awake()
    {
        Destroy(gameObject, 5f);
        if (GameObject.Find(GlobalReferences.player) != null)
            player = GameObject.Find(GlobalReferences.player).GetComponent<PlayerController>();
    }
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == GlobalReferences.player && !player.playerStatus.isImmune)
        {
            if (GameObject.Find(GlobalReferences.player) != null)
                player = GameObject.Find(GlobalReferences.player).GetComponent<PlayerController>();
            Destroy(player.gameObject);
            Destroy(gameObject);
            AudioManager.instance.PlayBGM(AssetsLoader.instance.GetBGM(GlobalReferences.BGMReferences.Ending));
            SceneManager.instance.LoadScene("Ending");
            return;
        }
        else{
            DebuffManager.instance.DispelShieldBuff();
            UIManager.instance.RemoveBuffIcon(GlobalReferences.UIReferences.shieldIconBuff);
            Destroy(gameObject);
            return;
        }
    }
    void OnDestroy() {
        AudioManager.instance.PlaySFX(AssetsLoader.instance.GetSFX(GlobalReferences.SFXReferences.Bomb));
    }
}
