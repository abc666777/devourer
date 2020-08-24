﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float speed = 15f;
    private const float speedPenalty = 0.5f;
    private const float speedBonus = 1.5f;
    private float movingPenalty = 1;
    public bool isSlow = false;
    public bool isFast = false;
    Rigidbody2D rb;
    public int level = 1;


    public Light2D light;
    public float hunger = 100;
    public float progress = 0;

    public float score = 0;

    public const float maxProgress = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("HungerTimer", 1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetSpeed();
        Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPosition = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y,0), destination, Time.fixedDeltaTime * speed * movingPenalty);
        rb.MovePosition(newPosition);

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
            StopLevelingUp();
            Debug.Log(level);
            levelingUp = StartCoroutine(LevelingUp(new Vector3(2,2,0),5f));
            Debug.Log(isLevelingUp);
        }
        else if (progress >= 66 && level < 3)
        {
            level = 3;
            UIManager.instance.ActivateMilestoneLayout(level);
            StopLevelingUp();
            levelingUp = StartCoroutine(LevelingUp(new Vector3(3,3,0),7f));
        }

        if(progress > 100) progress = 100;
 
    }
    Coroutine levelingUp = null;
    bool isLevelingUp {get {return levelingUp != null;}}

    IEnumerator LevelingUp(Vector3 newScale, float newLightRadius){
        while(transform.localScale != newScale && light.pointLightOuterRadius != newLightRadius){
            transform.localScale = Vector3.MoveTowards(transform.localScale, newScale, 1f * Time.deltaTime);
            light.pointLightOuterRadius = Mathf.MoveTowards(light.pointLightOuterRadius, newLightRadius, 1f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        StopLevelingUp();
    }

    void HungerTimer(){
        if(gameObject) hunger -= 1;
        
        if(hunger > 100) hunger = 100;
    }

    void StopLevelingUp(){
        if(isLevelingUp){
            StopCoroutine(levelingUp);
        }
        levelingUp = null;
    }
    
}