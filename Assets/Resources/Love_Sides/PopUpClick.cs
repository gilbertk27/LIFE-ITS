using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpClick : MonoBehaviour
{
    public GameObject Love = null;
    private Animator _loveanimator = null;

    // Start is called before the first frame update
    void Start()
    {
        _loveanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool Love_pop= false;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BoxCollider2D coll = Love.GetComponent<BoxCollider2D>();

            if (coll.OverlapPoint(wp))
            {
                Love_pop= true;
            }
        }

        _loveanimator.SetBool("Love_pop", Love_pop);
    }
}
