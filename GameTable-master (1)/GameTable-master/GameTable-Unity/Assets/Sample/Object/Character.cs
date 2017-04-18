using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
	[SerializeField]
	private string id;
	[SerializeField]
	private int skillLevel;

	private CharacterDescriptor desc;

	private List<Skill> skills;

	private void Awake()
	{
		desc = TableLocator.CharacterTable.Find (id);
		skills = new List<Skill> ();

		foreach (var skillGroupDesc in desc.SkillGroups) 
		{
			if (skillLevel > 0) 
			{
				var skill = new Skill (skillGroupDesc.SkillId, skillLevel);
				skills.Add (skill);
			} 
			else 
			{
				Debug.Log ("skill level is zero");
			}
		}
	}

	private void Start()
	{
		PrintData ();
	}

	private void PrintData()
	{
		Debug.LogFormat ("CharacterId : {0}", desc.Id);
		Debug.LogFormat ("Name : {0}", desc.Name);
		Debug.LogFormat ("Class : {0}", desc.Class);
		foreach (var skill in skills) 
		{
			skill.PrintData ();
		}
	}
}

public class Skill
{
	private SkillDescriptor desc;
	private List<SkillEffect> skillEffects;

	public Skill(string id, int level)
	{
		desc = TableLocator.SkillTable.Find (id);
		skillEffects = new List<SkillEffect> ();
		foreach (var skillEffectDesc in desc.SkillEffects) 
		{
			skillEffects.Add(new SkillEffect(skillEffectDesc, level));
		}
	}

	public void PrintData()
	{
		Debug.LogFormat ("Skill Id : {0}", desc.Id);
		foreach (var effect in skillEffects) 
		{
			effect.PrintData ();
		}
	}
}

public class SkillEffect
{
	SkillDescriptor.SkillEffectDescriptor desc;
	private int value;
	private float valueRate;

	public SkillEffect(SkillDescriptor.SkillEffectDescriptor desc, int level)
	{
		this.desc = desc;
		value = desc.Value + desc.GetUpgradeDesc(level).AddValue;
		valueRate = desc.ValueRate + desc.GetUpgradeDesc(level).AddValueRate;
	}

	public void PrintData()
	{
		Debug.LogFormat ("SkillEffect Id : {1}", desc.Id);
		Debug.LogFormat ("Value : {1}", value);
		Debug.LogFormat ("ValueRate : {1}", valueRate);
	}
}
