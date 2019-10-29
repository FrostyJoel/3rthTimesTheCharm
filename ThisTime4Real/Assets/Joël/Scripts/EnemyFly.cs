using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public float maxHover;
    public float flyingSpeed;
    public RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,-transform.up,out hit, Mathf.Infinity))
        {
            float dis = Vector3.Distance(transform.position, hit.point);
            if (dis < maxHover)
            {
                Vector3 flyingPower = new Vector3(0, flyingSpeed, 0);
                GetComponent<Rigidbody>().velocity = flyingPower;
                transform.Translate(transform.up * Time.deltaTime * UIManager.gameSpeed);
            }
        }
    }
}
