using Dmld;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    /*[SerializeField]
    public Package package;*/
    [SerializeField]
    public GameObject tragger;
    [SerializeField]
    public GameObject eventElementFather;
    [SerializeField]
    public ShijianList shijianList;
    [SerializeField]
    public ShijianList juqingList;
    [SerializeField]
    public List<string> eventFinishing;
    [SerializeField]
    public List<string> endFinishin;
    [SerializeField]
    public List <string> JuQingFinishin;
    [SerializeField]
    public GameObject allEvent;
    [SerializeField]
    public GameObject EndEvent;
    [SerializeField]
    public TextMeshProUGUI text;
    [SerializeField]
    public TextMeshProUGUI debufftext;
    [SerializeField]
    public TextMeshProUGUI lawtext;
    [SerializeField]
    public TextMeshProUGUI acttext;
    
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
        eventFinishing = new List<string>();
        endFinishin = new List<string>();
        JuQingFinishin = new List<string>();
        controller.ItemsPackage.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
