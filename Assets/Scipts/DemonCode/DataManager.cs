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
    [SerializeField]
    public List<string> Events;
    [SerializeField]
    public Package package;
    [SerializeField]
    public GameObject tragger;
    [SerializeField]
    public GameObject eventElementFather;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (player == null || controller == null||lawOrActLists==null||tragger==null)
        {
            Debug.LogWarning("DataManager≥ı÷µŒ¥…Ë÷√");
        }
        debuffName = new List<DebuffClass>();
        package.Items.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
