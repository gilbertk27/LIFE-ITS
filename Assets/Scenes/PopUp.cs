using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject Detail;
    public bool aktif;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Detail.SetActive(aktif);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
