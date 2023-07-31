using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private GameObject hitbox;
    public int coinscollected;
    public int health = 10;
    private int maxhealth = 100; 
    public int ammo;
    [SerializeField] private float attackduration;
    //this mean slot 1= keyt1, key1sprite or slot 2 = something
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
        

    public Text Cointext;
    public Image healthbar;

    [SerializeField]private Vector2 healthbaroriginalsize;
    public Sprite keysprite;
    public Sprite keydicksprite;
    public Image inventoryItemImage;
    public Sprite inventoryitemblank;

    //Singleton instantation
    private static NewPlayer instance;
    public static NewPlayer Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<NewPlayer>();
            return instance;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        healthbaroriginalsize = healthbar.rectTransform.sizeDelta;
        updateUI();

        
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed , 0);


        //if the player presses jump set velocity to a jump power value 
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            velocity.y = jumpPower;

        }

        //flip player
        if (targetVelocity.x < -.01)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (targetVelocity.x > .01)
        {
            transform.localScale = new Vector2(1, 1);
        }

        //click space to hit. referencing unity "fire1" 
        if(Input.GetButtonDown("Fire1"))
        {
          StartCoroutine(ActivateAttack());
        }

        if(health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1scene");
  
        }
        
    }

    public IEnumerator ActivateAttack()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(attackduration);
        hitbox.SetActive(false);

    }

    //new function - update ui elements 
    public void updateUI()
    {
        Cointext.text = coinscollected.ToString();

        //set health bar width to a percentage of its orginal value
        //healthbaroriginal.x * .(currenthealth/max health) 
        healthbar.rectTransform.sizeDelta = new Vector2(healthbaroriginalsize.x * ((float) health / (float) maxhealth),healthbar.rectTransform.sizeDelta.y);

        //healthbar witdth control
        //healthbar.rectransform.sizedelta.x / healthbar original size.x
        //healthbar.rectTransform.sizeDelta = new Vector2(100,healthbar.rectTransform.sizeDelta.y);


    }
    
    
    
    //function for inventory
    public void addinventoryitem(string inventoryname, Sprite image = null)
    {
        inventory.Add(inventoryname, image);
        //blank sprite should now swap with key sprite
        inventoryItemImage.sprite = inventory[inventoryname];
    }
    public void Removeinventoryitem(string inventoryname)
    {
        inventory.Remove(inventoryname);
        //blank sprite should now swap with key sprite
        inventoryItemImage.sprite = inventoryitemblank;
    }
}
