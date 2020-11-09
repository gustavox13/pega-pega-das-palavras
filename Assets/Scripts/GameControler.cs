using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pairs = new GameObject[6];

    private int currentTurn = 0;


    private void Start()
    {
        StartTurn();
    }



    private void StartTurn()
    {
        pairs[currentTurn].GetComponent<PairClass>().playCards();
    }

    public void CheckAnswer(int answer)
    {
        if(pairs[currentTurn].GetComponent<PairClass>().correctSide == answer) // RESPOSTA CORRETA
        {
            
            StartCoroutine(CorrectAnswer());
        }
        else // RESPOSTA ERRADA
        {
            Debug.Log("Resposta errada");
        }

        
    }

     IEnumerator CorrectAnswer()
    {
       
        pairs[currentTurn].GetComponent<PairClass>().DisableColliders(); //DESABILITA BOTAO IMEDIATAMENTE

        pairs[currentTurn].GetComponent<PairClass>().ExitCards(); //animacao de vitoria


        yield return new WaitForSeconds(4f);

        EndTurn();
    }

    private void EndTurn()
    {
        if(currentTurn < 5) // VAI PRO PROX DESAFIO
        {
            currentTurn++;
            StartTurn();
        }
        else
        {
            Debug.Log("fim de jogo");
        }
    }
}
