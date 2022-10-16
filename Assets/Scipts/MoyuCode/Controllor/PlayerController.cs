using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerController : MonoBehaviour
{
    #region  �ƶ�
    Animator animator;
    //�����ٶȱ���
    public bool isPalse;
    public float maxspeed;
    public float currentspeed;
    public bool isRun;
    //�������Զ���
    Rigidbody2D Rigidbody2D;
    //���������
    int x;
    //��ʱ��
    float Timer;
    //����λ��
    private Vector2 Vector2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isPalse = false;
        CurrentHealthy = MaxHealthy;
        CurrentSp = MaxSp;
        currentspeed = maxspeed;
        isRun = true;
        //�ֱ��ȡ��Ϸ����
        x = Random.Range(0, 2);
        //��ȡ����
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
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
        if (!isPalse)
        {
            //�л��ٶȣ�ʹ����������С��10%���ܱ��ܣ��ܲ�������������·��Ϣ�ָ�����
            if ((CurrentSp > MaxSp / 10 && isRun) && x != 0)
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
    }
    //�ƶ�
    public void Move(int i)
    {
        if (i == 0)
        { currentspeed = 0; }
        //��ȡ��ǰ��������λ��
        Vector2 position = transform.position;
        position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
        Rigidbody2D.position = position;
        animator.SetFloat("MoveX", currentspeed);
    }
    #endregion

    #region ��ֵϵͳ
    public float MaxHealthy;
    public float CurrentHealthy;
    public float Wealthy;
    public float MaxSp;
    public float CurrentSp;
    public float HappinessIndex;
    public float Gold;

    public void ChangeHealth(int amount)
    {
        CurrentHealthy = Mathf.Clamp(CurrentHealthy + amount, 0, MaxHealthy);
        HealthyBarManager.Instance.SetValue(CurrentHealthy / (float)MaxHealthy);
        if (CurrentHealthy <= 0)
        {
            isDie = true;
            Time.timeScale = 0f;
            gameOver.SetActive(isDie);
        }
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
    bool isDie;
    void OpenMyBag()
    {
        if (!isPalse)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isOpean = !isOpean;
                myBar.SetActive(isOpean);
                myBag.SetActive(!isOpean);
            }
        }
    }
    #endregion

    public GameObject gameOver;
}
