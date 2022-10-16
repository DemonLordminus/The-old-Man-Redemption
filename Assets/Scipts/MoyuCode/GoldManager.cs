using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public string Gold;
    public  GameObject Player;
    private void FixedUpdate()
    {
        Gold= Player.gameObject.GetComponent<PlayerController>().Gold.ToString();
        this.gameObject.GetComponent<Text>().text = Gold;
    }
}
