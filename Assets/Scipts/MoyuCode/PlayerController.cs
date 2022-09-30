using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerController : MonoBehaviour
{
    #region ʵ������ƶ���Ѱ��
    //�����յ���Ϸ����
    GameObject IfGreen;
    GameObject IfGuaiwu;
    //���������жϱ���
    public bool Green ;
    public bool Guaiwu ;
    //����һ����Ϸ����
    GameObject playobject;
    //�����ٶȱ���
    public float speed;
    //������Ծ����
    public float jumpVelocity = 0.5f;
    //�������Զ���
    Rigidbody2D Rigidbody2D;
    //��ȡ���ҷ���
    Vector2 lookdirection = new Vector2(1, 0);
    Vector2 lookdirection1 = new Vector2(-1, 0);
    //���������
    int x ;
    //��ʱ��
    float Timer;
    //����λ��
    private Vector2 Vector2;
    // Start is called before the first frame update
    void Start()
    {
        //�ֱ��ȡ��Ϸ����
        x = Random.Range(-1, 2);
        playobject = GameObject.Find("Sprite-0003");
        //��ȡ����
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //���������ж�����1f���Ƿ����ͼ��Ϊ��Map���Ķ���
        RaycastHit2D hit = Physics2D.Raycast(Rigidbody2D.position + Vector2.up * 0.2f, lookdirection,1f, LayerMask.GetMask("Map"));
        RaycastHit2D hit1 = Physics2D.Raycast(Rigidbody2D.position + Vector2.up * 0.2f, lookdirection1, 1f, LayerMask.GetMask("Map"));
        if (hit.collider != null||hit1.collider !=null)//������һ���赲����Ծ
        {
            //ʩ����ʹ֮�����Ծ
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpVelocity * Time.deltaTime);
        }
        //�������жϻ�ȡֵ
        try
        {
            IfGreen = GameObject.FindWithTag("Green");
            IfGuaiwu = GameObject.FindWithTag("Guaiwu");
            Green =IfGreen.GetComponent<Green>().Isgreen;
            Guaiwu = IfGuaiwu.GetComponent<Guaiwu>().Isguaiwu;
        }
        catch
        { }
        if (Green && Guaiwu)//����ͬʱ����
        {
            //���������ƶ�
            transform.position = Vector2.MoveTowards(transform.position, playobject.transform.position, speed * Time.deltaTime);
        }
        else
        {
            //����Move�������
            Move(x);
            //��ʱ��
            Timer -= Time.fixedDeltaTime;
            if (Timer <= 0)
            {
                //��ʼ��
                x = Random.Range(-1, 2);
                Timer = 1.5f;
            }

        }

    }
    //�ƶ�
    public void Move(int i)
    {
        //��ȡ��ǰ��������λ��
        Vector2 position = transform.position;
        position.x = position.x + speed * i * Time.fixedDeltaTime;
        Rigidbody2D.position = position;
    }
    #endregion
}
