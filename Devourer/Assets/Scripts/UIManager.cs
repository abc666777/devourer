using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Image hungerBar;

    public Image progressBar;
    public TextMeshProUGUI scoreText;

    public Image milestone2;
    public Image milestone3;

<<<<<<< HEAD
    PlayerController player;
    // Start is called before the first frame update
    void Awake()
    {

=======
    private PlayerController player;
    // Start is called before the first frame update
    void Awake() {
        instance = this;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
>>>>>>> parent of 25e0a4a... add new icon.
    }

    // Update is called once per frame
    void Update()
    {
        SetHungerBar();
    }

    void SetHungerBar(){
        hungerBar.fillAmount = player.hunger / 100;
    }

    public void SetScore(){
        scoreText.text = "Score : " + player.score;
    }

    public void SetProgressBar(){
        progressBar.fillAmount = player.progress / 100;
    }

    public void ActivateMilestoneLayout(int level){
        switch(level){
            case 2:
                milestone2.color = new Color(milestone2.color.r, milestone2.color.g, milestone2.color.b, 1);
                break;
            case 3:
                milestone3.color = new Color(milestone3.color.r, milestone3.color.g, milestone3.color.b, 1);
                break;
            default:
                break;
        }
    }
<<<<<<< HEAD

    public void AddBuff(string buffName)
    {
        //buff
    }
=======
>>>>>>> parent of 25e0a4a... add new icon.
}
