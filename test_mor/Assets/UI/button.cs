using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class button : MonoBehaviour {
    public GameObject pivotPoint;

	void Start () {
        Vector3 pos = pivotPoint.transform.position;
        Vector3 screen = Camera.main.WorldToScreenPoint(pos);
        Debug.Log("x = " + screen.x + "y = " + screen.y);
	}
	
	void Update () {
        Vector3 pos = Camera.main.WorldToScreenPoint(pivotPoint.transform.position);
	    transform.position = pos;
        Vector3 min = Camera.main.WorldToScreenPoint(pivotPoint.renderer.bounds.min);
        Vector3 max = Camera.main.WorldToScreenPoint(pivotPoint.renderer.bounds.max);
        RectTransform rectTranform = GetComponent<RectTransform>();
        rectTranform.sizeDelta = new Vector2(max.x - min.x, max.y - min.y);
	}
}
