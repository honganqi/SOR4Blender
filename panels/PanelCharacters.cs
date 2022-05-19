using System;
using System.Windows.Forms;

namespace SOR4_Blender.panels
{
    public partial class PanelCharacters : Form
    {
        MainWindow _mainwindow;
        public PanelCharacters(MainWindow mainwindow)
        {
            InitializeComponent();
            _mainwindow = mainwindow;
        }

        private void PanelGravity_MouseDown(object sender, MouseEventArgs e)
        {
            _mainwindow.lastLocation = e.Location;
        }

        private void PanelGravity_MouseMove(object sender, MouseEventArgs e)
        {
            _mainwindow.MoveWindow(e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainwindow.mainform.SwitchPanel("main");
        }
    }
}
