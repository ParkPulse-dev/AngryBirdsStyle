using UnityEngine;
using System.Collections;

public class DestoryOnTrigger : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D col)
    {
        // Destory game objects if collide borders
        string tag = col.gameObject.tag;
        if (tag == "pig" || tag == "brick")
        {
            Destroy(col.gameObject);
        }
    }
}
