using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float speed = 7.5f;
    private const float speedPenalty = 0.5f;
    private const float speedBonus = 1.5f;
    private float movingPenalty = 1;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public Rigidbody2D lightRb;
    public int level = 1;


    public Light2D light;

    public Light2D circleLight;
    public float hunger = 100;
    public float progress = 33;

    public float score = 0;
    public const float maxProgress = 100;

    private float faceDirection;

    public class Status
    {
        public bool isSlow = false;
        public bool isFast = false;
        public bool isImmune = false;
        public bool hasVision = false;
        public bool hasBonus = false;
        public bool isHungry = false;
    }


    [HideInInspector] public Status playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AudioManager.instance.PlayBGM(AssetsLoader.instance.GetBGM(GlobalReferences.BGMReferences.Gameplay));
        PlayerPrefs.SetFloat(GlobalReferences.score, score);
        playerStatus = new Status();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("HungerTimer", 1f, 1f);
    }

    [HideInInspector] public Animator anim;
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isHungry", playerStatus.isHungry);
        if (hunger > 100) hunger = 100;
        SetSpeed();
        float x = Input.GetAxis(GlobalReferences.InputReferences.InputHorizontal);
        float y = Input.GetAxis(GlobalReferences.InputReferences.InputVerticle);
        if (x != 0) faceDirection = x;
        sprite.flipX = faceDirection < 0 ? true : false;
        transform.Translate(Vector2.up * (speed * Time.deltaTime * y * movingPenalty));
        transform.Translate(Vector2.right * (speed * Time.deltaTime * x * movingPenalty));
        if (hunger <= 0)
        {
            Destroy(gameObject);
        }
    }

    void SetSpeed()
    {
        if (playerStatus.isSlow && playerStatus.isFast) movingPenalty = (speedBonus - speedPenalty);
        else if (playerStatus.isSlow) movingPenalty = (speedPenalty);
        else if (playerStatus.isFast) movingPenalty = (speedBonus);
        else movingPenalty = 1;
    }

    public void LevelUp()
    {
        if (progress < 33)
        {
            return;
        }
        if (progress >= 33 && progress < 66 && level < 2)
        {
            level = 2;
            UIManager.instance.ActivateMilestoneLayout(level);
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
            light.pointLightOuterRadius = 11f;
            circleLight.pointLightOuterRadius = 2.5f;
            GameManager.instance.AddMonster(2);
        }
        else if (progress >= 66 && level < 3)
        {
            level = 3;
            UIManager.instance.ActivateMilestoneLayout(level);
            transform.localScale = new Vector3(2f, 2f, 0);
            light.pointLightOuterRadius = 12f;
            circleLight.pointLightOuterRadius = 3;
            GameManager.instance.AddMonster(3);
            GameManager.instance.AddBomb();

        }

        if (progress > 100) progress = 100;

    }
    void HungerTimer()
    {
        if (gameObject) hunger -= ((level + (level - 1)) * (playerStatus.isHungry ? 2 : 1));
    }

    private void OnDestroy() {
        SceneManager.instance.LoadScene("Ending");
    }

}