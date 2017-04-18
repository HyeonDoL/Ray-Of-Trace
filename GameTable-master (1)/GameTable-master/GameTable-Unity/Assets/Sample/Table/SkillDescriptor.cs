using System;
using System.Linq;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

public class SkillDescriptor : BaseDescriptor
{
	public class SkillEffectDescriptor : BaseDescriptor
	{
		[JsonProperty("type")]
		public string Type {get; private set;}

		[JsonProperty("value")]
		public int Value {get; private set;}

		[JsonProperty("valueRate")]
		public float ValueRate {get; private set;}

		[JsonProperty("description")]
		public string Description { get; private set; }

		[JsonProperty("SkillEffectUpgrade")]
		public ReadOnlyCollection<SkillEffectUpgradeDescriptor> SkillEffectUpgrades {get; private set;}

		public SkillEffectUpgradeDescriptor GetUpgradeDesc(int level)
		{
			return SkillEffectUpgrades.FirstOrDefault (u => u.Level == level);
		}
	}

	public class SkillEffectUpgradeDescriptor
	{
		[JsonProperty("level")]
		public int Level {get; private set;}

		[JsonProperty("addValue")]
		public int AddValue {get; private set;}

		[JsonProperty("addValueRate")]
		public float AddValueRate {get; private set;}
	}

	[JsonProperty("name")]
	public string Name {get; private set;}

	[JsonProperty("mp")]
	public int MP {get; private set;}

	[JsonProperty("isTargeting")]
	public bool IsTargeting {get; private set;}

	[JsonProperty("SkillEffect")]
	public ReadOnlyCollection<SkillEffectDescriptor> SkillEffects {get; private set;}
}
