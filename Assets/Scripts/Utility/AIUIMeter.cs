using System.Collections;
using System.Collections.Generic;
using TMPro; // Import TextMeshPro namespace
using UnityEngine;
using UnityEngine.UI;

public class AIUIMeter : MonoBehaviour
{
	[SerializeField] TMP_Text label; // TextMeshPro text component for displaying label
	[SerializeField] Slider slider; // Slider component for displaying a value
	[SerializeField] Image image; // Image component for displaying a visual representation

	// Property to set the position of the UI element in the world
	public Vector3 position
	{
		set
		{
			Debug.DrawLine(value, value + Vector3.up * 3); // Draw a debug line from the given position
			Vector2 viewportPoint = Camera.main.WorldToViewportPoint(value); // Convert world position to viewport point
			GetComponent<RectTransform>().anchorMin = viewportPoint; // Set minimum anchor point of RectTransform to the viewport point
			GetComponent<RectTransform>().anchorMax = viewportPoint; // Set maximum anchor point of RectTransform to the viewport point
		}
	}

	// Property to set the value of the slider
	public float value
	{
		set
		{
			slider.value = value; // Set the value of the slider
		}
	}

	// Property to set the text of the label
	public string text
	{
		set
		{
			label.text = value; // Set the text of the label
		}
	}

	// Property to set the visibility of the UI element
	public bool visible
	{
		set
		{
			gameObject.SetActive(value); // Set the visibility of the game object
		}
	}

	// Property to set the alpha (transparency) of the image
	public float alpha
	{
		set
		{
			Color color = image.color; // Get the current color of the image
			color.a = value; // Set the alpha component of the color
			image.color = color; // Apply the new color to the image
		}
	}
}
