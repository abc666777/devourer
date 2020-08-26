using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> arrayOfMonsters;
    public GameObject[] monsterPrefabs;
    public Transform[] arrayOfBombSpawnPoint;

    public GameObject bomb;
    public List<GameObject> arrayOfItems;

    public Transform[] arrayOfSpawnPoint;

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
        Instantiate(arrayOfMonsters[Random.Range(0, arrayOfMonsters.Count)], arrayOfSpawnPoint[Random.Range(0, arrayOfSpawnPoint.Length)].position, Quaternion.identity);
    }

    void SpawnItems()
    {
        Instantiate(arrayOfItems[Random.Range(0, arrayOfItems.Count)], arrayOfSpawnPoint[Random.Range(0, arrayOfSpawnPoint.Length)].position, Quaternion.identity);
    }

    public void AddMonster(int level){
        arrayOfMonsters.Add(monsterPrefabs[level]);
    }

    public void SpawnBomb(){
        Instantiate(bomb, arrayOfBombSpawnPoint[Random.Range(0, arrayOfBombSpawnPoint.Length)].position, Quaternion.identity);
    }

    public void AddBomb(){
        InvokeRepeating("SpawnBomb", 0f, 3f);
    }
}
