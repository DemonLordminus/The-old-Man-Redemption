using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Dmld;
using System.Collections;
using Cinemachine;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class PlayerController : MonoBehaviour
{
    [Header("�ƶ���ֵ")]
    //�����ٶȱ���
    public bool isPalse;
    public float maxspeed;
    public float currentspeed;
    public bool isRun;
    public float RunReduceSp;
    public float WalkReduceSp;
    public float BreakRecoverSp;
    [Range(0, 100)]
    public float RunSpRange;
    [Range(0, 100)]
    public float WalkSpRange;
    [Range(0, 100)]
    public float BreakSpRange;
    [Range(0, 100)]
    public float RestToSp;//��Ϣ�ָ�����sp����
    public float RunSpeed;
    public float WalkSpeed;
    [Header("debuff��Ҫ����ֵ")]
    public float FaliReduceSp;
    public float mangmuTimeSmall;
    public float mangmuTimeBig;
    public float zhongduReduceHp;
    public float fareReduceSp;
    public float fareReduceSpMax;
    public float yiyuReduceBp;
    public float huxikunanReduceHp;
    public float jiwangRunTime;
    public float CurrentTime;//������
    public float mangmuTime;
    public CinemachineVirtualCamera virtualCamera;
    public DebuffClass[] debuffs;
    [Range(0, 100)]
    public float hunluanRandom;
    #region  �ƶ�
    Animator animator;
    [Header("������Ҫ����ֵ")]
    public float reSp;
    public int nlylcot;
    //�������Զ���
    Rigidbody2D Rigidbody2D;
    //���������
    int x;
    //��ʱ��
    float Timer;
    //����λ��
    //private Vector2 Vector2;
    // Start is called before the first frame update
    void Start()
    {

        Initialize();
        animator = GetComponent<Animator>();
        isPalse = false;
        CurrentBp = MaxBp;
        CurrentHealthy = MaxHealthy;
        CurrentSp = MaxSp;
        currentspeed = maxspeed;
        isRun = true;
        reSp = 1;
        nlylcot = 0;
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
        if (CurrentSp >= MaxSp / 1.01 && isRun == false)
        {
            isRun = true;
        }
    }
    void FixedUpdate()
    {
        RunSpeed = Mathf.Clamp(RunSpeed, WalkSpeed, maxspeed);
        WalkSpeed = Mathf.Clamp(WalkSpeed, 0, RunSpeed);
        if (!isPalse)
        {
            if (debuffs[9].isEnable)
            {
                if (debuffs[9].keepTime > mangmuTimeSmall)
                {
                    mangmuTime = -1;
                }
                else if (debuffs[9].keepTime > mangmuTimeBig)
                {
                    mangmuTime = 0f;
                }
                else
                {
                    mangmuTime = 1 / 10f;
                }
                virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize + mangmuTime * Time.fixedDeltaTime, 2, 5);
            }
            if (CurrentSp < MaxSp / 9 && debuffs[4].isEnable)
            {
                ChangeHealth(-huxikunanReduceHp);
            }
            //�л��ٶȣ�ʹ����������С��10%���ܱ��ܣ��ܲ�������������·��Ϣ�ָ�����
            if ((CurrentSp > MaxSp * RunSpRange / 100 && isRun) && x != 0 && !debuffs[2].isEnable)//fali)
            {
                currentspeed = RunSpeed;
                ChangeSp(-RunReduceSp);
            }
            else if (CurrentSp > MaxSp * WalkSpRange / 100 && isRun && x != 0)
            {
                ChangeSp(-WalkReduceSp);
                currentspeed = WalkSpeed;
            }
            else
            {
                if (debuffs[4].isEnable)//huxikunnan)
                {
                    ChangeSp(BreakRecoverSp / 2);
                }
                else
                {
                    ChangeSp(BreakRecoverSp);
                }
                currentspeed = WalkSpeed / 2;
                isRun = false;
            }
            Move(x);
            if (debuffs[1].isEnable)//fare)
            {
                ChangeSp(-fareReduceSp);
            }
            if (debuffs[3].isEnable)//outufuxie)
            {
                ChangeHealth(Convert.ToInt32(-1 - debuffs[3].keepTime / 10));
            }
            if (debuffs[7].isEnable)//yiyu
            {
                ChangeBP(-yiyuReduceBp);
            }
            #region �������δ���
            if (debuffs[10].isEnable == true)//��ҩ��sp�ظ�
            {
                reSp += 1;
            }
            if (debuffs[11].isEnable == true && nlylcot == 1)//�������ϵ�sp�ظ�
            {
                reSp += 1;
            }
            if (debuffs[11].isEnable == true && nlylcot >= 2)//������������buff���ϵ�Ч��
            {
                reSp += 1.5f;
                ChangeHealth(-(nlylcot));
            }
            if (debuffs[11].isEnable == true)//�����������Ʒ�����Ч��
            {
                debuffs[2].isEnable = false;
            }
            if (debuffs[12].isEnable == true)//����ƿ��sp�ظ�Ч��
            {
                reSp += 1;
            }
            if (debuffs[16].isEnable == true)//ֹʹҩ��hp����Ч��
            {
                ChangeHealth(-0.04f);
            }
            if (debuffs[15].isEnable == true)//��ҩˮ����Ұ�ָ�
            {
                virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize - 0.002f, 2, 5);
            }
            #endregion
            //��ʱ��
            Timer -= Time.fixedDeltaTime;
            if (Timer <= 0)
            {
                //��ʼ��
                x = Random.Range(0, 2);
                if (debuffs[0].isEnable)//zhongdu)
                {
                    ChangeHealth(-zhongduReduceHp);
                }
                if (debuffs[1].isEnable)//fare)
                {
                    MaxSp -= fareReduceSpMax;
                }
                Timer = 1.5f;
                NewSpeed();
            }
            if (debuffs[6].isEnable && debuffs[6].keepTime - CurrentTime > jiwangRunTime)//jianwang)
            {
                Jianwang();
                CurrentTime = debuffs[6].keepTime;
            }
            UpdateDebuffTime();
        }
        else
        {
            Move(0);
        }
    }
    //�ƶ�
    public void Move(int i)
    {
        if (i == 0)
        { currentspeed = 0; }
        //��ȡ��ǰ��������λ��
        Vector2 position = transform.position;
        if (debuffs[2].isEnable)//fali)
        {
            position.x = position.x + currentspeed / 2 * i * Time.fixedDeltaTime;
        }
        else
        {
            position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
        }
        Rigidbody2D.position = position;
        animator.SetFloat("MoveX", currentspeed);
    }
    #endregion

    #region ��ֵϵͳ
    [Header("��ֵϵͳ")]
    public float MaxHealthy;
    public float CurrentHealthy;
    public float MaxSp;
    public float CurrentSp;
    public float MaxBp;//�Ҹ�ֵ
    public float CurrentBp;
    public float Gold;

    public void ChangeHealth(float amount)
    {
        CurrentHealthy = Mathf.Clamp(CurrentHealthy + amount, 0, MaxHealthy);
        HealthyBarManager.Instance.SetValue(CurrentHealthy / (float)MaxHealthy);
        if (CurrentHealthy <= 0)
        {
            Time.timeScale = 0f;
            gameover = true;
            DataManager.instance.EndEvent.SetActive(true);
        }
    }

    public void ChangeSp(float amount)
    {
        CurrentSp = Mathf.Clamp(CurrentSp + amount, 0, MaxSp);
        SpBarManager.Instance.SetValue(CurrentSp / (float)MaxSp);
    }

    public void ChangeBP(float amount)
    {
        CurrentBp = Mathf.Clamp(CurrentBp + amount, 0, MaxBp);
        BlissBarManager.Instance.SetValue(CurrentBp / (float)MaxBp);
    }


    #endregion
    #region debuff
    //0=�ж�
    //1=����
    //2=����
    //3=Ż�¸�к
    //4=��������
    //5=����
    //6=����
    //7=����
    //8=����
    //9=äĿ


    [HideInInspector]
    public const int maxDebuffNum = 17;//���֢����

    void Initialize()
    {
        debuffs = new DebuffClass[maxDebuffNum];
        for (int order = 0; order < maxDebuffNum; ++order)
        {
            debuffs[order] = new DebuffClass(order);
        }
    }
    void UpdateDebuffTime()
    {
        foreach (DebuffClass debuff in debuffs)
        {
            if (debuff.keepTime > 0)
            {
                debuff.keepTime -= Time.fixedDeltaTime;
                if (debuff.keepTime < 0)
                {
                    debuff.isEnable = false;
                    debuff.keepTime = 0;
                    if (debuff.DebuffOrder == 11)//����������ؼ��
                    {
                        nlylcot = 0;
                        if (debuffs[2].keepTime > 0)
                        {
                            debuffs[2].isEnable = true;
                        }
                    }
                }
            }
        }
    }
    #endregion
    #region �л�UI
    [Header("UI�л�����")]
    public GameObject myBar;
    public GameObject myBag;
    bool isOpean;
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
    [HideInInspector]
    public bool gameover;
    #region ��ײ
    [Header("��ײ�������")]
    public bool IsTrue;
    public bool Isrun;
    //public string whatEnemy;
    public List<GetItem> ItemsPackage;
    public int eventCountPerformed;//�������¼���
    public int loopNum;
    public bool IfHunluan()
    {
        if (debuffs[5].isEnable && Random.Range(0, 100) < hunluanRandom)
        {
            return false;
        }
        return true;
    }
    //public int num;
    void Jianwang()
    {
        DataManager.instance.lawOrActLists.lawlists.RemoveRange(((int)Random.Range(0, DataManager.instance.lawOrActLists.lawlists.Count / 3)) * 3, 3);
    }
    public bool Probability(int amount)
    {
        if (Random.Range(0, 101) < amount)
        {
            return true;
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "mailbox")
        {
            eventCountPerformed++;
            collision.gameObject.GetComponent<eventElmentFather>().getEventPerform(); return;
        }
        if (IfHunluan())
        {
            eventCountPerformed++;
            OnEvent(collision);
        }
        else
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        #region �ϴ���
        /*if (propsController != null)//�ж�Ϊ��Ʒ
        {
            if (IfHunluan())
            {
                GetItem = propsController.GetItem;
                Package = propsController.Package;
                switch (GetItem.Name)//����GetItem����е�Name�������ж��Ƿ�����
                {
                    case "Yaoping":
                        IsTrue = (citiaos[14] && citiaos[17] && citiaos[1] || citiaos[0] && citiaos[15]) && Isrun;
                        if (citiaos[0])
                        {
                            citiaos[15] = false;
                        }; break;
                    case "xin":; collision.gameObject.GetComponent < AddNewItem()BoxCollider2D > ().isTrigger = true; return;
                    default: break;
                }
                if (IsTrue)
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    return;
                }
                else
                {
                    if (GetItem.Name == "Yaoping")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                        if (Gold > 50)
                        {
                            AddNewItem();
                            Gold -= 50;
                        }
                        return;
                    }
                    AddNewItem();
                    Destroy(collision.gameObject);
                    Destroy(collision.transform.parent.gameObject);
                }
            }
            else
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        else if (enemyController != null)
        {
            if (IfHunluan())
            {
                IsTrue = (citiaos[12] && citiaos[17] && citiaos[1] || citiaos[13] && citiaos[0]) && Isrun;
                if (citiaos[0])
                {
                    citiaos[13] = false;
                }
                if (IsTrue)
                {
                    try
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    }
                    catch
                    { };

                }
                else
                {
                    ChangeHealth(-10);
                    whatEnemy = enemyController.whatEnemy;
                    Destroy(collision.gameObject);
                    Destroy(collision.transform.parent.gameObject);
                }
            }
            else
            {
                ChangeHealth(-10);
                whatEnemy = enemyController.whatEnemy;
                Destroy(collision.gameObject);
                Destroy(collision.transform.parent.gameObject);
            }
        }*/
        #endregion

    }
    void OnEvent(Collision2D collision)
    {
        if (collision.gameObject.tag == "EventElement")
        {
            if (debuffs[13].isEnable)
            {
                collision.gameObject.GetComponent<eventElmentFather>().random += 5;
            }
            if (collision.gameObject.GetComponent<virusEvent>() != null && debuffs[14].isEnable)
            {
                collision.gameObject.GetComponent<virusEvent>().random += 5;
            }
            collision.gameObject.GetComponent<eventElmentFather>().getEventPerform();
        }
    }
    #endregion

    #region ��ȡ
    public void AddNewItem(GetItem item)
    {
        if (!ItemsPackage.Contains(item))
        {
            item.Num = 1;
            ItemsPackage.Add(item);

        }
        else
        {
            item.Num++;
        }
        PackageManager.RefreshItem();

    }
    public void AddNewItem(GetItem[] Item)
    {
        foreach (GetItem item in Item)
        {
            if (!ItemsPackage.Contains(item))
            {
                item.Num = 1;
                ItemsPackage.Add(item);

            }
            else
            {
                item.Num++;
            }
        }
        PackageManager.RefreshItem();

    }
    #endregion
}
