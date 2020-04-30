using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Database<TElement> : ScriptableObject, IEnumerable<TElement>
	where TElement : IIdentifiable {

	[SerializeField]
	private TElement[] elements;

	protected virtual IEnumerable<TElement> Elements {
		get => elements;
	}

	public TElement this[int id] {
		get {
			foreach (var element in elements)
				if (element.Id == id)
					return element;
			Debug.LogError ("Element with given id does not exist: " + id);
			return default;
		}
	}

	public TElement this[string name] {
		get {
			foreach (var element in elements)
				if (element.Name == name)
					return element;
			Debug.LogError ("Element with given title does not exist: " + name);
			return default;
		}
	}

	public bool QueryById (int id, ref TElement element) {
		bool querySuccessful = (element = Array.Find (elements, _element => _element.Id == id)) != null;
		element = element != null ? element : default;
		return querySuccessful;
	}

	public bool QueryByName (string name, ref TElement element) {
		bool querySuccessful = (element = Array.Find (elements, _element => _element.Name == name)) != null;
		element = element != null ? element : default;
		return querySuccessful;
	}

	public IEnumerator<TElement> GetEnumerator () =>
		Elements.GetEnumerator ();

	IEnumerator IEnumerable.GetEnumerator () =>
		GetEnumerator ();
	
}