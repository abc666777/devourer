using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class DebuffManager : MonoBehaviour
{
    public static DebuffManager instance;
    private PlayerController player;

    public GameObject fastUI;
    public GameObject slowUI;
    public GameObject shieldUI;
    public GameObject visionUI;
    public GameObject bonusUI;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find(GlobalReferences.player).GetComponent<PlayerController>();
        instance = this;
    }
    #region set buff
    public void SetFastBuff(float duration)
    {
        if (isFast)
        {
            DispelFastBuff();
        }
        settingFastBuff = GameManager.instance.StartCoroutine(SettingFastBuff(duration));

    }

    public void SetSlowBuff(float duration)
    {
        if (isSlow)
        {
            DispelSlowBuff();
        }
        settingSlowBuff = GameManager.instance.StartCoroutine(SettingSlowBuff(duration));
    }

    public void SetShieldBuff(float duration)
    {
        DispelShieldBuff();

        settingShieldBuff = GameManager.instance.StartCoroutine(SettingShieldBuff(duration));
    }
    #endregion
    #region getter/setter
    bool isFast { get { return settingFastBuff != null; } }
    bool isSlow { get { return settingSlowBuff != null; } }
    bool isShield { get { return settingShieldBuff != null; } }
    #endregion
    #region coroutines
    Coroutine settingFastBuff = null;
    Coroutine settingSlowBuff = null;
    Coroutine settingShieldBuff = null;
    #endregion
    #region IEnumerator
    IEnumerator SettingFastBuff(float time)
    {
        player.playerStatus.isFast = true;
        yield return new WaitForSeconds(time);
        player.playerStatus.isFast = false;
        DispelFastBuff();
    }

    IEnumerator SettingSlowBuff(float time)
    {
        player.playerStatus.isSlow = true;
        yield return new WaitForSeconds(time);
        player.playerStatus.isSlow = false;
        DispelSlowBuff();
    }

    IEnumerator SettingShieldBuff(float time)
    {
        player.playerStatus.isImmune = true;
        yield return new WaitForSeconds(time);
        player.playerStatus.isImmune = false;
        DispelShieldBuff();
    }
    #endregion
    #region dispel
    void DispelFastBuff()
    {
        GameManager.instance.StopCoroutine(settingFastBuff);
        settingFastBuff = null;
    }

    void DispelSlowBuff()
    {
        GameManager.instance.StopCoroutine(settingSlowBuff);
        settingSlowBuff = null;
    }
    void DispelShieldBuff()
    {
        GameManager.instance.StopCoroutine(settingShieldBuff);
        settingShieldBuff = null;
    }
    #endregion
}
