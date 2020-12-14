using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaCollider : MonoBehaviour
{
    List<Bacteria> bacterias = new List<Bacteria>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bacterias.Count);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bacteria")
        {
            Debug.Log("Add " + collision.gameObject.GetComponent<Bacteria>());
            bacterias.Add(collision.gameObject.GetComponent<Bacteria>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bacteria")
        {
            Debug.Log("Remove " + collision.gameObject.GetComponent<Bacteria>());
            bacterias.Remove(collision.gameObject.GetComponent<Bacteria>());
        }
    }

}
