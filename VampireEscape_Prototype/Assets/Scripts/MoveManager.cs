using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public static MoveManager instance;

    public Text moveCounterText;

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
        maxMoves = 20;

        moveCounterText.text = "Move " + currentMoves.ToString() + "/" + maxMoves.ToString();
    }

    public void AddMove()
    {
        currentMoves++;
        moveCounterText.text = "Move " + currentMoves.ToString() + "/" + maxMoves.ToString();
    }
}
