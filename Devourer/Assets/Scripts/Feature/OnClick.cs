using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClick : MonoBehaviour
{

	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        AudioManager.instance.PlaySFX(AssetsLoader.instance.GetSFX(GlobalReferences.SFXReferences.ButtonOnClick));
	}
}
