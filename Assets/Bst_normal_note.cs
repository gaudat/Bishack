using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bst_normal_note : MonoBehaviour {
    public int noteDir; // 0 = top, going clockwise
    public double hitTime; // When it takes
    public double speedMultiplier;

    private float hitDistance = 5.57f; // Where the hit line is, radius from center of playfield
    private float oneCircleDistance = (16.85f - 5.57f) * 2; // How far it takes for the note to rotate one circle
    private GameObject spinner;
	
    // Use this for initialization
	void Start () {
        spinner = transform.FindChild("note_front").gameObject;
        if (spinner == null) Debug.LogAssertion("note_front == null", this);
	}
	
	// Update is called once per frame
	void Update () {
        float noteDirAngle = -noteDir * 45 + 90;
        transform.localEulerAngles = new Vector3(0, 0, noteDirAngle);
        //transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * noteDirAngle), Mathf.Sin(Mathf.Deg2Rad * noteDirAngle), 0);
        float distanceFromHit = ((Vector2)transform.position).magnitude - hitDistance;
        if (distanceFromHit  > 0)
            spinner.transform.localEulerAngles = new Vector3(0, 0, -distanceFromHit / oneCircleDistance * 360f);
    }
}
