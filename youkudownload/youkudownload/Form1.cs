using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youkudownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void download_Click(object sender, EventArgs e)
        {
            if (downloadUrlTextBox.Text == "")
            {
                MessageBox.Show("请输入下载路径");
                return;
            }
            if (pathTextBox.Text == "")
            {
                MessageBox.Show("请选择保存路径");
                return;
            }
            ProcessUrl getDodwnloadUrl = new ProcessUrl(downloadUrlTextBox.Text);
            if (getDodwnloadUrl.parse())    //如果获取链接成功，则进行下载
            {
                download(getDodwnloadUrl);
            }
        }

        /// <summary>
        /// 下载电影
        /// </summary>
        /// <param name="getDodwnloadUrl">链接处理的类，里面有需要的信息</param>
        private void download(ProcessUrl getDodwnloadUrl)
        {
            string path = pathTextBox.Text;

            Uri url = new Uri(getDodwnloadUrl.downloadYouKuUrl);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "GET";

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1482.0 Safari/537.36";


            FileStream f = null;
            try
            {
                f = new FileStream(path + "//" + getDodwnloadUrl.title + "." + getDodwnloadUrl.media_flage, FileMode.Create);
            }
            catch (Exception w)
            {
                MessageBox.Show("路径有问题。");
            }

            using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
            {

                long dataLengthHaveRead = 0;
                long dataLength = webResponse.ContentLength;

                if (webResponse.StatusCode.ToString().Equals("OK"))
                {

                }
                else
                {
                    MessageBox.Show("出错！！");
                }

                using (Stream stream = webResponse.GetResponseStream())
                {

                    const long ChunkSize = 102400; //此行可以设置每次读取的数据
                    byte[] buffer = new byte[ChunkSize];
                    while (dataLength - dataLengthHaveRead > 0)
                    {
                        Application.DoEvents();
                        int lengthRead = stream.Read(buffer, 0, Convert.ToInt32(ChunkSize));
                        dataLengthHaveRead += lengthRead;
                        double pro = Math.Round(Convert.ToDouble(dataLengthHaveRead) / dataLength, 3) * 100;
                        downloadProcess.Value = Convert.ToInt32(pro);       //设置进度条
                        downloadInfo.Text = pro + "%";
                        f.Write(buffer, 0, lengthRead);
                        f.Flush();
                    }
                    f.Close();
                }
                MessageBox.Show("下载完成>_<");
            }
        }

        private void brows_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void about_Click(object sender, EventArgs e)
        {
            About aboutit = new About();
            aboutit.ShowDialog();
        }
    }
}
