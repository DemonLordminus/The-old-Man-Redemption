using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventElementCreate : MonoBehaviour
{
    public List<GameObject> eventElementsList;
    public int createNum;
    //public int goodNum;
    public int badNum;
    public float minDistance, maxDistance;
    private int eventDataPerformedCount;
    public float groundY;
    public Transform startTransform;
    private Transform lastEventElements;
    public GameObject end;
    public Transform lastEndMark;
    public float ViewMaxX;//ÆÁÄ»Íâ×ø±ê
    public void CreateElement()
    {
        List<eventElmentFather> newEventScrList= new List<eventElmentFather>();
        bool[] created = new bool[eventElementsList.Count];
        for(int nowCount=0;nowCount<createNum;++nowCount)
        {
            int random;
            while (created[random=RandomEventElement()])
            {   
            }
            created[random] = true;
            Vector3 pos = new Vector3(lastEndMark.position.x + Random.Range(minDistance,maxDistance)/*,DataManager.instance.player.transform.position.x,GameObject.Find("End").gameObject.transform.position.x)*/,groundY,0);
            var newEvent= Instantiate(eventElementsList[random],pos,Quaternion.identity,DataManager.instance.eventElementFather.transform);
            lastEventElements = newEvent.transform;
            lastEndMark.position = lastEventElements.position;
            if (newEvent.TryGetComponent<eventElmentFather>(out eventElmentFather newScr))
            {
                newEventScrList.Add(newScr);
                newScr.isGood = true;
            }
            else 
            {
                if ((newScr=newEvent.transform.GetComponentInChildren<eventElmentFather>()) != null)
                {
                    newEventScrList.Add(newScr);
                    newScr.isGood = true;
                }
            }
        }
        //end.transform.position =new Vector3(lastEventElements.position.x,groundY,0);
        //Debug.Log(newEventScrList.Count);
        for (int nowBadNum=0;nowBadNum<badNum;++nowBadNum)
        {
            int tmp = Random.Range(0, newEventScrList.Count-1);
            newEventScrList[tmp].isGood = false;
            newEventScrList[tmp].changeForGoodOrBad();
            newEventScrList.Remove(newEventScrList[tmp]);
        }
        foreach(eventElmentFather eventTmp in newEventScrList)
        {
            eventTmp.changeForGoodOrBad();
        }

    }
    private void Start()
    {
        lastEventElements = DataManager.instance.player.transform;
        lastEndMark.position = lastEventElements.position;
        CreateElement();
    }
    public int loopNum;
    private void Update()
    {
        //if(DataManager.instance.controller.eventCountPerformed-eventDataPerformedCount>createNum)
        //{
        //    lastEventElements = startTransform;
        //    CreateElement();
        //    eventDataPerformedCount=DataManager.instance.controller.eventCountPerformed;
        //}
        //if(DataManager.instance.controller.loopNum>loopNum)
        //{
        //    lastEventElements = startTransform;
        //    CreateElement();
        //    loopNum += 1;
        //}
        if (lastEndMark.transform.position.x < ViewMaxX)
        {
            CreateElement();
        }
    }
    private int RandomEventElement()
    {
        int random = Random.Range(0,eventElementsList.Count);
        return random;   
    }
}
