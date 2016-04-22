using UnityEngine;
using System.Collections;

public class ToggleLight : MonoBehaviour {

    public bool isLightOn;
    public Material onMaterial;
    public Material offMaterial;

	// Use this for initialization
	void Start () {
        isLightOn = false;
        this.GetComponent<MeshRenderer>().material = offMaterial;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void SwitchLight()
    {
        if (isLightOn)
        {
            this.GetComponent<MeshRenderer>().material = offMaterial;
            isLightOn = false;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = onMaterial;
            isLightOn = true;
        }
    }
}
