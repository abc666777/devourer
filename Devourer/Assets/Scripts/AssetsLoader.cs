using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AssetsLoader : MonoBehaviour
{
    public static AssetsLoader instance;
    [SerializeField] private SpriteAtlas UISprite;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);

    }
    public dynamic GetAssets(GlobalReferences.TYPEOF_ASSETS type, string assetsName)
    {
        switch (type)
        {
            case GlobalReferences.TYPEOF_ASSETS.buff:
                return GetBuffSprite(assetsName);
        }
        return null;
    }

    public Sprite GetBuffSprite(string name)
    {
        return UISprite.GetSprite(name);
    }
}
