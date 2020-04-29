using UnityEngine;

public abstract class SemiSingletonMonoBehaviour<T> : MonoBehaviour where T : SemiSingletonMonoBehaviour<T> {

	public static T Instance { get; private set; }

	protected virtual void Awake () {
		if (Instance) {
			Destroy (Instance);
			Debug.LogWarning ($"Multiple SemiSingletonMonoBehaviours of type {typeof (T)} found in the scene. Destroying extra.");
		}
		Instance = this as T;
	}

}