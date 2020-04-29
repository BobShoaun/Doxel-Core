using UnityEngine;

public abstract class SemiSingletonMonoBehaviour<T> : MonoBehaviour where T : SemiSingletonMonoBehaviour<T> {

	public static T Instance { get; private set; }

	protected virtual void Awake () {
        if (Instance == null)
            Instance = this as T;
        else
        {
            Destroy(Instance);
            Instance = this as T;
            Debug.LogWarning("Multiple SemiSingletonMonoBehaviours of the same type found in the scene. Destroying extra. Type: " + name);
        }
	}

}