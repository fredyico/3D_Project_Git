using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public Vector3 moveOffset;
    private Vector3 targetPos;
    private Vector3 startPos;
    //public AudioClip moveSound;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {     

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            if (targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            }
            else
            {
                targetPos = startPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // check to see if enemy hit with player - then call the function 'GameOver' from PlayerController script
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().healthPoints > 0)
            {
                other.GetComponent<PlayerController>().ControlHealth(1);
            }
            else if (other.GetComponent<PlayerController>().healthPoints == 0)
            {
                other.GetComponent<PlayerController>().GameOver();

            }
        }
    }
}
