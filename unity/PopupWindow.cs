/* 
 * ビルドしたUnityのウインドウをポップアップウインドウにするサンプルプログラムです。
 * 適当なゲームオブジェクトに追加してビルドして確認して下さい。
 * エスケープキーで終了します。
 * 詳細は https://unixo-lab.com/unity/transparent_window.html をご覧下さい。
 */
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    const int GWL_STYLE = -16;
    const uint WS_VISIBLE = 0x10000000;
    const uint WS_POPUP = 0x80000000;
    const int HWND_TOPMOST = -1;
    const uint SWP_NOMOVE = 0x0002;

    void Start()
    {
#if !UNITY_EDITOR
        int width = Screen.width;
        int height = Screen.height;
        var hWnd = GetActiveWindow();
        SetWindowLong(hWnd, GWL_STYLE, WS_VISIBLE | WS_POPUP);
        SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, width, height, SWP_NOMOVE);
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
