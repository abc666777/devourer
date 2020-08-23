using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] arrayOfMonsters;
    public GameObject[] arrayOfItems;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        InvokeRepeating(Instantiate(arrayOfMonsters[Random.Range(0, 1)]), 2.0f, 0.3f);
        InvokeRepeating(Instantiate(arrayOfItems[Random.Range(0, 1)]), 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnMonsters(GameObject ob)
    {

    }
}
