using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class OrderSorter : MonoBehaviour {

	private new Renderer renderer;
	private Canvas canvas;
	private SortingGroup sortingGroup;

	private void Awake () {
		renderer = GetComponent<Renderer> ();
		canvas = GetComponent<Canvas> ();
		sortingGroup = GetComponent<SortingGroup> ();
	}

	private void Update () {
		if (sortingGroup)
			sortingGroup.sortingOrder = (int) (transform.position.y * -10);
		else if (renderer)
			renderer.sortingOrder = (int) (transform.position.y * -10);
		else if (canvas)
			canvas.sortingOrder = (int) (transform.position.y * -10);
		else
			Debug.LogError ("No valid sortable component is attached to the gameobject");
	}

}