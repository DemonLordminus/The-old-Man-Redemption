using Dmld;
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
    [SerializeField]
    public LawOrActLists lawOrActLists;
    [SerializeField]
    public List<DebuffClass> debuffName;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (player == null || controller == null||lawOrActLists==null)
        {
            Debug.LogWarning("DataManager≥ı÷µŒ¥…Ë÷√");
        }
        debuffName = new List<DebuffClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
