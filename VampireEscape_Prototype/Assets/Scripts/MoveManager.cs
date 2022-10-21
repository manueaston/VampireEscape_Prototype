using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public static MoveManager instance;

    public Text moveCounterText;

    public Image bloodMeterImage;
    public Sprite[] bloodMeter;
    // array contains all sprites of blood meter

    public int currentMoves;
    public int maxMoves;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMoves = 0;

        moveCounterText.text = "Move " + currentMoves.ToString() + "/" + maxMoves.ToString();
        bloodMeterImage.sprite = bloodMeter[0];
    }

    public void AddMove()
    {
        currentMoves++;
        moveCounterText.text = "Move " + currentMoves.ToString() + "/" + maxMoves.ToString();

        // Calculates which blood meter image to use based on current move percentage out of max moves
        int bloodMeterIndex = (9 * currentMoves) / maxMoves;
        bloodMeterImage.sprite = bloodMeter[bloodMeterIndex];
    }

    //public void Reset()
    //{
    //    currentMoves = 0;
    //    moveCounterText.text = "Move " + currentMoves.ToString() + "/" + maxMoves.ToString();
    //    bloodMeterImage.sprite = bloodMeter[0];
    //}
}
