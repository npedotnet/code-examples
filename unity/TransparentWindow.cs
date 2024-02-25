/* 
 * ビルドしたUnityのウインドウを透明にするサンプルプログラムです。
 * 適当なゲームオブジェクトに追加してビルドして確認して下さい。
 * エスケープキーで終了します。
 * 詳細は https://unixo-lab.com/unity/transparent_window.html をご覧下さい。
 */
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
	[DllImport("user32.dll")]
	static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll")]
	static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[DllImport("user32.dll")]
	static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

	[DllImport("user32.dll")]
	static extern int SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte bAlpha, uint dwFlags);

	const int GWL_STYLE = -16;
	const uint WS_VISIBLE = 0x10000000;
	const uint WS_POPUP = 0x80000000;
	const int HWND_TOPMOST = -1;
	const uint SWP_NOMOVE = 0x0002;
	const int GWL_EXSTYLE = -20;
	const uint WS_EX_LAYERED = 0x00080000;
	const int LWA_COLORKEY = 1;

	void Start()
	{
#if !UNITY_EDITOR
		int width = Screen.width;
		int height = Screen.height;
		var hWnd = GetActiveWindow();
		SetWindowLong(hWnd, GWL_STYLE, WS_VISIBLE | WS_POPUP);
		SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, width, height, SWP_NOMOVE);

		SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED);
		SetLayeredWindowAttributes(hWnd, 0, 0, LWA_COLORKEY);
#endif
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
