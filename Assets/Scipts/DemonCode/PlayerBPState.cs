using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBPState : MonoBehaviour
{
    public PlayerController control;
    public bpState bpS;
    public enum bpState
    {
        low,
        mid,
        high,
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if(control.CurrentBp<50)
        {
            bpS = bpState.mid;
            control.hpReduceRate = 1.5f;
        }
        else
            if(control.CurrentBp<20)
        {
            bpS = bpState.low;
            control.hpReduceRate = 2f;
        }
        else
        {
            bpS = bpState.high;
            control.hpReduceRate = 1f;
        }
        if(control.Gold<=0 && !control.isPalse)
        {
            control.ChangeBP(-0.03f);
        }
        
    }
}
