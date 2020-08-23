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
        //InvokeRepeating("SpawnMonsters", 2f, 3f);
        //InvokeRepeating("SpawnItems", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnMonsters()
    {
        Instantiate(arrayOfMonsters[Random.Range(0, arrayOfMonsters.Length)]);
    }

    void SpawnItems()
    {
        Instantiate(arrayOfItems[Random.Range(0, arrayOfItems.Length)]);
    }
}
