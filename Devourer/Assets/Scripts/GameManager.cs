using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> arrayOfMonsters;
    public GameObject[] monsterPrefabs;

    public GameObject bomb;
    public List<GameObject> arrayOfItems;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        InvokeRepeating("SpawnMonsters", 2f, 1f);
        InvokeRepeating("SpawnItems", 2f, 3f);

    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnMonsters()
    {
        Vector3 spawnPosition = new Vector3 (Random.Range(-13, 14),Random.Range(-8, 9), 0);
        Instantiate(arrayOfMonsters[Random.Range(0, arrayOfMonsters.Count)], spawnPosition, Quaternion.identity);
    }

    void SpawnItems()
    {
        Vector3 spawnPosition = new Vector3 (Random.Range(-13, 14),Random.Range(-8, 9), 0);
        Instantiate(arrayOfItems[Random.Range(0, arrayOfItems.Count)], spawnPosition, Quaternion.identity);
    }

    public void AddMonster(int level){
        arrayOfMonsters.Add(monsterPrefabs[level]);
    }

    public void AddBomb(){
        arrayOfItems.Add(bomb);
    }
}
