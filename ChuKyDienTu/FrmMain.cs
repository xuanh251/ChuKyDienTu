using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ChuKyDienTu
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnTaoCapKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTaoKhoa f = new FrmTaoKhoa();
            f.ShowDialog();
        }

        private void BtnKyVanBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmKyVanBan f = new FrmKyVanBan();
            f.MdiParent = this;
            f.Show();
        }

        private void BtnXacNhanChuKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmXacNhan f = new FrmXacNhan();
            f.MdiParent = this;
            f.Show();
        }
    }
}