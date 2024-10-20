using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    Transform[] points;

	[SerializeField, Range(10, 100)]
	int resolution = 10;
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
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
			position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
        
    }
}
