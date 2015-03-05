using UnityEngine;
using System.Collections;

public class PadStand : MonoBehaviour {

    GameObject virtualPad;
	void Start () {
        virtualPad = GameObject.Find("Pad");
	}
	
	void Update () {
        transform.position = virtualPad.GetComponent<VirtualPad>().GetPadStandPos();
	}
}
