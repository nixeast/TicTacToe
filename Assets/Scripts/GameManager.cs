using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public UIManager MyUIManager;
    public GameObject[] btnTicTacToe;
    int nCurrentPlayerNumber;
    TMP_Text test_tmpText;
    int[] arrGameMap = new int[9];
    bool bIsMatched;
    int nWinnerNumber;
    int nMarkingCount;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game Start!");

        nCurrentPlayerNumber = 1;
        MyUIManager.UpdateCurrentPlayerNumberOnDisplay(nCurrentPlayerNumber);

        Debug.Log("CurrentPlayerNumber: " + nCurrentPlayerNumber);

        for (int i = 0; i < 9; i++)
        {
            arrGameMap[i] = 0;
        }

        bIsMatched = false;
        nWinnerNumber = 0;
        nMarkingCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameDraw();
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
            MyUIManager.UpdateCurrentPlayerNumberOnDisplay(nCurrentPlayerNumber);
            nMarkingCount++;
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
                //Debug.Log("Matched!");
                bIsMatched = true;
                nWinnerNumber = arrGameMap[nSlotNumber];
                ShowWinner();
                MyUIManager.ShowGameResult(nWinnerNumber);
                StopGmaePlay();
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
                //Debug.Log("Matched!");
                bIsMatched = true;
                nWinnerNumber = arrGameMap[nSlotNumber];
                ShowWinner();
                MyUIManager.ShowGameResult(nWinnerNumber);
                StopGmaePlay();
            }

            nColumnNumber++;
            nSlotNumber = nColumnNumber;
        }
    }

    void CheckDiagonalSlotMatch()
    {
        int nFirstSlotNumber;
        int nSecondSlotNumber;
        int nThirdSlotNumber;

        nFirstSlotNumber = 0;
        nSecondSlotNumber = 4;
        nThirdSlotNumber = 8;

        if (arrGameMap[nFirstSlotNumber] != 0 && arrGameMap[nFirstSlotNumber] == arrGameMap[nSecondSlotNumber] && arrGameMap[nFirstSlotNumber] == arrGameMap[nThirdSlotNumber])
        {
            //Debug.Log("Matched!");
            bIsMatched = true;
            nWinnerNumber = arrGameMap[nFirstSlotNumber];
            ShowWinner();
            MyUIManager.ShowGameResult(nWinnerNumber);
            StopGmaePlay();
        }

        nFirstSlotNumber = 2;
        nSecondSlotNumber = 4;
        nThirdSlotNumber = 6;

        if (arrGameMap[nFirstSlotNumber] != 0 && arrGameMap[nFirstSlotNumber] == arrGameMap[nSecondSlotNumber] && arrGameMap[nFirstSlotNumber] == arrGameMap[nThirdSlotNumber])
        {
            //Debug.Log("Matched!");
            bIsMatched = true;
            nWinnerNumber = arrGameMap[nFirstSlotNumber];
            ShowWinner();
            MyUIManager.ShowGameResult(nWinnerNumber);
            StopGmaePlay();
        }
    }

    void ShowWinner()
    {
        if(bIsMatched == true)
        {
            Debug.Log("Winner is " + nWinnerNumber + "Player");
        }
    }

    void StopGmaePlay()
    {
        int nButtonNumber = 0;

        while(nButtonNumber <= 8)
        {
            btnTicTacToe[nButtonNumber].GetComponent<Button>().enabled = false;
            
            nButtonNumber++;
        }

    }

    void CheckGameDraw()
    {
        if (nMarkingCount == 9 && nWinnerNumber == 0)
        {
            StopGmaePlay();
            MyUIManager.ShowGameResult(0);
        }
    }
}
