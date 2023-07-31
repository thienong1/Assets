using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    [SerializeField] private string requiredinventoryitemstring;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            //inventory.containskey1

            if (NewPlayer.Instance.inventory.ContainsKey(requiredinventoryitemstring)) 

            {
                Destroy(gameObject);
            }

        }

    }
}
