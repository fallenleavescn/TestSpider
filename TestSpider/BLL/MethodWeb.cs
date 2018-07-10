using System;
using System.Windows.Forms;
using System.Timers;

namespace Method
{
    class MethodWeb
    {
        private WebBrowser web = new WebBrowser();
        public string g_newText = null;
        private string g_oldText = null;

        public delegate void ReslovedText(string newText);
        public event ReslovedText resloveText;

        public MethodWeb(string target)
        {
            if (target != null)
                RequestWeb(target);
        }

        private void RequestWeb(string weburl)
        {
            try
            {
                this.web.Url = new Uri(weburl);
                this.web.ScriptErrorsSuppressed = false;

                this.web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
            }
            catch(Exception e) { MessageBox.Show(e.Message); }
        }

        System.Timers.Timer t;

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        { 
            if (this.web.ReadyState != WebBrowserReadyState.Complete)
                return;

            getContentTxt(ref g_oldText);
            g_newText = g_oldText;

            t = new System.Timers.Timer(200);
            t.Enabled = true;
            t.Elapsed += T_Elapsed;
        }

        int retry = 0;
        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (retry < 20 && g_newText == g_oldText)
            {
                getContentTxt(ref g_newText);
            }
            else
            {
                t.Enabled = false;
                if(g_newText != g_oldText)
                {
                    resloveText(g_newText);
                }
            }
            
        }
         
        public void getContentTxt(ref string txt)
        {
            HtmlElementCollection ElementCollection = web.Document.GetElementsByTagName("div");
            foreach (HtmlElement item in ElementCollection)
            {
                if (item.GetAttribute("className") == "content")
                    txt = item.OuterText;
            }
        }
    }
}
