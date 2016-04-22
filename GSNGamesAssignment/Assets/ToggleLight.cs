using UnityEngine;
using System.Collections;

public class ToggleLight : MonoBehaviour {

    private bool isLightOn;
    public Material onMaterial;
    public Material offMaterial;

	// Use this for initialization
	void Start () {
        isLightOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLightOn)
        {
            this.GetComponent<MeshRenderer>().material = onMaterial;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = offMaterial;
        }
	}

    public void SwitchLight()
    {
        if (isLightOn) { isLightOn = false; }
        else { isLightOn = true; }
    }
}
