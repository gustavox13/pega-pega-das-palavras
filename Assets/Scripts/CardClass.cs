using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClass : MonoBehaviour
{
    [SerializeField]
    private GameObject controler;


    [SerializeField]
    private int myCode;

    private Animator myAnim;

    private void Start()
    {
        myAnim = this.gameObject.GetComponent<Animator>();
    }


    private void OnMouseUpAsButton()
    {
        controler.GetComponent<GameControler>().CheckAnswer(myCode);
    }


    public void myExitAnim()
    {
        
        myAnim.SetBool("exitAnim", true);
    }



}
