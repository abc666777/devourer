using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_movement : MonoBehaviour
{
    public float movespeed = 5f;
    public float rotspeed = 100f; // rot = rotation

    private bool iswander = false; //จะเดินหรือไม่
    private bool iswalking = true; //เดินอยู่หรือไม่
    private bool isLeftorRight = true; //ไปทางซ้ายหรือไปทางขวา true = ขวา false = ซ้าย
    private int rotateNorUorD;

    // Start is called before the first frame update
    void Start()
    {
        movespeed = Random.Range(1,6);
        rotateNorUorD = Random.Range(1,4);
    }

    // Update is called once per frame
    void FixedUpdate(){
        Debug.Log(rotateNorUorD);
        if(isWander){
            wander = StartCoroutine(Wander());
        }
        if(iswalking == true){
            transform.position += new Vector3(isLeftorRight ? movespeed * Time.deltaTime : movespeed * Time.deltaTime * -1, IsUorDorN() * Time.deltaTime,0);
        }
    }

    Coroutine wander = null;
    bool isWander {get{return wander != null;}}

    void StopWander(){
        StopCoroutine(wander);
        wander = null;
    }

    IEnumerator Wander(){
        Debug.Log(rotateNorUorD);
        int rotateWait = Random.Range(1, 4); //รอหมุน
        int rotateLorR = Random.Range(1, 3); //ซ้ายหรือขวา 1 L 2 R
        rotateNorUorD = Random.Range(1, 4); //ไม่,บนหรือล่าง 1 N 2 U 3 D
        int walkWait = Random.Range(1, 6); //รอเดิน
        int walkTime = Random.Range(1, 6);

        yield return new WaitForSeconds(rotateWait);

        if(rotateLorR == 2){
            isLeftorRight = true;
        }
        if(rotateLorR == 1){
            isLeftorRight = false;
        }

        yield return new WaitForSeconds(walkWait);
        iswalking = true;

        yield return new WaitForSeconds(walkTime);
        iswalking = false;
        StopWander();

    }

    private float IsUorDorN(){
        if (rotateNorUorD == 1){
            return 0;
        }else if (rotateNorUorD == 2){
            return movespeed;
        }else if (rotateNorUorD == 3){
            return movespeed * -1;
        }
        return 0;
    }

}