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
    // Start is called before the first frame update
    void Start()
    {
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
            atuofloor.floorLoop();
            elementAtuoDestory(playerPos.x);
        }
    }


    private void elementAtuoDestory(float playerX)
    {
        eventElmentFather[] elements = ElementFather.transform.GetComponentsInChildren<eventElmentFather>();
        foreach(eventElmentFather element in elements)
        {
            if(element.gameObject.transform.position.x<playerX)
            {
                if(!element.isVisible)
                {
                    element.selfDestroyLater();
                }
            }
        }
    }


}
