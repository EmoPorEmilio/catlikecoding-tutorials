using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    Transform[] points;

	[SerializeField, Range(10, 100)]
	int resolution = 10;


	[SerializeField]
	FunctionLibrary.FunctionName function;
    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[resolution];
		var position = Vector3.zero;
        float step = 2f / resolution;
		var scale = Vector3.one * step;

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
			point.localPosition = position;
			point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
			position.y = f(position.x, position.z, time);
            point.localPosition = position;
        }
        
    }
}
