using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointCreate : MonoBehaviour
{
    
    public GameObject JointObject,JointPoint;
    public float JointSize;
    List<GameObject> J;
    public bool change = false;
    //Line‚Ì•`‰æŠÖŒW
    [SerializeField]
    private LineRenderer line = null;

    [SerializeField]
    private Transform pivot = null;
    void Start()
    {
        J = new List<GameObject>();
        
        //J[J.Count - 1].GetComponent<HingeJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            Conect();
            change = false;
        }
        if(J.Count == 0) { return; }
        this.line.SetPosition(0,gameObject.transform.position);

        for (int j = 1; j <= J.Count; j++)
        {
            this.line.SetPosition(j, J[j - 1].transform.position);
        }

        //Vector3 vec = (JointPoint.transform.position - transform.position).normalized;
    }

    public void Conect()
    {
        line.positionCount = 0;
        for (int k = 0;k < J.Count; k++)
        {
            Destroy(J[k]);
        }

        J.Clear();
        var Distance = Vector3.Distance(transform.position, JointPoint.transform.position);
        var JointCount = (int)(Distance / JointSize);

        Debug.Log(JointCount);

        Distance = 1f;
        var Minus = 1f / JointCount;
        var First = false;
        Debug.Log(Minus);
        Debug.Log(Distance);
        do
        {
            if (First)
            {
                J.Add(Instantiate(JointObject, Vector3.Lerp(JointPoint.transform.position, transform.position, Distance), transform.rotation));
            }
            First = true;
            Distance -= Minus;
            Debug.Log(Distance);
        } while (Distance > 0);
        gameObject.AddComponent<HingeJoint>().connectedBody = J[0].GetComponent<Rigidbody>();
        for (int i = 0; i < J.Count - 1; i++)
        {
            J[i].GetComponent<HingeJoint>().connectedBody = J[i + 1].GetComponent<Rigidbody>();
        }
        J[J.Count - 1].GetComponent<HingeJoint>().connectedBody = JointPoint.GetComponent<Rigidbody>();
        line.positionCount = J.Count + 1;

    }
}
