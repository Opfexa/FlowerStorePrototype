using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> emptyArea;
    [SerializeField]
    List<GameObject> cactusArea;
    public List<GameObject> cactusList;
    public List<GameObject> potList;
    private GameManager gameManager;
    public int emptyAreaNumber;
    public int emptyCactusAreaNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        potList= new List<GameObject>();
        cactusList = new List<GameObject>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        emptyAreaNumber = emptyArea.Count;
        emptyCactusAreaNumber = cactusArea.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddTable(GameObject pot)
    {
        if (emptyAreaNumber > 0)
        {
            potList.Add(pot);
            Replace();
            emptyAreaNumber--;
        }
    }
    public void AddCactus(GameObject cactus)
    {
        if(emptyCactusAreaNumber > 0)
        {
            cactusList.Add(cactus);
            CactusReplace();
            emptyCactusAreaNumber--;
        }
    }
    private void Replace()
    {
        for (int i = 0; i < potList.Count; i++)
        {
            potList[i].gameObject.transform.position = emptyArea[i%emptyArea.Count].gameObject.transform.position;
        }
    }
    private void CactusReplace()
    {
        for (int i = 0; i < cactusList.Count; i++)
        {
            cactusList[i].gameObject.transform.position = cactusArea[i%cactusArea.Count].gameObject.transform.position;
        }
    }
}
