using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public GameObject Dialog;
    public Sprite Image;
    private void Start()
    {
        Dialog.transform.GetChild(0).GetComponent<Image>().sprite = Image;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController collsion = GetComponent<PlayerController>();
        if(collision != null)
        {
            Time.timeScale = 0f;
            Dialog.SetActive(true);
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
        }
    }
}
