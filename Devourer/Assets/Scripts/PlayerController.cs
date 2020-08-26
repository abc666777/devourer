using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private const float speedPenalty = 0.5f;
    private const float speedBonus = 1.5f;
    private float movingPenalty = 1;
    public bool isSlow = false;
    public bool isFast = false;
    Rigidbody2D rb;
    public Rigidbody2D lightRb;
    public int level = 1;


    public Light2D light;
    public float hunger = 100;
    public float progress = 0;

    public float score = 0;
    public const float maxProgress = 100;

    private float faceDirection;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("HungerTimer", 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeed();
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(x != 0) faceDirection = x;
        Vector3 absVector = transform.localScale.x < 0 ? Vector3.Scale(transform.localScale, new Vector3(-1, 1, 0)) : transform.localScale;
        gameObject.transform.localScale = faceDirection > 0 ? Vector3.Scale(new Vector3(-1, 1, 0), absVector) : absVector;
        transform.Translate(Vector2.up * (speed * Time.deltaTime * y * movingPenalty));
        transform.Translate(Vector2.right * (speed * Time.deltaTime * x * movingPenalty));
        if(hunger <= 0){
            Destroy(gameObject);
        }
    }

    void SetSpeed()
    {
        if (isSlow && isFast) movingPenalty = (speedBonus - speedPenalty);
        else if (isSlow) movingPenalty = (speedPenalty);
        else if (isFast) movingPenalty = (speedBonus);
        else movingPenalty = 1;
    }

    public void LevelUp()
    {
        if(progress < 33){
            return;
        }
        if (progress >= 33 && progress < 66 && level < 2)
        {
            level = 2;
            UIManager.instance.ActivateMilestoneLayout(level);
            transform.localScale = new Vector3(2,2,0);
            light.pointLightOuterRadius = 10f;
            GameManager.instance.AddMonster(2);
        }
        else if (progress >= 66 && level < 3)
        {
            level = 3;
            UIManager.instance.ActivateMilestoneLayout(level);
            transform.localScale = new Vector3(3,3,0);
            light.pointLightOuterRadius = 15f;
            GameManager.instance.AddMonster(3);
            GameManager.instance.AddBomb();
            
        }

        if(progress > 100) progress = 100;
 
    }
    void HungerTimer(){
        if(gameObject) hunger -= 1;
        
        if(hunger > 100) hunger = 100;
    }
    
}