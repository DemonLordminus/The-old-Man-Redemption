using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreate : MonoBehaviour
{
    public List<GameObject> eventElementsList;
    //public int createNum;
    //public int goodNum;
    //public int badNum;
    //public float minDistance, maxDistance;
    public float groundY;
    public Transform groundTransform;
    private Transform lastEventElements;
    public Transform startTransform;
    public int loopNum;
    public int delta;
    //public GameObject end;
    public void CreateElement(float deltax)
    {
        lastEventElements = DataManager.instance.player.transform;
        //created[random] = true;
        Vector3 pos = new Vector3(lastEventElements.position.x + deltax, groundY, 0);
        /*var newEvent = */
        Instantiate(eventElementsList[0], pos, Quaternion.identity, groundTransform);
        #region
        //List<eventElmentFather> newEventScrList = new List<eventElmentFather>();
        /*bool[] created = new bool[eventElementsList.Count];
        for (int nowCount = 0; nowCount < createNum; ++nowCount)
        {
            int random = RandomEventElement();
            *//*while (created[random = RandomEventElement()])
            {
            }*//*
            created[random] = true;
            Vector3 pos = new Vector3(lastEventElements.position.x + deltax, groundY, 0);
            *//*var newEvent = *//*Instantiate(eventElementsList[random], pos, Quaternion.identity, groundTransform);
            //lastEventElements = newEvent.transform;
            #region
            *//*if (newEvent.TryGetComponent<eventElmentFather>(out eventElmentFather newScr))
            {
                newEventScrList.Add(newScr);
                newScr.isGood = true;
            }
            else
            {
                if ((newScr = newEvent.transform.GetComponentInChildren<eventElmentFather>()) != null)
                {
                    newEventScrList.Add(newScr);
                    newScr.isGood = true;
                }
            }*//*
        }
        //end.transform.position =new Vector3(lastEventElements.position.x,groundY,0);
        //Debug.Log(newEventScrList.Count);
        *//*for (int nowBadNum = 0; nowBadNum < badNum; ++nowBadNum)
        {
            int tmp = Random.Range(0, newEventScrList.Count - 1);
            newEventScrList[tmp].isGood = false;
            newEventScrList.Remove(newEventScrList[tmp]);
        }
*/
        #endregion
    }
    private void Start()
    {
        lastEventElements=DataManager.instance.player.transform;
        CreateElement(delta);
    }
    private void Update()
    {
        if (DataManager.instance.controller.loopNum > loopNum)
        {
            loopNum = DataManager.instance.controller.loopNum;
            CreateElement(delta*2);
            loopNum = DataManager.instance.controller.loopNum;
        }
        /* if (DataManager.instance.controller.eventCountPerformed - eventDataPerformedCount > createNum)
         {
             CreateElement();
             eventDataPerformedCount = DataManager.instance.controller.eventCountPerformed;
         }*/
    }
    /*private int RandomEventElement()
    {
        int random = Random.Range(0, eventElementsList.Count);
        return random;
    }*/
}
