using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

public class CharacterDescriptor : BaseDescriptor
{
	public class SkillGroupDescriptor
	{
		[JsonProperty("skillId")]
		public string SkillId { get; private set; }
	}

	[JsonProperty("name")]
	public string Name {get; private set;}

	[JsonProperty("class")]
	public string Class {get; private set;}

	[JsonProperty("SkillGroup")]
	public ReadOnlyCollection<SkillGroupDescriptor> SkillGroups {get; private set;}
}