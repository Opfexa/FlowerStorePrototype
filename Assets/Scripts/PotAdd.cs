using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotAdd : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void AddPot()
    {
        gameManager.AddPot();
    }
    public void CactusAdd()
    {
        gameManager.AddCactus();
    }
}
