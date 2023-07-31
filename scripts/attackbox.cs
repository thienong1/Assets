using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackbox : MonoBehaviour
{
    [SerializeField] private int attackdamage =10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        //touching enemy hurt enemy
        if (col.gameObject.GetComponent<enemy>())
        {
            col.gameObject.GetComponent<enemy>().health -= attackdamage;

        }
    }
}
