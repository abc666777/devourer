using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_movement : MonoBehaviour
{
    public float movespeed = 5f;
    private int isLeftorRight; //ไปทางซ้ายหรือไปทางขวา true = ขวา false = ซ้าย
    private int[] arrayOfLeftRight = { -1, 1 };
    private int[] arrayOfUpDirection = { -1, 0, 1 };

    private int upDirection;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (transform.position.x > 0) isLeftorRight = -1;
        else if (transform.position.x < 0) isLeftorRight = 1;
        upDirection = arrayOfUpDirection[Random.Range(0, arrayOfUpDirection.Length)];
        movespeed = Random.Range(1, 6);
        wander = StartCoroutine(Wander());
    }
    // Update is called once per frame
    void Update()
    {
        sprite.flipX = isLeftorRight > 0 ? true : false;
        transform.position += new Vector3(movespeed * Time.deltaTime * isLeftorRight, upDirection * Time.deltaTime, 0);
    }

    Coroutine wander = null;
    bool isWander { get { return wander != null; } }

    void StopWander()
    {
        StopCoroutine(wander);
        wander = null;
    }

    IEnumerator Wander()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            isLeftorRight = arrayOfLeftRight[Random.Range(0, arrayOfLeftRight.Length)];
            upDirection = arrayOfUpDirection[Random.Range(0, arrayOfUpDirection.Length)];
            yield return new WaitForSeconds(Random.Range(1, 10));
        }
    }
}