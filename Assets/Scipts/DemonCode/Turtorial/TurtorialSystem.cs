using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurtorialSystem : MonoBehaviour
{
    public PlayerControlForTurtorial contorl;
    public GameObject player;
    public GameObject HideBlock;
    public List<Transform> playerStop;
    public GameObject TurtorialText;
    public Vector3 showUpTextPos;
    public GameObject cam;
    public GameObject UIobj;
    public TextIntro[] textIn;
    [Serializable]
    public class TextIntro
    {
        public GameObject introText;
        //public Transform textTrigger;
        public GameObject scenceText;
        public Vector3 pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        UIobj.SetActive(true);
        InvokeRepeating("blockBecomeSmall", 0.5f, 0.01f);
    }
    void blockBecomeSmall()
    {
        HideBlock.transform.localScale -= new Vector3(0.02f, 0.02f, 0) ;
        if(HideBlock.transform.localScale.x<0.01f)
        {
            Destroy(HideBlock);
            CancelInvoke();
            playerShowUp();
        }
    }
    private bool showUp=false;
    private void playerShowUp()
    {
        contorl.forcePalse = false;
        showUp = true;
        contorl.RunSpeed *= 2;
    }
    private bool backgroundintro=false;
    private void backGroundintro()
    {
        backgroundintro= true;
        contorl.forcePalse = false;
    }    
    private void continueMove()
    {
        contorl.forcePalse = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(showUp)
        {
            if (player.transform.position.x >= playerStop[0].position.x) 
            {
                showUp = false;
                contorl.forcePalse = true;
                cam.GetComponent<CinemachineBrain>().enabled = true;
                contorl.RunSpeed /= 2;
                Invoke("backGroundintro", 3f);
                playerStop[0].gameObject.SetActive(false);
            }
            TurtorialText.transform.position =new Vector3(player.transform.position.x,0,0)+showUpTextPos;
        }
        else
        if(backgroundintro)
        {
            foreach(Transform tr in playerStop)
            {
                if(tr.gameObject.activeInHierarchy)
                {
                    if(player.transform.position.x >= tr.position.x)
                    {
                        contorl.forcePalse = true;
                        tr.gameObject.SetActive(false);
                        Invoke("continueMove", 3f);
                    }
                }
            }
           
        }

        foreach (TextIntro text in textIn)
        {
            if (text != null && text.introText != null)
            {
                text.introText.transform.position = Camera.main.WorldToScreenPoint(text.scenceText.transform.position + text.pos);

            }

        }
    }
}
