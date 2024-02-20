using System.Collections.Generic; // Import the System.Collections.Generic namespace
using UnityEngine; // Import the UnityEngine namespace

public class AIUtilityObject : MonoBehaviour // Define the AIUtilityObject class which inherits from MonoBehaviour
{
	[System.Serializable]
	public class Effector // Nested class for defining effectors
	{
		public AIUtilityNeed.Type type; // Type of need affected by the effector
		[Range(-2, 2)] public float change; // Magnitude of change for the associated need
	}

	[Header("Parameters")]
	[SerializeField] public Effector[] effectors; // Array of effectors affecting various needs
	[SerializeField, Tooltip("Time to use object")] public float duration; // Duration for which the object can be used
	[SerializeField, Tooltip("Animation to play when using")] public string animationName; // Name of animation to play when using the object

	[Header("UI")]
	[SerializeField, Tooltip("Radius to detect agent")] float radius = 5; // Radius for detecting nearby agents
	[SerializeField] LayerMask agentLayerMask; // Layer mask for agents
	[SerializeField] AIUIMeter meterPrefab; // Prefab for the UI meter associated with the object
	[SerializeField] Vector3 meterOffset; // Offset for positioning the UI meter

	public float score { get; set; } // Score associated with the object's utility

	AIUIMeter meter; // Reference to the UI meter
	Dictionary<AIUtilityNeed.Type, float> registry = new Dictionary<AIUtilityNeed.Type, float>(); // Dictionary for mapping need types to their associated changes

	void Start()
	{
		// Create meter UI at run-time
		meter = Instantiate(meterPrefab, GameObject.Find("Canvas").transform);

		// Set meter properties
		meter.name = name;
		meter.text = name;
		meter.position = transform.position + meterOffset;

		// Set effectors array into dictionary for easier access
		foreach (var effector in effectors)
		{
			registry[effector.type] = effector.change;
		}
	}

	private void Update()
	{
		meter.visible = false; // Hide meter by default

		// Show object meter if near agent
		var colliders = Physics.OverlapSphere(transform.position, radius, agentLayerMask);
		if (colliders.Length > 0)
		{
			if (colliders[0].TryGetComponent(out AIUtilityAgent agent))
			{
				// Calculate distance score for the meter
				float distance = 1 - Vector3.Distance(colliders[0].transform.position, transform.position) / radius;
				score = agent.GetUtilityScore(this);
				meter.alpha = Mathf.Max(0.5f, score * distance); // Set meter alpha based on score and distance
				meter.visible = true; // Show the meter
			}
		}
	}

	void LateUpdate()
	{
		meter.value = score; // Update meter value with the object's score
		meter.position = transform.position + meterOffset; // Update meter position relative to the object
	}

	// Get the change associated with a specific need type
	public float GetNeedChange(AIUtilityNeed.Type type)
	{
		return registry.TryGetValue(type, out float value) ? value : 0f; // Return the change if found in the registry, otherwise return 0
	}

	// Check if the object has an effector associated with a specific need type
	public bool HasNeedType(AIUtilityNeed.Type type)
	{
		return registry.ContainsKey(type); // Return true if the need type is found in the registry
	}
}
