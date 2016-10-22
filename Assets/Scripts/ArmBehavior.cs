using UnityEngine;
using System.Collections;

public class ArmBehavior : MonoBehaviour {

    private float Radius = 3;
    public Vector3 Displacement;
    public Vector3 Displacement2;
    public GameObject PlayerBody;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Displacement = (gameObject.transform.position - PlayerBody.transform.position);
        
        if (Displacement.x >= Radius )
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - Displacement.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (Displacement.y >= Radius)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Displacement.y, gameObject.transform.position.z);
        }
        if (Displacement.z >= Radius)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - Displacement.z);
        }

    }
}
