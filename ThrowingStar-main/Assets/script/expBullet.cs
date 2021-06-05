using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expBullet : MonoBehaviour
{

    GameObject TargetObj;
    Vector3 offset;
    Transform tr;

    public float cookingTime;
    public bool isCollision = false;

    public GameObject explosionEffect;

    public float bulletSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        TargetObj = null;
        isCollision = false;
        offset = new Vector3(0, 0, 0);
        tr = GetComponent<Transform>();
        cookingTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {

        if (isCollision)
        {
            transform.position = TargetObj.transform.position - offset;
        }
        else
        {
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        tr.position = transform.position;

        if (other.tag == "Enemy")
        {
            TargetObj = GameObject.FindWithTag("Enemy");
            offset = TargetObj.transform.position - transform.position;
            isCollision = true;
            Invoke("explosion", cookingTime);

        }

        if (other.tag == "Wall")
        {
            TargetObj = GameObject.FindWithTag("Wall");
            offset = TargetObj.transform.position - transform.position;
            isCollision = true;
            Invoke("explosion", cookingTime);

        }

       
    }

    void collisionOK()
    {
        rotateShuriken rotateshuriken = GameObject.Find("Shuriken").GetComponent<rotateShuriken>();
        //rotateshuriken.isCol = true;
        //rotateshuriken.turnSpeed = 0.0f ;

    }

    private void explosion()
    {
        Collider[] colls = Physics.OverlapSphere(tr.position, 4.0f);

        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();
            if (rbody != null)
            {
                rbody.mass = 1.0f;
                rbody.AddExplosionForce(300, tr.position, 10f);
            }
        }

        Instantiate(explosionEffect, tr.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
