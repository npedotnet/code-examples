/*
 * Unityでスクリーンショットを保存するサンプルプログラムです。
 * 詳細は https://unixo-lab.com/unity/screenshot.html をご覧ください。
 */
using System.IO;
using UnityEngine;

public class Screenshot
{
	public static void Capture(string path)
	{
		string directory = Path.GetDirectoryName(path);

		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}

		string extension = Path.GetExtension(path).ToLower();

		switch (extension)
		{
			case ".jpg":
			case ".jpeg":
				File.WriteAllBytes(path, ScreenCapture.CaptureScreenshotAsTexture().EncodeToJPG());
				break;
			case ".png":
				ScreenCapture.CaptureScreenshot(path);
				break;
			case ".tga":
				File.WriteAllBytes(path, ScreenCapture.CaptureScreenshotAsTexture().EncodeToTGA());
				break;
		}
	}
}
