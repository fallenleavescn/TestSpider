using System.IO;

namespace Method
{
    public class MethodSpider
    {
        private string targetURL;

        
        public MethodSpider(string target)
        {
            this.targetURL = target;
        }
        
        public string RequestWEB(string targetURL)
        {
            MethodWeb mw = new Method.MethodWeb(targetURL);
            mw.resloveText += new MethodWeb.ReslovedText(this.Text);
            return mw.g_newText;
        }

        public void Text(string txt)
        {
            File.WriteAllText("c:/1.txt", txt);
        }
    }
}
