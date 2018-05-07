using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ChuKyDienTu
{
    public partial class FrmXacNhan : DevExpress.XtraEditors.XtraForm
    {
        public string bantomluoc1 = "";
        public string bantomluoc2 = "";
        private long E = 0L;
        private long N = 0L;
        private string fname = "";
        private OpenFileDialog ofd1 = new OpenFileDialog();
        private OpenFileDialog ofd = new OpenFileDialog();
        ChuKyDienTu chuKyDienTu = new ChuKyDienTu();

        public FrmXacNhan()
        {
            InitializeComponent();
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

        private void BtnTaiChuKy_Click(object sender, EventArgs e)
        {
            richTextBoxChuKy.ReadOnly = true;
            Openfilexn();
        }

        private void Openfilexn()
        {
            ofd1.Multiselect = false;
            ofd1.Filter = "Text Files (*.txt)|*.txt";
            ofd1.FilterIndex = 1;
            ofd1.FileName = string.Empty;
            if (ofd1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBoxChuKy.LoadFile(ofd1.FileName, RichTextBoxStreamType.PlainText);
                fname = ofd1.FileName;
                richTextBoxChuKy.Modified = false;
                Text = "Doc Crypto : " + ofd1.FileName;
            }
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

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            XacNhan();
        }
        private void XacNhan()
        {
            try
            {
                if ((textEditE.Text != "") && (textEditN.Text != ""))
                {
                    if (richTextBoxChuKy.Text != "")
                    {
                        progressBar.Value = 0;
                        E = Convert.ToInt64(textEditE.Text);
                        N = Convert.ToInt64(textEditN.Text);
                        string text = richTextBoxChuKy.Text;
                        int num = 0;
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i] == Convert.ToChar(" "))
                            {
                                num++;
                            }
                        }
                        long[] numArray = new long[num];
                        int num3 = 0;
                        int index = 0;
                        string str2 = "";
                        while (num3 < text.Length)
                        {
                            if (text[num3] != Convert.ToChar(" "))
                            {
                                str2 = str2 + text[num3];
                                num3++;
                            }
                            else
                            {
                                numArray[index] = Convert.ToInt64(str2);
                                str2 = "";
                                index++;
                                num3++;
                            }
                        }
                        long[] numArray2 = new long[numArray.Length];
                        for (int j = 0; j < numArray.Length; j++)
                        {
                            numArray2[j] = tinh(numArray[j], E, N);
                            if (j < 90)
                            {
                                progressBar.Value++;
                            }
                        }
                        string str3 = "";
                        for (int k = 0; k < numArray2.Length; k++)
                        {
                            str3 = str3 + ((char)((ushort)numArray2[k]));
                        }
                        progressBar.Value = 0x5f;
                        bantomluoc1 = str3;
                        bantomluoc2 = chuKyDienTu.BamSHA(richEditControlVanBan.Text);
                        progressBar.Value = 100;
                        if (bantomluoc1 != bantomluoc2)
                        {
                            XtraMessageBox.Show("Chữ ký không đúng hoặc văn bản không toàn vẹn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            XtraMessageBox.Show("Xác thực chữ ký thành công!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Chữ ký xác nhận không được rỗng", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Nhập khoá công khai E, N để xác nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                XtraMessageBox.Show("Chữ ký sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            richEditControlVanBan.ResetText();
            richTextBoxChuKy.ResetText();
        }

        private void BtnNapKhoa_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Khoá công khai(*.puk)|*.puk"
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
                    textEditE.Text = info.BienE;
                    textEditN.Text = info.BienN;
                    Program.bienE = info.BienE;
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