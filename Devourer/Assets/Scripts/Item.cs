using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum EFFECT_TYPE { slow, fast, vision, shield, bonus, hunger }
    public EFFECT_TYPE type;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == GlobalReferences.player)
        {

            switch (type)
            {
                case EFFECT_TYPE.slow:
                    DebuffManager.instance.SetSlowBuff(5f);
                    break;
                case EFFECT_TYPE.fast:
                    DebuffManager.instance.SetFastBuff(5f);
                    break;
                case EFFECT_TYPE.shield:
                    DebuffManager.instance.SetShieldBuff(5f);
                    break;
                case EFFECT_TYPE.vision:
                    DebuffManager.instance.SetVisionBuff(5f);
                    break;
                case EFFECT_TYPE.bonus:
                    DebuffManager.instance.SetBonusBuff(5f);
                    break;
                case EFFECT_TYPE.hunger:
                    DebuffManager.instance.SetHungerBuff(5f);
                    break;
            }
            Destroy(gameObject);
        }

        if (col.gameObject.name.Contains(GlobalReferences.bound))
        {
            Destroy(gameObject);
        }
    }
}
// Start is called before the first frame update
