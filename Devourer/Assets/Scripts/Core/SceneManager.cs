using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] private GameObject loadScenePanel;
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Awake()
    {  
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if(!PlayerPrefs.HasKey(GlobalReferences.highScore))
            PlayerPrefs.SetFloat(GlobalReferences.highScore, 0f);

        PlayerPrefs.Save();
        highScore.text = "High Score: " + PlayerPrefs.GetFloat(GlobalReferences.highScore);
    }

    bool isLoading {get {return loadASync != null;}}
    Coroutine loadASync = null;
    void StopLoadScene(){
        if(isLoading)
            StopCoroutine(loadASync);

        loadASync = null;
    }
    
    public void LoadScene(string sceneName){
        StopLoadScene();
        loadASync = StartCoroutine(LoadASync(sceneName));
    }

    public void Quit(){
        Application.Quit();
    }

    IEnumerator LoadASync(string sceneName){
        Instantiate(loadScenePanel, GameObject.Find(GlobalReferences.canvas).transform);
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        StopLoadScene();
    }
}
