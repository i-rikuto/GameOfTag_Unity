using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Horizontal = Input.GetAxis("Horizontal");
        var Vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(Horizontal * Time.deltaTime, 0, Vertical * Time.deltaTime);
        transform.position = transform.position + velocity * Speed;
    }
}
