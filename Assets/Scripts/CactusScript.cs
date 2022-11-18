using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    [SerializeField]
    private GameObject magic;
    private Animator animator;
    private GameManager gameManager;
    private TableManager tableManager;
    Vector3 place;
    private bool grown;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<PotManager>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        tableManager = GameObject.FindObjectOfType<TableManager>();
        place = transform.position;
        SmallCactus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() 
    {
        if(grown == true)
        {
            Destroy(gameObject);
            gameManager.flowerCount++;
            tableManager.emptyAreaNumber++;
        }
    }
    void SmallCactus()
    {
        StartCoroutine(Grow());
    }
    void MediumCactus()
    {
        animator.SetBool("medium",true);
        StartCoroutine(Grown());
    }
    void BigCactus()
    {
        animator.SetBool("big",true);
        grown = true;
    }
    IEnumerator Grow()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(magic,new Vector3(place.x, place.y + 1f,place.z),Quaternion.identity);
        MediumCactus();
    }
    IEnumerator Grown()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(magic,new Vector3(place.x, place.y + 1f,place.z),Quaternion.identity);
        BigCactus();
    }
}
