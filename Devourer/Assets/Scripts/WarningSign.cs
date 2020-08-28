using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSign : MonoBehaviour
{
    public GameObject bomb;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 5f);
    }

    void OnDestroy() {
        Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
    }
}
