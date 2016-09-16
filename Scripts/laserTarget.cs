using UnityEngine;
using System.Collections;

public class laserTarget : MonoBehaviour {

    public Transform origin;
    public Transform target;
    LineRenderer linerenderer;
	// Use this for initialization
	void Start () {
        linerenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        linerenderer.SetPosition(0, origin.position);
        linerenderer.SetPosition(1, target.position);
    }
}
