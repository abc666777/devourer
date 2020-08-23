using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100;

    private const float speedPenalty = 0.2f;

    public bool isAffected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) isAffected = !isAffected;
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        float movingPenalty = isAffected ? speedPenalty : 1;
        transform.Translate(Vector2.up * (speed * Time.deltaTime * y * movingPenalty));
        transform.Translate(Vector2.right * (speed * Time.deltaTime * x * movingPenalty));
    }
}