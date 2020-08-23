using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum EFFECT_TYPE { slow, fast }
    public EFFECT_TYPE type;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "EatCollider")
        {

            switch (type)
            {
                case EFFECT_TYPE.slow:
                    DebuffManager.instance.SetDebuff(5f);
                    break;
                case EFFECT_TYPE.fast:
                    DebuffManager.instance.SetBuff(5f);
                    break;
            }
            Destroy(gameObject);
        }
    }

    void Innitialize(EFFECT_TYPE type)
    {
        this.type = type;
    }
}
// Start is called before the first frame update
