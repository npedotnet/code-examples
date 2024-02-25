/*
 * Unityエディターのメニューからスクリーンショットを保存するサンプルプログラムです。
 * Screenshot.csに依存しているので一緒に使って下さい。
 * 詳細は https://unixo-lab.com/unity/screenshot.html をご覧ください。
 */
using UnityEditor;

public class ScreenshotMenu
{
	[MenuItem("Screenshot/PNGで保存")]
	public static void ScreenshotAsPNG()
	{
		Screenshot.Capture("Screenshot/test.png");
	}
}
