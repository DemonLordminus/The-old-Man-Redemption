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
    public void floorLoop()
    {
        List<GameObject> move=new List<GameObject>();
        foreach (GameObject fl in floorList)
        {
            if (fl.transform.position.x+gap<DataManager.instance.player.transform.position.x)
            {
                //floorList.Remove(fl);
                move.Add(fl);
            }
        }
        foreach (GameObject fl in move)
        {
            floorList.Remove(fl);
            fl.transform.position = floorList[floorList.Count-1].transform.position+ new Vector3(gap, 0);
            floorList.Add(fl);
        }
    }
}
