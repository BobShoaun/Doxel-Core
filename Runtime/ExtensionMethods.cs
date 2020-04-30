using System;
using System.Collections;
using UnityEngine;

namespace Doxel.Utility.ExtensionMethods {

	public static class ActionExtensionMethods {

		public static void Raise (this Action action) =>
			action?.Invoke ();

		public static void Raise<T> (this Action<T> action, T argument) =>
			action?.Invoke (argument);

		public static void Raise<T1, T2> (this Action<T1, T2> action, T1 argument1, T2 argument2) =>
			action?.Invoke (argument1, argument2);

		public static IEnumerator DelayedInvoke (this Action action, float duration) {
			yield return new WaitForSeconds (duration);
			action.Raise ();
		}

	}

	public static class GameObjectExtensionMethods {

		public static GameObject GetGameObjectInParent (this GameObject gameObject, string name, bool includeInactive = false) =>
			Array.Find (gameObject.GetComponentsInParent<Transform> (includeInactive), transform => transform.name == name).gameObject;

		public static GameObject GetGameObjectInChildren (this GameObject gameObject, string name, bool includeInactive = false) =>
			Array.Find (gameObject.GetComponentsInChildren<Transform> (includeInactive), transform => transform.name == name).gameObject;

	}

	public static class RandomExtensionMethods {

		public static double NextDouble (this System.Random random, double minimum, double maximum) =>
			random.NextDouble () * (maximum - minimum) + minimum;

		public static float NextSingle (this System.Random random, float minimum, float maximum) =>
			(float) random.NextDouble (minimum, maximum);

	}

}