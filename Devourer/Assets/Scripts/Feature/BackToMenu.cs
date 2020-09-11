using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackToMenu : MonoBehaviour
{

	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        SceneManager.instance.LoadScene("Start");
        Time.timeScale = 1f;
	}
}
