using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(AssetsLoader.instance.GetBGM(GlobalReferences.BGMReferences.MainMenu));
    }

    // Update is called once per frame

}
