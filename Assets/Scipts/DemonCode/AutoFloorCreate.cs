using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFloorCreate : MonoBehaviour
{
    
    public GameObject floor;
    public float gap;
    [Range(1,30)]
    public int num;
    public List<GameObject> floorList;
    public Transform StartPos;
    public Transform EndPos;
    // Start is called before the first frame update
    void Start()
    {
        if(floor==null || StartPos==null)
        {
            Debug.LogError("floorŒ¥…Ë÷√");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    [EditorButton]
    public void reCreateFloor()
    {
        var start = StartPos.gameObject;
        foreach (GameObject fl in floorList)
        {
            if (fl != start)
            {
                DestroyImmediate(fl);
            }
        }
        floorList.Clear();
        floorList.Add(start);
        StartPos = start.transform;
        for(int count= floorList.Count; count<num;++count)
        {
            var floorIns = Instantiate(floor, transform);
            floorIns.transform.position=StartPos.position + new Vector3(count*gap, 0);
            floorList.Add(floorIns);
        }
    }
    public float positionX;
    Transform pos;
    public void floorLoop()
    {
        //List<GameObject> move=new List<GameObject>();
        foreach (GameObject fl in floorList)
        {
            try
            {
                if (fl.transform.position.x + gap < EndPos.position.x)
                {
                    //floorList.Remove(fl);
                    //move.Add(fl);
                    //floorList.Add(fl);
                    //Instantiate(floor, transform);
                    positionX = fl.transform.position.x;
                    Debug.Log("fl" + fl.transform.position.x);
                }
            }
            catch
            { }
        }
        Debug.Log(EndPos);
        Debug.Log(positionX);
        while(positionX-gap*2<EndPos.position.x)
        {
            Vector2 vector2 =new Vector2(floorList[floorList.Count-1].transform.position.x + positionX, floorList[floorList.Count-1].transform.position.y);
            pos.position = vector2;
            GameObject fl= Instantiate(floor, pos);
            floorList.Add(fl);
            positionX +=gap;
        }
        /*
        foreach (GameObject fl in move)
        {
            floorList.Add(fl);
            fl.transform.position = floorList[floorList.Count-1].transform.position+ new Vector3(gap, 0);
        }*/
    }
}
