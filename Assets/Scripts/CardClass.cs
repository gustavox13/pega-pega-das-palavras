using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClass : MonoBehaviour
{
    [SerializeField]
    private GameObject controler;

    [SerializeField]
    private GameObject cardSongObj;

    private AudioSource cardsong;

    [SerializeField]
    private int myCode;

    private Animator myAnim;

    private void Start()
    {
        cardsong = cardSongObj.GetComponent<AudioSource>();

        myAnim = this.gameObject.GetComponent<Animator>();
    }


    private void OnMouseUpAsButton()
    {
        cardsong.Play();
        controler.GetComponent<GameControler>().CheckAnswer(myCode);
    }


    public void myExitAnim()
    {
        
        myAnim.SetBool("exitAnim", true);
    }



}
