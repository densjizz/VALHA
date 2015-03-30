using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class MetaCrewCreator : Editor {

	[MenuItem("Assets/Create/MetaCrew")]
	public static void CreateAsset ()
	{
		//MetaCrew crew = new MetaCrew ();
		var meta = ScriptableObject.CreateInstance<MetaCrew> ();
		
		var strenght = new Osiris.Attribute ("Strenght", 10);
		strenght.Scaling = 1.0f;
		meta.Attributes.Add (strenght);
		
		var reflex = new Osiris.Attribute ("Reflex", 10);
		reflex.Scaling = 1.0f;
		meta.Attributes.Add (reflex);
		
		var Intelligence = new Osiris.Attribute ("Intelligence", 10);
		Intelligence.Scaling = 1.0f;
		meta.Attributes.Add (Intelligence);
		
		meta.Health = new Osiris.HealthAttribute (strenght);
		
		
		AssetDatabase.CreateAsset(meta, "Assets/Meta/MetaCrew.asset");
	}

	[MenuItem("Assets/Create/MetaSubmarine")]
	public static void CreateSubmarineAsset ()
	{
		//MetaCrew crew = new MetaCrew ();
		var meta = ScriptableObject.CreateInstance<MetaSubmarine> ();

		
		var endurance = new Osiris.Attribute ("Strenght", 10);
		endurance.Scaling = 1.0f;
		meta.Health = new Osiris.HealthAttribute (endurance);

		
		meta.Health = new Osiris.HealthAttribute (endurance);

		meta.Stations = CreateBasicSubStation ();
		
		
		AssetDatabase.CreateAsset(meta, "Assets/Meta/MetaSubmarine.asset");
	}

	[MenuItem("Assets/Create/MetaWeapon")]
	public static void CreateMetaWeaponAsset ()
	{
		//MetaCrew crew = new MetaCrew ();
		var meta = ScriptableObject.CreateInstance<MetaWeapon> ();
        meta.ReloadSpeed = 0.2f;
		meta.Damage = 1;
		meta.Name = "";
		AssetDatabase.CreateAsset(meta, "Assets/Meta/MetaWeapon.asset");
	}
	static List<MetaStation> CreateBasicSubStation ()
	{
		List<MetaStation> result = new List<MetaStation> ();
		var id = 0;

		MetaStation Engine = new MetaStation ();
		Engine.ID = id++;
		Engine.Name = "Engine";
		result.Add (Engine);


        MetaStation Navigation = new MetaStation();
        Navigation.ID = id++;
        Navigation.Name = "Navigation";
        result.Add(Navigation);


		MetaStation Sonar = new MetaStation ();
		Sonar.ID = id++;
		Sonar.Name = "Sonar";
		result.Add (Sonar);

		MetaStation Radio = new MetaStation ();
		Radio.ID = id++;
		Radio.Name = "Radio";
		result.Add (Radio);

		MetaStation Weapon = new MetaStation ();
		Weapon.ID = id++;
		Weapon.Name = "Weapons";
		result.Add (Weapon);

		return result;
	}


    [MenuItem("Assets/Create/MetaTile")]
    public static void CreateMetaTile() {
        var meta = ScriptableObject.CreateInstance<MetaTile>();
        AssetDatabase.CreateAsset(meta, "Assets/Meta/MetaTile.asset");
    }
}
