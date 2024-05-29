using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    
    public GameObject[] btnTicTacToe;
    int nCurrentPlayerNumber;
    TMP_Text test_tmpText;
    int[] arrGameMap = new int[9];
    bool bIsMatched;
    int nWinnerNumber;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game Start!");

        //string strBtnName = btnTicTacToe[0].name;

        nCurrentPlayerNumber = 1;

        Debug.Log("CurrentPlayerNumber: " + nCurrentPlayerNumber);

        for (int i = 0; i < 9; i++)
        {
            arrGameMap[i] = 0;
        }

        for (int i = 0; i < 9; i++)
        {
            //Debug.Log(arrGameMap[i]);
        }
        bIsMatched = false;
        nWinnerNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestMessage(int nBtnNumber)
    {
        if(arrGameMap[nBtnNumber] == 0)
        {
            string tmp = btnTicTacToe[nBtnNumber].transform.GetChild(0).name;


            GameObject testGameObject = btnTicTacToe[nBtnNumber].transform.GetChild(0).gameObject;
            testGameObject.GetComponent<TMP_Text>().text = nCurrentPlayerNumber.ToString();
            arrGameMap[nBtnNumber] = nCurrentPlayerNumber;

            if (nCurrentPlayerNumber == 1)
            {
                nCurrentPlayerNumber = 2;
            }
            else if (nCurrentPlayerNumber == 2)
            {
                nCurrentPlayerNumber = 1;
            }

            CheckRowSlotMatch();
            CheckColumnSlotMatch();
            CheckDiagonalSlotMatch();
        }
        

    }

    void CheckRowSlotMatch()
    {
        int nRowNumber;
        int nSlotNumber;
       
        nRowNumber = 0;
        nSlotNumber = 0;
        
        while (nRowNumber <= 2)
        {
            if (arrGameMap[nSlotNumber] != 0 && arrGameMap[nSlotNumber] == arrGameMap[nSlotNumber + 1] && arrGameMap[nSlotNumber] == arrGameMap[nSlotNumber + 2])
            {
                Debug.Log("Matched!");
                bIsMatched = true;
                nWinnerNumber = arrGameMap[nSlotNumber];
                ShowWinner();
            }

            nRowNumber++;
            nSlotNumber = nRowNumber * 3;
        }
    }
    void CheckColumnSlotMatch()
    {
        int nColumnNumber;
        int nSlotNumber;

        nColumnNumber = 0;
        nSlotNumber = 0;

        while (nColumnNumber <= 2)
        {
            if (arrGameMap[nSlotNumber] != 0 && arrGameMap[nSlotNumber] == arrGameMap[nSlotNumber + 3] && arrGameMap[nSlotNumber] == arrGameMap[nSlotNumber + 6])
            {
                Debug.Log("Matched!");
                bIsMatched = true;
                nWinnerNumber = arrGameMap[nSlotNumber];
                ShowWinner();
            }

            nColumnNumber++;
            nSlotNumber = nColumnNumber;
        }
    }

    void CheckDiagonalSlotMatch()
    {
        if (arrGameMap[0] != 0 && arrGameMap[0] == arrGameMap[4] && arrGameMap[0] == arrGameMap[8])
        {
            Debug.Log("Matched!");
            bIsMatched = true;
            nWinnerNumber = arrGameMap[0];
            ShowWinner();
        }

        if (arrGameMap[2] != 0 && arrGameMap[2] == arrGameMap[4] && arrGameMap[2] == arrGameMap[6])
        {
            Debug.Log("Matched!");
            bIsMatched = true;
            nWinnerNumber = arrGameMap[2];
            ShowWinner();
        }
    }

    void ShowWinner()
    {
        if(bIsMatched == true)
        {
            Debug.Log("Winner is " + nWinnerNumber + "Player");
        }
    }
}
