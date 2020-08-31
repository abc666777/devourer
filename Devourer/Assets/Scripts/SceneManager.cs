using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] private GameObject loadScenePanel;
    // Start is called before the first frame update
    void Awake()
    {  
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
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
