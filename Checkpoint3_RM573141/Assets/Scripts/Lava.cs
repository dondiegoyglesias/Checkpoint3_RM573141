using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour
{
   

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
        

}
