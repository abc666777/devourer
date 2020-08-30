using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> arrayOfMonsters;
    public GameObject[] monsterPrefabs;
    public GameObject warningSign;
    //public GameObject bomb;
    public List<GameObject> arrayOfItems;

    public Transform[] arrayOfSpawnPoint;

    public GameObject pauseScene;

    bool isPause = false;

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

    private void Update()
    {
        if (Input.GetKeyDown(GlobalReferences.InputReferences.Escape))
        {
            Pause();
        }
    }

    // Update is called once per frame

    void SpawnMonsters()
    {
        Instantiate(arrayOfMonsters[Random.Range(0, arrayOfMonsters.Count)], arrayOfSpawnPoint[Random.Range(0, arrayOfSpawnPoint.Length)].position, Quaternion.identity);
    }

    void SpawnItems()
    {
        Instantiate(arrayOfItems[Random.Range(0, arrayOfItems.Count)], arrayOfSpawnPoint[Random.Range(0, arrayOfSpawnPoint.Length)].position, Quaternion.identity);
    }

    public void AddMonster(int level)
    {
        arrayOfMonsters.Add(monsterPrefabs[level]);
    }

    public void SpawnWarning()
    {
        Vector3 randomPos = new Vector3(Random.Range(-18f, 18f), Random.Range(-8f, 8f), 0);
        Instantiate(warningSign, randomPos, Quaternion.identity);
    }

    public void AddBomb()
    {
        InvokeRepeating("SpawnWarning", 0f, 5f);
    }

    public void Pause()
    {
        isPause = !isPause;
        pauseScene.SetActive(isPause);
        Time.timeScale = isPause ? 0 : 1f;
    }
}
