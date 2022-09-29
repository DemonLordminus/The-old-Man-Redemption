using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCollision : MonoBehaviour
{
    public List<GameObject> collisonWord;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<WordInstanceInfo>() != null)
        {
            collisonWord.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<WordInstanceInfo>() != null)
        {
            collisonWord.Remove(collision.gameObject);
        }
    }
}
