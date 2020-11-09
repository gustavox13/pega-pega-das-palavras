using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairClass : MonoBehaviour
{
    [SerializeField]
    private GameObject cardBack1;
    [SerializeField]
    private GameObject cardBack2;

    [SerializeField]
    private GameObject textCorrect;

    [SerializeField]
    private GameObject cardLeft;
    [SerializeField]
    private GameObject cardRight;

    public int correctSide;


    public void playCards()
    {
        cardBack1.SetActive(false);
        cardBack2.SetActive(false);

        cardLeft.SetActive(true);
        cardRight.SetActive(true);
    }

    public void DisableColliders()
    {
        cardLeft.GetComponent<BoxCollider2D>().enabled = false;
        cardRight.GetComponent<BoxCollider2D>().enabled = false;
    }


    public void EnableColliders()
    {
        cardLeft.GetComponent<BoxCollider2D>().enabled = true;
        cardRight.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ExitCards()
    {
        textCorrect.SetActive(true);

        cardLeft.GetComponent<CardClass>().myExitAnim();
        cardRight.GetComponent<CardClass>().myExitAnim();
    }


}
