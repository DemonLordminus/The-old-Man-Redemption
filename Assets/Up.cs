using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 vector2=transform.position;
        if(Input.GetKey(KeyCode.W))
        {
            vector2.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vector2.y -= 1;
        }
        transform.position=vector2;
    }
}
