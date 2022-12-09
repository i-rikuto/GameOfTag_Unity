using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_Ray : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Front,RayEnd,RayError;
    public Material RayMaterial;
    [SerializeField] LineRenderer line;
    [SerializeField] JointCreate jointCreate;
    public float rotationSpeed = 1000.0f;

    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            Front.transform.LookAt(hit.point);
            //Debug.Log(hit.collider.gameObject.transform.position);
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            if (RayMaterial.color == Color.blue)
            {
                jointCreate.Conect(RayEnd);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            jointCreate.Conect_Clear();
        }

        float step = rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.RotateTowards(this.transform.rotation, Front.transform.rotation, step);
        this.transform.rotation = rotation;
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, RayEnd.transform.localPosition );
        RaycastHit _hit;
        if (Physics.Raycast(this.gameObject.transform.position, transform.forward,out _hit,1000)) {
            RayEnd.transform.position = _hit.point;
            RayMaterial.color = Color.blue;
        }
        else
        {
            RayEnd.transform.position = RayError.transform.position;
            RayMaterial.color = Color.red;
        }
        
        //target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, mouse.z));
        //transform.LookAt(target);
    }
}
