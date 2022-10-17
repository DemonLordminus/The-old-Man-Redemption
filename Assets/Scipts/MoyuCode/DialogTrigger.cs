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
            collision.gameObject.GetComponent<PlayerController>().isPalse=true;
            Dialog.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
