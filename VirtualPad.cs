using UnityEngine;
using System.Collections;

public class VirtualPad : Mover {

    private bool touchTrigger = false;
    private Vector3 standardPos;
	public static Vector3 axis, direction;
    public Vector3 GetPadStandPos () { return standardPos; }

	void Update () {
        transform.position = pos;
        float r = (50.0f*1.8f)*1.25f;
        axis = direction = Vector3.zero;
        //if (Input.GetMouseButtonDown (0) && Length(pos - Input.mousePosition) < r)
        if (Input.GetMouseButtonDown (0))
        {
            touchTrigger = true;
            standardPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y+0.01f, 0);
        }
        else if (Input.GetMouseButtonUp (0))
        {
            touchTrigger = false;
        }
        if (touchTrigger)
        {
            pos = Input.mousePosition;
            Vector3 leng = pos - standardPos;
            float l = Length (leng);
            if (r < l) { pos = standardPos + leng * (r / l); }
            axis = (Normalize (pos - standardPos) / r) * Mathf.Min (r, l);
            direction = Normalize (pos - standardPos);
        }
        else
        {
            //pos = Vector3.Lerp (pos, standardPos, 0.2f);
            pos = standardPos = new Vector3(Screen.width * 10, Screen.height * 10, 0);
        }
    }
}