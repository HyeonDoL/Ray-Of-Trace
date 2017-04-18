using UnityEngine;
using System.Collections;

public static class TableLocator 
{
	public static CharacterTable CharacterTable { get; private set; }
	public static SkillTable SkillTable { get; private set; }

	static TableLocator()
	{
		CharacterTable = new CharacterTable ("Table/Character");
		SkillTable = new SkillTable("Table/Skill");
	}
}
