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

    [HideInInspector] public List<GameObject> CurrentlyDisplayBuffIcons;
    [SerializeField] private GameObject root;
    [SerializeField] private GameObject iconPrefabs;

    private GameObject ob;
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
        ob = CurrentlyDisplayBuffIcons.Find(x => x.name == newIcon.name);
        if (ob != null)
        {
            //CurrentlyDisplayBuffIcons.Remove(ob);
            Destroy(ob);
        }
        CurrentlyDisplayBuffIcons.Add(newIcon);
        ob = null;
    }

    public void NewBuffIcon(string iconName)
    {
        GameObject ob = Instantiate(iconPrefabs, root.transform);
        ob.name = iconName;
        ob.GetComponent<Image>().sprite = AssetsLoader.instance.GetBuffSprite(iconName);
        ob.SetActive(true);
        AddBuffIconToLayout(ob);
    }

    public void RemoveBuffIcon(string iconName)
    {
        GameObject _ob = CurrentlyDisplayBuffIcons.Find(x => x.name == iconName);
        if (_ob != null)
        {
            //CurrentlyDisplayBuffIcons.Remove(ob);
            Destroy(_ob);
        }
    }
}
