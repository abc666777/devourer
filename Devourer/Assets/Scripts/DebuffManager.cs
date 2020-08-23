using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    public static DebuffManager instance;
    PlayerController player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        instance = this;
    }
    public void SetBuff(float duration)
    {
        if (isFast)
        {
            DispelBuff();
        }
        settingBuff = GameManager.instance.StartCoroutine(SettingBuff(duration));

    }

    public void SetDebuff(float duration)
    {
        if (isSlow)
        {
            DispelDebuff();
        }
        settingDebuff = GameManager.instance.StartCoroutine(SettingDebuff(duration));
    }

    bool isFast { get { return settingBuff != null; } }
    bool isSlow { get { return settingDebuff != null; } }
    Coroutine settingBuff = null;
    Coroutine settingDebuff = null;
    IEnumerator SettingBuff(float time)
    {
        player.isFast = true;
        yield return new WaitForSeconds(time);
        player.isFast = false;
        DispelBuff();
    }

    IEnumerator SettingDebuff(float time)
    {
        player.isSlow = true;
        yield return new WaitForSeconds(time);
        player.isSlow = false;
        GameManager.instance.StopCoroutine(settingDebuff);
        DispelDebuff();
    }

    void DispelBuff()
    {
        GameManager.instance.StopCoroutine(settingBuff);
        settingBuff = null;
    }

    void DispelDebuff()
    {
        GameManager.instance.StopCoroutine(settingDebuff);
        settingDebuff = null;
    }
}
