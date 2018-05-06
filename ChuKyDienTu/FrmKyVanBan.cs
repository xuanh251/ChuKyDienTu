using DevExpress.XtraRichEdit;
using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml.Serialization;

namespace ChuKyDienTu
{
    public partial class FrmKyVanBan : DevExpress.XtraEditors.XtraForm
    {
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
        ChuKyDienTu chuKyDienTu = new ChuKyDienTu();
        public FrmKyVanBan()
        {
            InitializeComponent();
            //textEditD.Text = Program.bienD;
            //textEditN.Text = Program.bienN;
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
            KyVanBan();
        }
        private void KyVanBan()
        {
            try
            {
                DateTime now = DateTime.Now;
                progressBar.Value = 0;
                if (String.IsNullOrEmpty(richEditControlVanBan.Text))
                {
                    XtraMessageBox.Show("Bạn cần thêm văn bản cần ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                textEditSHA.Text = chuKyDienTu.BamSHA(richEditControlVanBan.Text);
                if (Program.bienN != "")
                {
                    int num5;
                    long a = Convert.ToInt64(Program.bienp);
                    long b = Convert.ToInt64(Program.bienq);
                    N = b * a;
                    long n = (b - 1L) * (a - 1L);//tinh ham so Ole n
                    //tìm E là nguyên tố cùng nhau với n
                    long num4 = chuKyDienTu.max(a, b);
                    E = num4 + 1L;
                    do
                    {
                        E += 1L;
                    }
                    while (ucln(E, n) != 1L);
                    D = chuKyDienTu.nd(E, n);
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
                    XtraMessageBox.Show("Ký thành công!Thời gian thực hiện : " + span.Seconds.ToString() + "," + span.Milliseconds.ToString() + " gi\x00e2y.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Chưa ký được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message.ToString(), "Thông báo");
            }
        }
        private void BtnLuuChuKy_Click(object sender, EventArgs e)
        {
            LuuChuKy();
        }
        private void LuuChuKy()
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
                    XtraMessageBox.Show("Bạn đã lưu chữ ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            richEditControlVanBan.ResetText();
            memoEditChuKy.ResetText();
            textEditSHA.ResetText();
            memoEditChuKy.ResetText();
            textEditD.Text = Program.bienD;
            textEditN.Text = Program.bienN;
        }

        private void BtnNapKhoa_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Khoá bảo mật(*.pvk)|*.pvk"
            };
            string path = null;
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    path = ofd.FileName;
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(KeyManager));
                    FileStream read = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    KeyManager info = (KeyManager)xmlSerializer.Deserialize(read);
                    textEditD.Text = info.BienD;
                    textEditN.Text = info.BienN;
                    Program.bienp = info.BienP;
                    Program.bienq = info.BienQ;
                    Program.bienD = info.BienD;
                    Program.bienN = info.BienN;
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Không tải được khoá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}