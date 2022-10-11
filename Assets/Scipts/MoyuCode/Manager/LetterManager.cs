using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ŵĹ���
public class LetterManager : MonoBehaviour
{
    //��ȡ������
    public GameObject tragger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            //ʹ�������ڴ�����
            tragger.SetActive(true);
            //���ô�����������
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
