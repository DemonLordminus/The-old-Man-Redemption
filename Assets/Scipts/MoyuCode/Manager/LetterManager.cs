using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject tragger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            tragger.SetActive(true);
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < tragger.transform.GetChild(i).childCount; j++)
                {
                    Destroy(tragger.transform.GetChild(i).GetChild(0).gameObject);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
