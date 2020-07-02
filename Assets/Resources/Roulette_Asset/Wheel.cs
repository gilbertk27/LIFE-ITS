using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour{
    private int randomValue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;

    //[SerializeField]
    //private Text winText;

    AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioSource>();
        //coroutineAllowed = true;
    }

    // If you left click over the roulette then the coroutine is started
    private void OnMouseDown()
    {
        ac.PlayOneShot(ac.clip);
        StartCoroutine("Spin");
    }

    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomValue = Random.Range(20, 30);
        timeInterval = 0.1f;

        for (int i = 0; i < randomValue; i++)
        {
            transform.Rotate(0, 0, 30f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomValue * 0.85f))
                timeInterval = 0.4f;
            yield return new WaitForSeconds(timeInterval);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 90 == 0)
            transform.Rotate(0, 0,45f);

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 0:
                break;
            case 45:
                break;
            case 90:
                break;
            case 135:
                break;
            case 180:
                break;
            case 225:
                break;
            case 270:
                break;
            case 315:
                break;
        }

        coroutineAllowed = true;

    }

    // Update is called once per frame
        void Update()
    {
        
    }
}
