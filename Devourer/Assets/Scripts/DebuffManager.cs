using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class DebuffManager : MonoBehaviour
{
    public static DebuffManager instance;
    private PlayerController player;
    private Light2D visionLight;
    public GameObject fastUI;
    public GameObject slowUI;
    public GameObject shieldUI;
    public GameObject visionUI;
    public GameObject bonusUI;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find(GlobalReferences.player).GetComponent<PlayerController>();
        visionLight = GameObject.Find(GlobalReferences.visionLight).GetComponent<Light2D>();
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
        if(isShield)
        {
            DispelShieldBuff();
        }
        settingShieldBuff = GameManager.instance.StartCoroutine(SettingShieldBuff(duration));
    }

    public void SetVisionBuff(float duration)
    {
        if(hasVision)
        {
            DispelVisionBuff();
        }
        settingVisionBuff = GameManager.instance.StartCoroutine(SettingVisionBuff(duration));
    }
    public void SetBonusBuff(float duration)
    {
        if(hasBonus)
        {
            DispelBonusBuff();
        }
        settingBonusBuff = GameManager.instance.StartCoroutine(SettingBonusBuff(duration));
    }

    public void SetHungerBuff(float duration){
        player.LevelUp();
        UIManager.instance.SetScore();
        UIManager.instance.SetProgressBar();
        player.score += (1 * (player.playerStatus.hasBonus ? 2 : 1));
        player.hunger += 15;
        player.progress += (1 / player.level);
        if(isHungry)
        {
            DispelHungerBuff();
        }
        settingHungerBuff = GameManager.instance.StartCoroutine(SettingHungerBuff(duration));
    }
    #endregion
    #region getter/setter
    bool isFast { get { return settingFastBuff != null; } }
    bool isSlow { get { return settingSlowBuff != null; } }
    bool isShield { get { return settingShieldBuff != null; } }
    bool hasVision { get { return settingVisionBuff != null; } }
    bool hasBonus { get {return settingBonusBuff != null;} }
    bool isHungry {get {return settingHungerBuff != null;}}
    #endregion
    #region coroutines
    Coroutine settingFastBuff = null;
    Coroutine settingSlowBuff = null;
    Coroutine settingShieldBuff = null;
    Coroutine settingVisionBuff = null;
    Coroutine settingBonusBuff = null;
    Coroutine settingHungerBuff = null;
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

    IEnumerator SettingVisionBuff(float time)
    {
        float t = 0;
        visionLight.intensity = 1;
        while(t < 1){
            t += Time.deltaTime / time;
            visionLight.intensity = Mathf.Lerp(1, 0, t);
            yield return null;
        }
        DispelVisionBuff();
    }

    IEnumerator SettingBonusBuff(float time)
    {
        player.playerStatus.hasBonus = true;
        yield return new WaitForSeconds(time);
        player.playerStatus.hasBonus = false;
        DispelBonusBuff();
    }

    IEnumerator SettingHungerBuff(float time)
    {
        player.playerStatus.isHungry = true;
        yield return new WaitForSeconds(time);
        player.playerStatus.isHungry = false;
        DispelHungerBuff();
    }
    #endregion
    #region dispel
    void DispelFastBuff()
    {
        player.playerStatus.isFast = false;
        GameManager.instance.StopCoroutine(settingFastBuff);
        settingFastBuff = null;
    }

    void DispelSlowBuff()
    {
        player.playerStatus.isSlow = false;
        GameManager.instance.StopCoroutine(settingSlowBuff);
        settingSlowBuff = null;
    }
    public void DispelShieldBuff()
    {
        player.playerStatus.isImmune = false;
        GameManager.instance.StopCoroutine(settingShieldBuff);
        settingShieldBuff = null;
    }

    public void DispelVisionBuff()
    {
        visionLight.intensity = 0;
        GameManager.instance.StopCoroutine(settingVisionBuff);
        settingVisionBuff = null;
    }

    public void DispelBonusBuff()
    {
        player.playerStatus.hasBonus = false;
        GameManager.instance.StopCoroutine(settingBonusBuff);
        settingBonusBuff = null;
    }
    
    public void DispelHungerBuff()
    {
        player.playerStatus.isHungry = false;
        GameManager.instance.StopCoroutine(settingHungerBuff);
        settingHungerBuff = null;
    }
    #endregion
}
