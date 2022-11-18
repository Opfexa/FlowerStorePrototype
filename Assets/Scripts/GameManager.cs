using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int potPiece;
    [SerializeField]
    private GameObject pot;
    [SerializeField]
    private int cactusPiece;
    [SerializeField]
    private GameObject cactus;
    [SerializeField]
    private TextMeshProUGUI flowerCountText;
    private TableManager tableManager;
    private PotManager potManager;
    public int magicPiece;
    public int flowerCount;
    // Start is called before the first frame update
    void Start()
    {
        tableManager = GameObject.FindObjectOfType<TableManager>();
        TextMeshProUGUI flowerCountText = GetComponent<TextMeshProUGUI>();
        potManager = GetComponent<PotManager>();
        flowerCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        flowerCountText.text = "Topladığın bitki sayısı: " + flowerCount;
        
    }
    public void AddPot()
    {
        if (tableManager.emptyAreaNumber > 0 && potPiece > 0)
        {
            tableManager.AddTable(pot);
            Instantiate(pot);
            potPiece--;
        }
        else
        {
            Debug.Log("Alan ya da saksı kalmadı.");
        }
    }
    public void AddCactus()
    {
        if (tableManager.emptyCactusAreaNumber > 0 && cactusPiece > 0)
        {
            tableManager.AddCactus(cactus);
            Instantiate(cactus);
            cactusPiece--;
        }
    }
    
}
