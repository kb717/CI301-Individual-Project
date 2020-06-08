using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)            //on collision with an object that is tagged enemy
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);                    //destroy the current game object, in this case, food
        }
    }

}
