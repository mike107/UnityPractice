using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour {

    //configuration parameter
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 11f;
    [SerializeField] float screenHeightInUnits = 11f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mousePosInUnits = Input.mousePosition.y / Screen.height * screenHeightInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(mousePosInUnits, minY, maxY);
        transform.position = paddlePos;
	}
}
