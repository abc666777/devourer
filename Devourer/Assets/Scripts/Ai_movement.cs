using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_movement : MonoBehaviour
{
    public float movespeed = 10.0f;
    public float rotspeed = 100f; // rot = rotation

    private bool iswander = false; //จะเดินหรือไม่
    private bool iswalking = true; //เดินอยู่หรือไม่
    private bool isLeftorRight = true; //ไปทางซ้ายหรือไปทางขวา true = ขวา false = ซ้าย
    private int isNorUorD = 1;//1 เท่าเดิม 2 ไปข้างบน 3 ไปข้างล่าง

    private int rotateNorUorD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(iswander == false){
            StartCoroutine(Wander());
        }
        if(iswalking == true){
            transform.position += new Vector3(isLeftorRight ? movespeed * Time.deltaTime : movespeed * Time.deltaTime * -1, IsUorDorN(),0);
        }
    }

    IEnumerator Wander(){
        int rotateWait = Random.Range(1, 3); //รอหมุน
        int rotateLorR = Random.Range(1, 2); //ซ้ายหรือขวา 1 L 2 R
        rotateNorUorD = Random.Range(1, 3); //ไม่,บนหรือล่าง 1 N 2 U 3 D
        int walkWait = Random.Range(1, 3); //รอเดิน
        int walkTime = Random.Range(1, 5);

        iswander = true;
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
        iswander = false;

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
