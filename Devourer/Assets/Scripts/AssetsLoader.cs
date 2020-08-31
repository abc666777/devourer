using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AssetsLoader : MonoBehaviour
{
    public static AssetsLoader instance;
    [SerializeField] private SpriteAtlas UISprite;
    private List<AudioClip> bgmlists;
    // Start is called before the first frame update
    void Awake()
    {  
        if(instance != null && instance != this)
            Destroy(gameObject);

        else if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        UISprite = Resources.Load<SpriteAtlas>(GlobalReferences.PathReferences.UI_BuffPath + GlobalReferences.UIReferences.UIAtlas);
        bgmlists = new List<AudioClip>(Resources.LoadAll<AudioClip>(GlobalReferences.PathReferences.BGMPath));
    }

    public Sprite GetBuffSprite(string name)
    {
        return UISprite.GetSprite(name);
    }

    public AudioClip GetBGM(string name){
        return bgmlists.Find(x => x.name == name);
    }
}
