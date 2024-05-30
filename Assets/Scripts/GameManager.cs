using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public UIManager MyUIManager;
    public GameObject[] btnTicTacToe;
    GameObject btnSelectedButton;
    int nCurrentPlayerNumber;
    TMP_Text test_tmpText;
    int[] arrGameMap = new int[9];
    bool bIsMatched;
    int nWinnerNumber;
    int nMarkingCount;
    int nMapSize;

    // Start is called before the first frame update
    void Start()
    {
        InitMap();
        SetUpCurrentPlayerNumber();
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
            btnSelectedButton = btnTicTacToe[nBtnNumber].transform.GetChild(0).gameObject;
            btnSelectedButton.GetComponent<TMP_Text>().text = nCurrentPlayerNumber.ToString();
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
        int nSlotNumber1;
        int nSlotNumber2;
        int nSlotNumber3;

        nRowNumber = 0;
        nSlotNumber1 = 0;
        nSlotNumber2 = nSlotNumber1 + 1;
        nSlotNumber3 = nSlotNumber1 + 2;
        while (nRowNumber <= 2)
        {
            if (arrGameMap[nSlotNumber1] != 0 && arrGameMap[nSlotNumber1] == arrGameMap[nSlotNumber2] && arrGameMap[nSlotNumber1] == arrGameMap[nSlotNumber3])
            {
                bIsMatched = true;
                nWinnerNumber = arrGameMap[nSlotNumber1];
                ShowWinner();
                MyUIManager.ShowGameResult(nWinnerNumber);
                StopGmaePlay();
            }

            nRowNumber++;
            nSlotNumber1 = nRowNumber * 3;
            nSlotNumber2 = nSlotNumber1 + 1;
            nSlotNumber3 = nSlotNumber1 + 2;
        }
    }
    void CheckColumnSlotMatch()
    {
        int nColumnNumber;
        int nSlotNumber1;
        int nSlotNumber2;
        int nSlotNumber3;

        nColumnNumber = 0;
        nSlotNumber1 = 0;
        nSlotNumber2 = nSlotNumber1 + 3;
        nSlotNumber3 = nSlotNumber1 + 6;
        while (nColumnNumber <= 2)
        {
            if (arrGameMap[nSlotNumber1] != 0 && arrGameMap[nSlotNumber1] == arrGameMap[nSlotNumber2] && arrGameMap[nSlotNumber1] == arrGameMap[nSlotNumber3])
            {
                bIsMatched = true;
                nWinnerNumber = arrGameMap[nSlotNumber1];
                ShowWinner();
                MyUIManager.ShowGameResult(nWinnerNumber);
                StopGmaePlay();
            }

            nColumnNumber++;
            nSlotNumber1 = nColumnNumber;
            nSlotNumber2 = nSlotNumber1 + 3;
            nSlotNumber3 = nSlotNumber1 + 6;
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

    void SetUpCurrentPlayerNumber()
    {
        nCurrentPlayerNumber = 1;
        MyUIManager.UpdateCurrentPlayerNumberOnDisplay(nCurrentPlayerNumber);
    }

    void InitMap()
    {
        int nCount;

        nCount = 0;
        while (nCount < nMapSize)
        {
            arrGameMap[nCount] = 0;
        }
    }
}
