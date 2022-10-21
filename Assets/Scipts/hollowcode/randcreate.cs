using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class randcreate : MonoBehaviour
{
    public GameObject enemy;
    public GameObject mailbox;
    public GameObject medicine;
    public GameObject yaofang;
    public GameObject xinzhi;
    Transform tran;
    float nowx;
    float btime = 0;
    int k, n;
    public float mindistance, maxdistance;
    float distance;
    Vector3 createposition;

    void Start()
    {
        tran = gameObject.transform;
        nowx = tran.position.x;
        distance = Random.Range(mindistance, maxdistance);
    }

    void Update()
    {
        btime += Time.deltaTime;
        if (tran.position.x - nowx > distance && btime > 3)
        {
            createposition = new Vector3(tran.position.x + 50, -1, 0);
            n = Random.Range(0, 10);
            switch (n)
            {
                case 0: case 1: case 2: case 3: Instantiate(enemy, createposition, Quaternion.identity); break;
                case 6: Instantiate(mailbox, createposition, Quaternion.identity); break;
                case 7: case 4: case 5: Instantiate(medicine, createposition, Quaternion.identity); break;
                case 8: Instantiate(xinzhi, createposition, Quaternion.identity); break;
                case 9: Instantiate(yaofang, createposition, Quaternion.identity); break;
            }
            btime = 0;
            nowx = tran.position.x;
            distance = Random.Range(mindistance, maxdistance);
        }
    }
}
