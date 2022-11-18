using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotManager : MonoBehaviour
{
    public int magicCount;
    [SerializeField]
    private GameObject Cactus;
    [SerializeField]
    private Sprite finalForm;
    [SerializeField]
    private GameManager gameManager;
    private TableManager tableManager;
    [SerializeField]
    private GameObject magic;
    private Vector3 place;
    public bool grown;
    public int clickCount;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        tableManager = GameObject.FindObjectOfType<TableManager>();
        magicCount = 0;
        place = transform.position;
        grown= false;
        clickCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        clickCount++;
        if (gameManager.magicPiece > 0 && magicCount < 2 && !grown)
        {
            magicCount++;
        }
        if (magicCount == 2 && !grown && clickCount == 2)
        {
            grown = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = finalForm;
            Instantiate(magic,new Vector3(place.x, place.y + 2.5f,place.z),Quaternion.identity);
        }
        if (magicCount >= 2 && grown && clickCount >= 3)
        {
            clickCount = 0;
            StartCoroutine(DestroyDelay());
        }
        
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.2f);
        gameManager.flowerCount++;
        tableManager.emptyAreaNumber++;
        Destroy(gameObject);
    }
}
