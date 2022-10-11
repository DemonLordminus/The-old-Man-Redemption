using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//信的管理
public class LetterManager : MonoBehaviour
{
    //获取触发器
    public GameObject tragger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            //使信生成在触发器
            tragger.SetActive(true);
            //重置触发器的内容
            for (int i = 0; i < 3; i++)
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
