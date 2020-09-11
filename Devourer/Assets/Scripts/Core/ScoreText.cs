using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private float score = 0;
    public TextMeshProUGUI text;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Awake() {

        if (PlayerPrefs.HasKey(GlobalReferences.score))
            score = PlayerPrefs.GetFloat(GlobalReferences.score);

        if(PlayerPrefs.HasKey(GlobalReferences.highScore) && PlayerPrefs.HasKey(GlobalReferences.score)){
            if(PlayerPrefs.GetFloat(GlobalReferences.score) > PlayerPrefs.GetFloat(GlobalReferences.highScore)){
                PlayerPrefs.SetFloat(GlobalReferences.highScore, PlayerPrefs.GetFloat(GlobalReferences.score));
            }
        }
        PlayerPrefs.Save();
        highScoreText.text = "HIGH SCORE\n" + PlayerPrefs.GetFloat(GlobalReferences.highScore);
        text.text = "YOUR SCORE\n" + score;
    }
}
    // Update is called once per frame

