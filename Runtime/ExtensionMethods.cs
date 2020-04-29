using System;
using System.Collections;
using UnityEngine;

namespace Doxel.Utility.ExtensionMethods {

	public static class ActionExtensionMethods {

		public static void Raise (this Action actionToCall) =>
			actionToCall?.Invoke ();

		public static void Raise<T> (this Action<T> actionToCall, T argument) =>
			actionToCall?.Invoke (argument);

		public static void Raise<T1, T2> (this Action<T1, T2> actionToCall, T1 argument1, T2 argument2) =>
			actionToCall?.Invoke (argument1, argument2);

		public static IEnumerator DelayedInvoke (this Action actionToInvoke, float duration) {
			yield return new WaitForSeconds (duration);
			actionToInvoke.Raise ();
		}

	}

}