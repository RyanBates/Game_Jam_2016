using UnityEngine;
using System.Collections;

public class ArmBehavior : MonoBehaviour {

    private float Radius = 2;
    public Vector3 Displacement;
    float speed = 30.0f;
    bool wkey = false;
    bool skey = false;
    bool qkey = false;
    bool ekey = false;
    bool dkey = false;
    bool akey = false;
    public GameObject PlayerBody;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Displacement = (gameObject.transform.position - PlayerBody.transform.position);
        wkey = false;
        skey = false;
        qkey = false;
        ekey = false;
        dkey = false;
        akey = false;

        Vector3 direction = Vector3.zero;
        Quaternion rotation = new Quaternion(0,0,0,0);

        if (Input.GetAxis("Vertical") > 0 && transform.position.z < Radius + PlayerBody.transform.position.z+2)
        {
            wkey = true;
        }

        if (Input.GetAxis("Vertical") < 0 && transform.position.z > -Radius + PlayerBody.transform.position.z-2 )
        {
            skey = true;
        }
        if (Input.GetAxis("UP") > 0 && transform.position.y < Radius + PlayerBody.transform.position.y)
        {
            qkey = true;
        }
        if (Input.GetAxis("UP") < 0 && transform.position.y > -Radius + PlayerBody.transform.position.y)
        {
            ekey = true;
        }

        if (Input.GetAxis("Horizontal") > 0 && transform.position.x < Radius + PlayerBody.transform.position.x-5)
        {
            dkey = true;
        }

        if (Input.GetAxis("Horizontal") < 0 && transform.position.x > -Radius + PlayerBody.transform.position.x-10)
        {
            akey = true;
        }
        if (wkey == true || skey == true)
        {
            direction += Vector3.forward * (Input.GetAxis("Vertical") * speed) * Time.deltaTime;
        }
        if (qkey == true || ekey == true)
        {
            direction += Vector3.up * ((Input.GetAxis("UP") * -speed) * Time.deltaTime);
        }

        if (dkey == true || akey == true)
        {
            direction += Vector3.right * (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;
        }
        transform.position += direction * speed * Time.deltaTime;
        
        //if (Displacement.x >= Radius )
        //{
        //    gameObject.transform.position = new Vector3(PlayerBody.transform.position.x + Displacement.x, PlayerBody.transform.position.y, PlayerBody.transform.position.z);
        //}
        //if (Displacement.y >= Radius)
        //{
        //    gameObject.transform.position = new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y + Displacement.y, PlayerBody.transform.position.z);
        //}
        //if (Displacement.z >= Radius)
        //{
        //    gameObject.transform.position = new Vector3(PlayerBody.transform.position.x, PlayerBody.transform.position.y, PlayerBody.transform.position.z + Displacement.z);
        //}

    }
}
