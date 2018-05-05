using DevExpress.XtraRichEdit;
using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ChuKyDienTu
{
    public partial class FrmKyVanBan : DevExpress.XtraEditors.XtraForm
    {
        public string bantomluoc1 = "";
        public string bantomluoc2 = "";
        private long D = 0L;
        private long E = 0L;
        private string fname = "";
        private long N = 0L;
        private OpenFileDialog ofd = new OpenFileDialog();
        private OpenFileDialog ofd1 = new OpenFileDialog();
        private OpenFileDialog ofd2 = new OpenFileDialog();
        private OpenFileDialog ofd3 = new OpenFileDialog();
        public static string pass;
        private SaveFileDialog sfd = new SaveFileDialog();
        private SaveFileDialog sfd1 = new SaveFileDialog();

        public FrmKyVanBan()
        {
            InitializeComponent();
            textEditD.Text = Program.bienD;
            textEditN.Text = Program.bienN;
        }

        public long max(long a, long b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }

        public long nd(long a, long b)
        {
            long num2 = 1L;
            while ((((num2 * b) + 1L) % a) != 0L)
            {
                num2 += 1L;
            }
            return (((num2 * b) + 1L) / a);
        }

        private void BtnTaiVanBan_Click(object sender, EventArgs e)
        {
            richEditControlVanBan.Modified = false;
            Openfile();
        }

        private void Openfile()
        {
            ofd.Multiselect = false;
            ofd.Filter = "Word Document (*.doc)|*.doc|Document files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf";
            ofd.FilterIndex = 1;
            ofd.FileName = string.Empty;
            if ((ofd.ShowDialog() != DialogResult.Cancel) && (ofd.FileName != ""))
            {
                if (ofd.FilterIndex == 2)
                {
                    richEditControlVanBan.LoadDocument(ofd.FileName, DocumentFormat.PlainText);
                }
                else if (ofd.FilterIndex == 1)
                {
                    ApplicationClass class2 = new ApplicationClass();
                    object fileName = ofd.FileName;
                    object confirmConversions = Missing.Value;
                    class2.Documents.Open(ref fileName, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions, ref confirmConversions).Select();
                    class2.Selection.Copy();
                    richEditControlVanBan.Text = "";
                    richEditControlVanBan.Paste();
                    object saveChanges = false;
                    class2.Quit(ref saveChanges, ref confirmConversions, ref confirmConversions);
                }
                else if (ofd.FilterIndex == 3)
                {
                    richEditControlVanBan.LoadDocument(ofd.FileName, DocumentFormat.PlainText);
                }
                fname = ofd.FileName;
                richEditControlVanBan.Modified = false;
                Text = "Doc Crypto : " + ofd.FileName;
            }
        }

        public static string BamSHA(string mess)
        {
            SHA256Managed managed = new SHA256Managed();
            byte[] bytes = Encoding.UTF8.GetBytes(mess);
            bytes = managed.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in bytes)
            {
                builder.Append(num.ToString("x2").ToLower());
            }
            return builder.ToString().ToUpper();
        }

        public long ucln(long a, long b)
        {
            while (b != 0L)
            {
                long num2 = a % b;
                a = b;
                b = num2;
            }
            return a;
        }

        public static long tinh(long b, long e, long n)
        {
            long num = b % n;
            for (long i = 1L; i < e; i += 1L)
            {
                num = (num * b) % n;
            }
            return num;
        }

        private void BtnKyVanBan_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                progressBar.Value = 0;
                textEditSHA.Text = BamSHA(richEditControlVanBan.Text);
                if (Program.bienN != "")
                {
                    int num5;
                    long a = Convert.ToInt64(Program.bienp);
                    long b = Convert.ToInt64(Program.bienq);
                    N = b * a;
                    long num3 = (b - 1L) * (a - 1L);
                    long num4 = max(a, b);
                    E = num4 + 1L;
                    do
                    {
                        E += 1L;
                    }
                    while (ucln(E, num3) != 1L);
                    D = nd(E, num3);
                    int[] numArray = new int[textEditSHA.Text.Length];
                    for (num5 = 0; num5 < textEditSHA.Text.Length; num5++)
                    {
                        numArray[num5] = textEditSHA.Text[num5];
                    }
                    long[] numArray2 = new long[numArray.Length];
                    for (num5 = 0; num5 < numArray.Length; num5++)
                    {
                        numArray2[num5] = tinh(numArray[num5], D, N);
                        if (num5 < 0x62)
                        {
                            progressBar.Value++;
                        }
                    }
                    string str = "";
                    for (num5 = 0; num5 < numArray.Length; num5++)
                    {
                        str = str + numArray2[num5] + " ";
                    }
                    memoEditChuKy.Text = str;
                    TimeSpan span = DateTime.Now.Subtract(now);
                    progressBar.Value = 100;
                    MessageBox.Show("Ký thành công!Thời gian thực hiện : " + span.Seconds.ToString() + "," + span.Milliseconds.ToString() + " gi\x00e2y.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Chưa ký được", "Thông báo");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "Th\x00f4ng b\x00e1o");
            }
        }

        private void BtnLuuChuKy_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Chữ ký(*.txt)|*.txt"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(dialog.FileName);
                    writer.WriteLine(this.memoEditChuKy.Text);
                    writer.Flush();
                    writer.Close();
                    MessageBox.Show("Bạn đã lưu chữ ký", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi", "Thông báo");
            }
        }
    }
}