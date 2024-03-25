/*
 * UnityのObjectを安全に破棄するサンプルコードです。。
 * 詳細は https://unixo-lab.com/unity/destroy_object.html をご覧ください。
 */
using UnityEngine;

public class ObjectUtility
{
	public static void DestroySafe<T>(ref T obj, float t = 0) where T : Object
	{
		if (obj != null)
		{
#if UNITY_EDITOR
			if (Application.isPlaying)
			{
				Object.Destroy(obj, t);
			}
			else
			{
				Object.DestroyImmediate(obj);
			}
#else
        Object.Destroy(obj, t);
#endif
			obj = null;
		}
	}
}
