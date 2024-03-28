/*
 * UnityでJsonを扱うサンプルプログラムです。
 * 配列のシリアライズやオブジェクトのディープコピーもできます。
 * 詳細は https://unixo-lab.com/unity/json.html をご覧下さい。
 */
using UnityEngine;

public class Json
{
	public static string Serialize<T>(T obj)
	{
		return JsonUtility.ToJson(obj);
	}

	public static T Deserialize<T>(string json)
	{
		return JsonUtility.FromJson<T>(json);
	}

	public static string SerializeArray<T>(T[] objs)
	{
		string json = JsonUtility.ToJson(new ArrayWrapper<T> { _ = objs });
		return json.Substring(5, json.Length - 6);
	}

	public static T[] DeserializeArray<T>(string json)
	{
		return JsonUtility.FromJson<ArrayWrapper<T>>("{\"_\":" + json + "}")._;
	}

	public static T Copy<T>(T obj)
	{
		return JsonUtility.FromJson<T>(JsonUtility.ToJson(obj));
	}

	public static T[] CopyArray<T>(T[] objs)
	{
		return DeserializeArray<T>(SerializeArray(objs));
	}

	[System.Serializable]
	private struct ArrayWrapper<T>
	{
		public T[] _;
	}
}
