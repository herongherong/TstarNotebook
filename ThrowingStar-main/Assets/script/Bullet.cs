using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject TargetObj;
    Vector3 offset;
    Transform tr;

    public bool isCollsion = false;

    public GameObject explosionEffect;

    public float bulletSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        TargetObj = null;
        isCollsion = false;
        offset = new Vector3(0, 0, 0);
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isCollsion)
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
            isCollsion = true;
            Invoke("explosion", 3);

        }

        if (other.tag == "Wall")
        {
            TargetObj = GameObject.FindWithTag("Enemy");
            offset = TargetObj.transform.position - transform.position;
            isCollsion = true;
            Invoke("explosion", 3);

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
        Collider[] colls = Physics.OverlapSphere(tr.position, 10.0f);

        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();
            if (rbody != null)
            {
                rbody.mass = 1.0f;
                rbody.AddExplosionForce(1000, tr.position, 10f);
            }
        }

        Instantiate(explosionEffect, tr.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
