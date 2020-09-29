using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _GUIClasses : MonoBehaviour {
	
	[System.Serializable]
	public class TextureGUI {

		public Texture texture; 
		public Vector3 offset; 
		public Vector2 originalOffset; 
		public enum Point { TopLeft, TopRight, BottomLeft, BottomRight, Center} 
		public Point anchorPoint = Point.TopLeft;
			
		void setAnchor(){
			originalOffset = offset;
			if (texture){ 
				switch(anchorPoint) { 
				case Point.TopLeft: 
					break;
				case Point.TopRight: 
					offset.x = originalOffset.x - texture.width;
					break;				
				case Point.BottomLeft:
					offset.y = originalOffset.y - texture.height;
					break;			
				case Point.BottomRight:
					offset.x = originalOffset.x - texture.width;
					offset.y = originalOffset.y - texture.height;
					break;
				case Point.Center:
					offset.x = originalOffset.x - texture.width/2;
					offset.y = originalOffset.y - texture.height/2;
					break;
				}
			}
		}	
	}
	
	[System.Serializable]
	public class Location {

		public enum Point { TopLeft, TopRight, BottomLeft, BottomRight, Center}
		public Point pointLocation = Point.TopLeft;
		public Vector2 offset;
			
		public void updateLocation(){
			switch(pointLocation){
			case Point.TopLeft:
				offset = new Vector2(0,0);
				break;
			case Point.TopRight:
				offset = new Vector2(Screen.width,0);
				break;	
			case Point.BottomLeft:
				offset = new Vector2(0,Screen.height);
				break;
			case Point.BottomRight:
				offset = new Vector2(Screen.width,Screen.height);
				break;
			case Point.Center:
				offset = new Vector2(Screen.width/2,Screen.height/2);
				break;
			}		
		}
	}

}
