using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using Newtonsoft.Json;

public abstract class BaseDescriptor 
{
	[JsonProperty("id")]
	public string Id { get; private set; }

	[OnDeserialized()]
	public void OnDeserialized(StreamingContext context)
	{
		CheckIntegrity ();
	}

	public virtual void CheckIntegrity()
	{
	}
}
