using System;

namespace ChuKyDienTu
{
    public partial class FrmTaoKhoa : DevExpress.XtraEditors.XtraForm
    {
        ChuKyDienTu chuKyDienTu = new ChuKyDienTu();
        public FrmTaoKhoa()
        {
            InitializeComponent();
            TaoSNT();
        }

        private void btnTaoSNT_Click(object sender, EventArgs e)
        {
            TaoSNT();
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

        private void BtnTaoKhoa_Click(object sender, EventArgs e)
        {
            TaoKhoa();
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
            Program.bienD = this.D.ToString();
            Program.bienE = this.E.ToString();
            Program.bienN = this.N.ToString();
        }
        private void txtSNT1_EditValueChanged(object sender, EventArgs e)
        {
            Program.bienq = txtSNT1.Text;
        }

        private void txtSNT2_EditValueChanged(object sender, EventArgs e)
        {
            Program.bienp = txtSNT2.Text;
        }
    }
}