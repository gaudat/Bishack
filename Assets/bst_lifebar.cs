using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bst_lifebar : MonoBehaviour {

    private GameObject[] lifeBar = new GameObject[100]; // 100 percents
    private GameObject lifeBarCursor;
    public int lifeBarValue;


	// Use this for initialization
	void Start () {
        lifeBarCursor = transform.FindChild("lifebar_cursor_pivot").gameObject;
        if (lifeBarCursor == null) Debug.LogAssertion("lifebar_cursor_pivot == null", this);
        lifeBarCursor.SetActive(false);
        GameObject fill_parent = transform.FindChild("lifebar_fill_pivot").gameObject;
        if (fill_parent == null) Debug.LogAssertion("lifebar_fill_pivot == null", this);
        fill_parent.SetActive(false);
		for (int i=0; i<100; i++)
        {
            lifeBar[i] = Instantiate(fill_parent);
            lifeBar[i].transform.Rotate(new Vector3(0, 0, -i * 360f / 100 - 1.8f));
            lifeBar[i].SetActive(false);
        }

        lifeBarCursor.transform.localEulerAngles = new Vector3(0, 0, 0);
        lifeBarCursor.SetActive(true);
        
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeBarValue < 0 || lifeBarValue > 100) Debug.LogError("lifeBarValue out of range", this);
        else
        {
            for (int i=0; i<lifeBarValue; i++)
            {
                lifeBar[i].SetActive(true);
            }
            for (int i=lifeBarValue; i< 100; i++)
            {
                lifeBar[i].SetActive(false);
            }
            lifeBarCursor.transform.localEulerAngles = new Vector3(0, 0, -lifeBarValue * 360f / 100);
        }
	}
}
