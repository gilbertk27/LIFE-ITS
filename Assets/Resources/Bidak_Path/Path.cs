using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject Tile1Click;
    public bool aktif;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Tile1Click.SetActive(aktif);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
