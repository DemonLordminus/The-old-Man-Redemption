using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerController : MonoBehaviour
{
    #region  �ƶ�

    //�����ٶȱ���
    public float maxspeed;
    public float currentspeed;
    public bool isRun;
    //������Ծ����
    public float jumpVelocity = 0.5f;
    //�������Զ���
    Rigidbody2D Rigidbody2D;
    //��ȡ���ҷ���
    Vector2 lookdirection = new Vector2(1, 0);
    //���������
    int x;
    //��ʱ��
    float Timer;
    //����λ��
    private Vector2 Vector2;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealthy = MaxHealthy;
        CurrentSp = MaxSp;
        currentspeed = maxspeed;
        isRun = true;
        //�ֱ��ȡ��Ϸ����
        x = Random.Range(0, 2);
        //��ȡ����
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        OpenMyBag();
    }
    //��ʼ���ٶ�
    void NewSpeed()
    {
        if (CurrentSp == MaxSp && isRun == false)
        {
            isRun = true;
        }
    }
    void FixedUpdate()
    {
        //�л��ٶ�

        if ((CurrentSp > MaxSp / 10 && isRun)&&x!=0)
        {
            currentspeed = maxspeed;
            ChangeSp(-1);
        }
        else
        {
            currentspeed = maxspeed / 2;
            ChangeSp(2);
            isRun = false;
        }

        Move(x);
        //��ʱ��
        Timer -= Time.fixedDeltaTime;
        if (Timer <= 0)
        {
            //��ʼ��
            x = Random.Range(0, 2);
            Timer = 1.5f;
            NewSpeed();


        }

    }
    //�ƶ�
    public void Move(int i)
    {
        if (i == 0)
        {
            //��ȡ��ǰ��������λ��
            Vector2 position = transform.position;
            position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
            Rigidbody2D.position = position;
        }
        else
        {
            //���������ж�����1f���Ƿ����ͼ��Ϊ��Map���Ķ���
            RaycastHit2D hit = Physics2D.Raycast(Rigidbody2D.position + Vector2.up * 0.2f, lookdirection, 1f, LayerMask.GetMask("Map"));
            if (hit.collider != null)//������һ���赲����Ծ
            {
                //ʩ����ʹ֮�����Ծ
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpVelocity * Time.deltaTime);
            }
            //��ȡ��ǰ��������λ��
            Vector2 position = transform.position;
            position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
            Rigidbody2D.position = position;
        }
    }
    #endregion

    #region ��ֵϵͳ
    public float MaxHealthy;
    public float CurrentHealthy;
    public float Wealthy;
    public float MaxSp;
    public float CurrentSp;
    public float HappinessIndex;


    public void ChangeHealth(int amount)
    {
        CurrentHealthy = Mathf.Clamp(CurrentHealthy + amount, 0, MaxHealthy);
        HealthyBarManager.Instance.SetValue(CurrentHealthy / (float)MaxHealthy);
    }

    public void ChangeSp(int amount)
    {
        CurrentSp = Mathf.Clamp(CurrentSp + amount, 0, MaxSp);
        SpBarManager.Instance.SetValue(CurrentSp / (float)MaxSp);
    }
    #endregion

    #region �л�UI
    public GameObject myBar;
    public GameObject myBag;
    bool isOpean;

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isOpean = !isOpean;
            myBar.SetActive(isOpean);
            myBag.SetActive(!isOpean);
        }

    }
    #endregion


}
