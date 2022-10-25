using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EverythingLoop : MonoBehaviour
{
    public List<GameObject> GameObjectForLoop;
    public Transform LoopMarkStr, LoopMarkEnd;
    public AutoFloorCreate atuofloor;
    public GameObject ElementFather;
    public GameObject BackGroudFather; 
    public GameObject EventFather;
    public float viewWidth;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            atuofloor.floorLoop();
        }
        catch
        { }
        if(GameObjectForLoop==null)
        {
            Debug.LogError("GameObjectForLoop未设置，已自动搜索");
            GameObjectForLoop.Add(GameObject.Find("EventElment"));
        }
        if(atuofloor==null)
        {
            atuofloor=GameObject.Find("AtuoFloor").GetComponent<AutoFloorCreate>(); 
        }
        if(ElementFather==null)
        {
            ElementFather = DataManager.instance.eventElementFather;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerPos = DataManager.instance.player.transform.position;
        if (playerPos.x>LoopMarkEnd.position.x)
        {
            Vector3 vectorDifference = new Vector3(LoopMarkEnd.position.x - LoopMarkStr.position.x, 0);
            foreach(GameObject go in GameObjectForLoop) 
            {
                go.transform.position -= vectorDifference;
            }
            DataManager.instance.player.transform.position -= vectorDifference;
            DataManager.instance.player.transform.position= new Vector3 (LoopMarkStr.position.x,DataManager.instance.player.transform.position.y,0);
            elementAtuoDestory();
            AutoDestory(EventFather);
            AutoDestory(BackGroudFather);
            atuofloor.floorLoop();
            DataManager.instance.controller.loopNum += 1;
        }
    }


    private void elementAtuoDestory()
    {
        float playerX=DataManager.instance.player.transform.position.x;
        eventElmentFather[] elements = ElementFather.transform.GetComponentsInChildren<eventElmentFather>();
        foreach(eventElmentFather element in elements)
        {
            //if(element.gameObject.transform.position.x<playerX)
            //{
            //        element.selfDestroyLater();
            //}
            if (element.gameObject.transform.position.x+viewWidth < playerX)
            {
                element.selfDestroyLater();
            }
        }
    }

    //void elementAtuoDstory()
    //{
    //    /*eventElmentFather[] elements = ElementFather.transform.GetComponentsInChildren<eventElmentFather>();
    //    foreach (eventElmentFather element in elements)
    //    {
    //        element.selfDestroyLater();
    //    }*/
    //    for (int i = 0; i < ElementFather.transform.childCount; i++)
    //    {
    //        DestroyImmediate(ElementFather.transform.GetChild(0).gameObject);
    //    }
    //}
    //void EventAutoDestory()
    //{
    //    float playerX = DataManager.instance.player.transform.position.x;
    //    for (int i = 0; i < EventFather.transform.childCount; i++)
    //    {
    //        var tmp = EventFather.transform.GetChild(0).gameObject;
    //        if (tmp.transform.position.x + viewWidth < playerX)
    //        {
    //            DestroyImmediate(tmp);
    //        }
    //    }
    //}
    //void BackGroudAutoDestory()
    //{
    //    for (int i = 0; i < BackGroudFather.transform.childCount; i++)
    //    {
    //        DestroyImmediate(BackGroudFather.transform.GetChild(0).gameObject);
    //    }
    //}

    private void AutoDestory(GameObject father)
    {
        float playerX = DataManager.instance.player.transform.position.x;
        for (int i = 0; i < father.transform.childCount; i++)
        {
            var tmp = father.transform.GetChild(0).gameObject;
            if (tmp.transform.position.x + viewWidth < playerX)
            {
                DestroyImmediate(tmp);
            }
        }
    }
}
