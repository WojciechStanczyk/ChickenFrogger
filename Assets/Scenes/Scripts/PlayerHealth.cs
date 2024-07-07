using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }
  // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
   
            if (collision.gameObject.CompareTag("Car"))
            {
                Debug.Log("*** HIT ***");
                HealthBar.currentHealth = HealthBar.currentHealth - 1;
             
                if (HealthBar.currentHealth == 0)
                {
                    //    SceneManager.LoadScene("Game_Over");
                }
            }
        
           
      }


        
    }

   
    


