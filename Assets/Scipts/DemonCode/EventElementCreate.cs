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
    private Transform lastEventElements;
    public void createElement()
    {
        List<eventElmentFather> newEventScrList= new List<eventElmentFather>();
        bool[] created = new bool[eventElementsList.Count];
        for(int nowCount=0;nowCount<createNum;++nowCount)
        {
            int random;
            while (created[random=randomEventElement()])
            {   
            }
            created[random] = true;
            Vector3 pos = new Vector3(lastEventElements.position.x + Random.Range(minDistance,maxDistance),groundY,0);
            var newEvent= Instantiate(eventElementsList[random],pos,Quaternion.identity,DataManager.instance.eventElementFather.transform);
            lastEventElements = newEvent.transform;
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
        //Debug.Log(newEventScrList.Count);
        for(int nowBadNum=0;nowBadNum<badNum;++nowBadNum)
        {
            int tmp = Random.Range(0, newEventScrList.Count-1);
            newEventScrList[tmp].isGood = false;
            newEventScrList.Remove(newEventScrList[tmp]);
        }

    }
    private void Start()
    {
        lastEventElements = DataManager.instance.player.transform;
        createElement();
        createElement();
    }
    private void Update()
    {
        if(DataManager.instance.controller.eventCountPerformed-eventDataPerformedCount>createNum)
        {
            createElement();
            eventDataPerformedCount=DataManager.instance.controller.eventCountPerformed;
        }
    }
    private int randomEventElement()
    {
        int random = Random.Range(0,eventElementsList.Count);
        return random;   
    }
}
