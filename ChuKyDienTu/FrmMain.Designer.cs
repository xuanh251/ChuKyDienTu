namespace ChuKyDienTu
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BtnTaoCapKhoa = new DevExpress.XtraBars.BarLargeButtonItem();
            this.BtnKyVanBan = new DevExpress.XtraBars.BarLargeButtonItem();
            this.BtnXacNhanChuKy = new DevExpress.XtraBars.BarLargeButtonItem();
            this.BtnNhomThucHien = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.barLargeButtonItem5 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManagerMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManagerMain)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BtnTaoCapKhoa,
            this.BtnKyVanBan,
            this.BtnXacNhanChuKy,
            this.BtnNhomThucHien,
            this.skinBarSubItem1,
            this.barLargeButtonItem5});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnTaoCapKhoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnKyVanBan),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnXacNhanChuKy),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnNhomThucHien)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BtnTaoCapKhoa
            // 
            this.BtnTaoCapKhoa.Caption = "Tạo cặp khoá";
            this.BtnTaoCapKhoa.Id = 0;
            this.BtnTaoCapKhoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnTaoCapKhoa.ImageOptions.Image")));
            this.BtnTaoCapKhoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnTaoCapKhoa.ImageOptions.LargeImage")));
            this.BtnTaoCapKhoa.Name = "BtnTaoCapKhoa";
            this.BtnTaoCapKhoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnTaoCapKhoa_ItemClick);
            // 
            // BtnKyVanBan
            // 
            this.BtnKyVanBan.Caption = "Ký văn bản";
            this.BtnKyVanBan.Id = 1;
            this.BtnKyVanBan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKyVanBan.ImageOptions.Image")));
            this.BtnKyVanBan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnKyVanBan.ImageOptions.LargeImage")));
            this.BtnKyVanBan.Name = "BtnKyVanBan";
            this.BtnKyVanBan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnKyVanBan_ItemClick);
            // 
            // BtnXacNhanChuKy
            // 
            this.BtnXacNhanChuKy.Caption = "Xác nhận chữ ký";
            this.BtnXacNhanChuKy.Id = 2;
            this.BtnXacNhanChuKy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnXacNhanChuKy.ImageOptions.Image")));
            this.BtnXacNhanChuKy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnXacNhanChuKy.ImageOptions.LargeImage")));
            this.BtnXacNhanChuKy.Name = "BtnXacNhanChuKy";
            this.BtnXacNhanChuKy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnXacNhanChuKy_ItemClick);
            // 
            // BtnNhomThucHien
            // 
            this.BtnNhomThucHien.Caption = "Thông tin nhóm thực hiện";
            this.BtnNhomThucHien.Id = 3;
            this.BtnNhomThucHien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNhomThucHien.ImageOptions.Image")));
            this.BtnNhomThucHien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnNhomThucHien.ImageOptions.LargeImage")));
            this.BtnNhomThucHien.Name = "BtnNhomThucHien";
            this.BtnNhomThucHien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNhomThucHien_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(839, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 301);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(839, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 241);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(839, 60);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 241);
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "Giao diện";
            this.skinBarSubItem1.Id = 4;
            this.skinBarSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("skinBarSubItem1.ImageOptions.Image")));
            this.skinBarSubItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("skinBarSubItem1.ImageOptions.LargeImage")));
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            // 
            // barLargeButtonItem5
            // 
            this.barLargeButtonItem5.Caption = "Giao diện";
            this.barLargeButtonItem5.Id = 5;
            this.barLargeButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem5.ImageOptions.Image")));
            this.barLargeButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem5.ImageOptions.LargeImage")));
            this.barLargeButtonItem5.Name = "barLargeButtonItem5";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.EnableBonusSkins = true;
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            // 
            // xtraTabbedMdiManagerMain
            // 
            this.xtraTabbedMdiManagerMain.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((DevExpress.XtraTab.TabButtons.Close | DevExpress.XtraTab.TabButtons.Default)));
            this.xtraTabbedMdiManagerMain.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.xtraTabbedMdiManagerMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabbedMdiManagerMain.MdiParent = this;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 323);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Text = "Phần mềm tạo chữ ký điện tử - Nhóm 6 DT15CTT01 - Báo cáo học phần Bảo mật thông t" +
    "in";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManagerMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem BtnTaoCapKhoa;
        private DevExpress.XtraBars.BarLargeButtonItem BtnKyVanBan;
        private DevExpress.XtraBars.BarLargeButtonItem BtnXacNhanChuKy;
        private DevExpress.XtraBars.BarLargeButtonItem BtnNhomThucHien;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem5;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManagerMain;
    }
}