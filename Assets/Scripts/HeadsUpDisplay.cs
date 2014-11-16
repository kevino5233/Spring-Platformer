using UnityEngine;
using System.Collections;

public class HeadsUpDisplay : MonoBehaviour
{
	public Texture ScoreBackground;
	public GameObject BottomLeftCornerPlayer;
	public GameObject BottomRightCornerPlayer;

	void OnGUI ()
	{
		const float height = 97.0f;
		const float width = 175.0f;
		this.DrawScore(TextAnchor.UpperLeft, this.BottomLeftCornerPlayer.GetComponent<Player>(), new Vector2(10.0f, Screen.height - height - 10.0f), width, height);
		this.DrawScore(TextAnchor.UpperRight, this.BottomRightCornerPlayer.GetComponent<Player>(), new Vector2(Screen.width - 10.0f - width, Screen.height - height - 10.0f), width, height);

		const float restartButtonWidth = 100.0f;
		const float restartButtonHeight = 40.0f;
	}

	void DrawScore(TextAnchor alignment, Player player, Vector2 topLeft, float width, float height)
	{
		GUI.DrawTexture(new Rect(topLeft.x, topLeft.y, width, height), this.ScoreBackground);

		const float topMargin = 15.0f;
		const float outerMargin = 35.0f;
		const float scoreHeight = 40.0f;
		
		Texture2D healthColor = new Texture2D(1, 1);
		healthColor.SetPixel(0, 0, player.HUDColor);
		healthColor.Apply();
		GUI.skin.box.normal.background = healthColor;
		GUI.Box(new Rect(topLeft.x + outerMargin / 2, topLeft.y + topMargin / 2, (width - outerMargin) * player.health / 100, 10), GUIContent.none);
		
		GUIStyle scoreStyle = new GUIStyle("label");
		scoreStyle.fontSize = 40;
		scoreStyle.alignment = alignment;
		scoreStyle.normal.textColor = player.HUDColor;
		GUI.Label (new Rect(topLeft.x + outerMargin, topLeft.y + topMargin, width - outerMargin * 2, height), player.Score.ToString(), scoreStyle);

		GUIStyle nameStyle = new GUIStyle("label");
		nameStyle.fontSize = 14;
		nameStyle.alignment = alignment;
		nameStyle.normal.textColor = player.HUDColor;
		GUI.Label (new Rect(topLeft.x + outerMargin, topLeft.y + topMargin + scoreHeight, width - outerMargin * 2, height), player.name, nameStyle);

	}
	
}
