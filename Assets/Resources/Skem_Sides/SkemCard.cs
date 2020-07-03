using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkemCard : MonoBehaviour{ 
    public GameObject Skem = null;
    private Animator _Skemanimator = null;
    public bool Skem_pop = false;
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] cardSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Final side or value that dice reads in the end of coroutine
    private int finalSide = 0;

    AudioSource ac;
    // Use this for initialization
    private void Start()
    {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();
        ac = GetComponent<AudioSource>();
        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        cardSides = Resources.LoadAll<Sprite>("Skem_Sides/");
        _Skemanimator = GetComponent<Animator>();
    }

    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine("RollTheCard");

        ac.PlayOneShot(ac.clip);

        if (Input.GetMouseButtonDown(0))
        {
            _Skemanimator.ResetTrigger("Skem_pop");
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BoxCollider2D coll = Skem.GetComponent<BoxCollider2D>();

            if (coll.OverlapPoint(wp))
            {
                _Skemanimator.SetTrigger("Skem_pop");
            }
        }
        //_Skemanimator.SetBool("Skem_pop", Skem_pop);
    }

    //private void OnMouseOver()
    //{
    //    switch (finalSide)
    //    {
    //        case 1:
    //            cardSides = Resources.Load<Sprite>("Skem_Sides/Side1.png");
    //            break;
    //        case 2:
    //            cardSides = Resources.Load<Sprite>("Skem_Sides/Side2.png");
    //            break;
    //        case 3:
    //            cardSides = Resources.Load<Sprite>("Skem_Sides/Side3.png");
    //            break;
    //    }
    //    If(Input.GetMouseButtonDown(1)){

    //    }
    //}


    // Coroutine that rolls the dice

    private IEnumerator RollTheCard()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomCardSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomCardSide = Random.Range(0, 13);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = cardSides[randomCardSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.11f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomCardSide + 1;

        // Show final dice value in Console
        Debug.Log(finalSide);

    }
}
