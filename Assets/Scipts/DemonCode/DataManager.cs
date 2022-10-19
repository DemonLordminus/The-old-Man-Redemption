using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour 
{
    public static DataManager instance;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public PlayerController controller;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (player == null || controller == null)
        {
            Debug.LogWarning("DataManager≥ı÷µŒ¥…Ë÷√");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
