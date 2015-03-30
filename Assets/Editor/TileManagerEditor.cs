using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


[CustomEditor(typeof(TileManager))]
public class TileManagerEditor : Editor {
	

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		if(GUILayout.Button("GenerateMap")){
			TileManager manager = (TileManager)target;



			int startX = 0;
			int startY = 0;

			for(int j=0; j < manager.Height; j++){
				for(int i=0; i < manager.Width; i++){
					var newTile = (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(manager.Tile);
					newTile.transform.parent = manager.transform;
					newTile.transform.localPosition = new Vector3(i*16, j*16);

					newTile.layer = manager.gameObject.layer;

					var x = startX/manager.tileWidth;
					var y = startY/manager.tileWidth;



					var tile =(Tile)newTile.GetComponent<Tile>();
					tile.x = (int)(startX/manager.tileWidth);
					tile.y = (int)(startY/manager.tileWidth);




					newTile.name = "Tile("+i +":"+j+")";
					startX+= 16;

				}
				startY+= 16;
				startX = 0;
			}
		}

	}
}
