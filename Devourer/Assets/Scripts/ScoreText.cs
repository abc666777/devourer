using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private float score = 0;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake() {

         if (PlayerPrefs.HasKey("Score"))
            score = PlayerPrefs.GetFloat("Score");

        text.text = "YOUR SCORE\n" + score;
    }
}
    // Update is called once per frame

