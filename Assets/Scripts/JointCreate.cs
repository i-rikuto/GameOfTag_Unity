using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject JointObject,JointPoint;
    public float JointSize;
    List<GameObject> J;
    void Start()
    {
        J = new List<GameObject>();
        var Distance = Vector3.Distance(transform.position, JointPoint.transform.position);
        var JointCount = (int)(Distance / JointSize);
        
        Debug.Log(JointCount);

        Distance = 1f;
        var Minus = 1f / JointCount;
        Debug.Log(Minus);
        Debug.Log(Distance);
        do
        {
            var Obj = Instantiate(JointObject, Vector3.Lerp(JointPoint.transform.position, transform.position, Distance), transform.rotation);
            J.Add(Obj);
            Distance -= Minus;
            Debug.Log(Distance);
        } while (Distance > 0);
        for(int i = J.Count - 1; i > 0; i--)
        {
            J[i].GetComponent<HingeJoint>().connectedBody = J[i - 1].GetComponent<Rigidbody>();
        }

        J.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = (JointPoint.transform.position - transform.position).normalized;
    }

    public void Conect(Transform Point)
    {
        var Distance = Vector3.Distance(transform.position, Point.position);

    }
}
