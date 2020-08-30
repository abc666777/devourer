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

    private PlayerController player;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentlyDisplayBuffIcons = new List<GameObject>();
        instance = this;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetHungerBar();
    }

    void SetHungerBar()
    {
        hungerBar.fillAmount = player.hunger / 100;
    }

    public void SetScore()
    {
        scoreText.text = "Score : " + player.score;
    }

    public void SetProgressBar()
    {
        progressBar.fillAmount = player.progress / 100;
    }

    private List<GameObject> CurrentlyDisplayBuffIcons;
    [SerializeField] private GameObject root;
    [SerializeField] private GameObject iconPrefabs;
    public void ActivateMilestoneLayout(int level)
    {
        switch (level)
        {
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
    public void AddBuffIconToLayout(GameObject newIcon)
    {
        foreach (GameObject icon in CurrentlyDisplayBuffIcons)
        {
            if (icon.name == newIcon.name)
            {
                CurrentlyDisplayBuffIcons.Remove(icon);
                Destroy(icon);
                return;
            }
        }
        CurrentlyDisplayBuffIcons.Add(newIcon);
    }

    public void NewBuffIcon(string iconName)
    {
        GameObject ob = Instantiate(iconPrefabs, root.transform);
        ob.SetActive(true);
        ob.name = iconName;
        ob.GetComponent<Image>().sprite = AssetsLoader.instance.GetAssets(GlobalReferences.TYPEOF_ASSETS.buff, iconName);
        AddBuffIconToLayout(ob);
    }

    public void RemoveBuffIcon(string iconName)
    {
        foreach (GameObject icon in CurrentlyDisplayBuffIcons)
        {
            if (icon.name == iconName)
            {
                CurrentlyDisplayBuffIcons.Remove(icon);
                Destroy(icon);
                return;
            }
        }
    }
}
