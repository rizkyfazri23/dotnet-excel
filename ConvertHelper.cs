namespace excel
{
	public class ConvertHelper
	{
		public static string fileToString(string fileName, byte[] byteArray)
		{
			string base64Content = Convert.ToBase64String(byteArray);

			string usedFileName = fileName;
			usedFileName = usedFileName.Replace("&", "&amp;");
			usedFileName = usedFileName.Replace("'", "&apos;");
			return "<file><name>" + usedFileName + "</name><content>" + base64Content + "</content></file>";
		}
	}
}