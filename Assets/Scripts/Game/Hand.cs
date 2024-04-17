using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform mHandMesh;

    private void Update()
    {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bubble"))
        {
             Debug.Log("collision triggered not bubble");
            // var bubble = GameObject.FindWithTag("Bubble");
            // if (bubble != null){
            //     bubble.transform.localScale = Vector3.one;
            // }
            return;
        }
        Debug.Log("bubble triggered");
        // collision.gameObject.SetActive(false);
       // collision.gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
    }
}
