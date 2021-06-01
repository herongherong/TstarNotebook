using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShuriken : MonoBehaviour
{
    Collider[] inAreaEnemy;

    public Vector3 pos;

    int firstCollision;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�߷�ź ������ ��ũ��Ʈ Ȱ��ȭ");
        //http://www.devkorea.co.kr/bbs/board.php?bo_table=m03_qna&wr_id=86398 ����
        //Physics.OverlapSphere( A.transform.position(����3 ����) , float �ݰ� );
        //Collider[]  �ֺ�������Ʈ  = Physics.OverlapSphere( A.transform.position , ���ϴ� �Ÿ� );
        //�����ݰ� �ȿ� �ִ� ������Ʈ���� ���� ����.
        //����� ������Ʈ���� collider������Ʈ�� �־�� �ϰ� �ݶ��̴� �迭���·� ��ȯ��..
        inAreaEnemy = Physics.OverlapSphere(transform.position, 8f);

        pos = this.gameObject.transform.position;

        firstCollision = 1;

        //��ũ��Ʈ Ȱ��ȭ ��ü�� onTriggerEnter�� �������Ƿ� ���⿡ �ۼ�.
        if (firstCollision >= 1)
        {
            pos = this.gameObject.transform.position;
            firstCollision = 0;
            Debug.Log("����! ���̻� pos������ �����ϴ�");
        }
    }

    // Update is called once per frame
    void Update()
    {// 

        //������ ������ "�ݰ� �� ������Ʈ" ���� �ϳ��ϳ� ������ pos��ȯ��ų����)
        foreach (Collider col in inAreaEnemy)
        {
            if (col.tag == "Enemy")
            {//https://funfunhanblog.tistory.com/29 ����. ��𵹾Ƽ� ���̰� ����� �����ҵ���..
                Debug.Log("�߷��� �ȿ� �� �߰�");
                col.GetComponent<Enemy>().movingByBlackHole();
            }
        }


    }

    //��ũ��Ʈ Ȱ��ȭ ��ü�� onTriggerEnter�� �������Ƿ� start()�� �ۼ�
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Wall")
        {
            //Debug.Log("���߼����� ��򰡿� �浹");
            //gameObject.GetComponent<GravityBullet>().enabled = true;
            if(firstCollision >= 1)
            {
                pos = this.gameObject.transform.position;
                firstCollision = 0;
                Debug.Log("����! ���̻� pos������ �����ϴ�");
            }


        }
            
    }
    */



}