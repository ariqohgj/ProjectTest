using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool change;

    public GameObject[] ObjectBaru;
    public GameObject CurrentObejct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            rb.position += Vector3.forward * Time.deltaTime * speed;
        }
        else
        {
            rb.position += Vector3.back * Time.deltaTime * speed;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        List<GameObject> list = new List<GameObject>();

        if (collision.gameObject.tag == "Wall")
        {
            
            if(!change)
            {
                change = true;
            }
            else
            {
                change = false;
            }
        }

        foreach (GameObject obj in ObjectBaru)
        {
            CurrentObejct.gameObject.SetActive(false);
            if(obj != CurrentObejct)
            {
                list.Add(obj);
            }
        }

        CurrentObejct = list[Random.Range(0, list.Count)].gameObject;
        CurrentObejct.SetActive(true);
    }
}
