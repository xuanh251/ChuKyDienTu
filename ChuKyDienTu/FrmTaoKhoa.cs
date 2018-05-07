using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml.Serialization;
using System.IO;

namespace ChuKyDienTu
{
    public partial class FrmTaoKhoa : DevExpress.XtraEditors.XtraForm
    {
        ChuKyDienTu chuKyDienTu = new ChuKyDienTu();
        public FrmTaoKhoa()
        {
            InitializeComponent();
            TaoSNT();
            TaoKhoa();
        }

        private void btnTaoSNT_Click(object sender, EventArgs e)
        {
            TaoSNT();
            TaoKhoa();
        }

        private void TaoSNT()
        {
            long num = chuKyDienTu.sntngaunhien();
            long num2 = chuKyDienTu.sntngaunhien();
            while (num == num2)
            {
                num2 = chuKyDienTu.sntngaunhien();
            }
            txtSNT1.Text = Convert.ToString(num);
            txtSNT2.Text = Convert.ToString(num2);
        }

        private long N = 0L;
        private long E = 0L;
        private long D = 0L;

        private void BtnLuuKhoaBiMat_Click(object sender, EventArgs e)
        {
            LuuKhoaBaoMat();
        }
        private void LuuKhoaBaoMat()
        {
            try
            {
                KeyManager keyManager = new KeyManager();
                keyManager.BienD = txtD.Text;
                keyManager.BienN = txtNBM.Text;
                keyManager.BienQ = txtSNT1.Text;
                keyManager.BienP = txtSNT2.Text;
                string path = null;
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Khoá bí mật(*.pvk)|*.pvk"
                };
                if (dialog.ShowDialog()==DialogResult.OK)
                {
                    path = dialog.FileName;
                    chuKyDienTu.SaveKey(keyManager, path);
                    XtraMessageBox.Show("Đã lưu khoá bảo mật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnLuuKhoaCongKhai_Click(object sender, EventArgs e)
        {
            LuuKhoaCongKhai();
        }
        private void LuuKhoaCongKhai()
        {
            try
            {
                KeyManager keyManager = new KeyManager();
                keyManager.BienE = txtE.Text;
                keyManager.BienN = txtNCK.Text;
                string path = null;
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Khoá công khai(*.puk)|*.puk"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                    chuKyDienTu.SaveKey(keyManager, path);
                    XtraMessageBox.Show("Đã lưu khoá công khai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaoKhoa()
        {
            long snt1 = Convert.ToInt64(txtSNT1.Text);
            long snt2 = Convert.ToInt64(txtSNT2.Text);
            N = snt1 * snt2;
            txtNBM.Text = txtNCK.Text = N.ToString();
            long num3 = (snt2 - 1L) * (snt1 - 1L);
            long num4 = chuKyDienTu.max(snt1, snt2);
            E = num4 + 1L;
            do
            {
                E += 1L;
            }
            while (chuKyDienTu.ucln(E, num3) != 1L);
            D = chuKyDienTu.nd(E, num3);
            txtE.Text = E.ToString();
            txtD.Text = D.ToString();
            
        }
       
        
    }
}