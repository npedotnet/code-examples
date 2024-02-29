/* 
 * ゲームオブジェクトを常駐化するサンプルプログラムです。
 * 適当なゲームオブジェクトに追加して確認して下さい。
 * 詳細は https://unixo-lab.com/unity/resident_object.html をご覧下さい。
 */
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}
