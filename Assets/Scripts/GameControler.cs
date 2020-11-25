using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pairs = new GameObject[6];

    [SerializeField]
    private GameObject pacoca;

    private Animator pacocaAnim;

    [SerializeField]
    private GameObject tutorial;

    private int currentTurn = 0;

    public int QuantPlay = 0;

    [SerializeField]
    private GameObject[] categoria = new GameObject[3];

    [SerializeField]
    private GameObject finalScreen;


    private AudioSource shuffleSong;

    private AudioSource pointAlert;
    [SerializeField]
    private GameObject PointAlertObj;

    [SerializeField]
    private GameObject princesaArmClose;
    [SerializeField]
    private GameObject princesaArmFinal;

    [SerializeField]
    private GameObject principeArmClose;
    [SerializeField]
    private GameObject principeArmFinal;

    private void Start()
    {
        pointAlert = PointAlertObj.GetComponent<AudioSource>();
        pacocaAnim = pacoca.GetComponent<Animator>();

        shuffleSong = this.gameObject.GetComponent<AudioSource>();
    }

   

    public void CloseTutoAndStart()
    {
        tutorial.SetActive(false);
        StartTurn();
    }


    private void StartTurn()
    {
        shuffleSong.Play();

        changeCategoria();
        pairs[currentTurn].GetComponent<PairClass>().playCards();
    }


    private void changeCategoria()
    {
        if (currentTurn < 2)
        {
            categoria[0].SetActive(true);

        }
        else if (currentTurn >= 2 && currentTurn < 4)
        {
            categoria[0].SetActive(false);
            categoria[1].SetActive(true);
        }
        else
        {
            categoria[1].SetActive(false);
            categoria[2].SetActive(true);
        }
    }


    public void CheckAnswer(int answer)
    {
        QuantPlay++;

        if(pairs[currentTurn].GetComponent<PairClass>().correctSide == answer) // RESPOSTA CORRETA
        {
         
            
            StartCoroutine(CorrectAnswer());
        }
        else // RESPOSTA ERRADA
        {
            StartCoroutine(WrongAnswer());
        }

        
    }


    IEnumerator WrongAnswer()
    {
        pacocaAnim.SetTrigger("wrong");
        pairs[currentTurn].GetComponent<PairClass>().DisableColliders(); //DESABILITA BOTAO IMEDIATAMENTE

        yield return new WaitForSeconds(1.5f);

        pairs[currentTurn].GetComponent<PairClass>().EnableColliders(); //HABILITA BOTAO IMEDIATAMENTE
    }


     IEnumerator CorrectAnswer()
    {
        pointAlert.Play();

        pairs[currentTurn].GetComponent<PairClass>().DisableColliders(); //DESABILITA BOTAO IMEDIATAMENTE

        pairs[currentTurn].GetComponent<PairClass>().ExitCards(); //animacao de vitoria


        yield return new WaitForSeconds(4.5f);

        EndTurn();
    }

    private void EndTurn()
    {
        if(currentTurn < 4) // VAI PRO PROX DESAFIO
        {
            currentTurn++;
            StartTurn();
        } else if(currentTurn == 4)
        {

            princesaArmClose.SetActive(false);
            principeArmClose.SetActive(false);

            princesaArmFinal.SetActive(true);
            principeArmFinal.SetActive(true);

            currentTurn++;
            StartTurn();

        }
        else
        {
            finalScreen.SetActive(true);
            
        }
    }
}
