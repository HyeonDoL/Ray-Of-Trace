using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public abstract class GenericTable<T> where T : BaseDescriptor
{
	private Dictionary<string, T> dictionary;

	public GenericTable(string path)
	{
		var descriptors = GetDescriptors (path);	
		CreateDictionary (descriptors);
	}

	public List<T> GetDescriptors(string path)
	{
		//TODO try-catch
		var textAsset = Resources.Load<TextAsset> (path);
		var json = textAsset.text;
		return JsonConvert.DeserializeObject<List<T>> (json);
	}

	public void CreateDictionary(List<T> descriptors)
	{
		dictionary = new Dictionary<string, T> ();
		foreach (var descriptor in descriptors) 
		{
			dictionary.Add (descriptor.Id, descriptor);
		}
	}

	public T Find(string id, bool showLog = true)
	{
		T desc = null;
		if (dictionary.TryGetValue (id, out desc)) 
		{
			return desc;
		} 
		else 
		{
			if (showLog)
				Debug.LogErrorFormat ("[{0}]Descriptor not found - {1}", this.GetType ().Name, id);
			
			return null;
		}
	}

	public IEnumerable<T> All()
	{
		return dictionary.Values;
	}
}