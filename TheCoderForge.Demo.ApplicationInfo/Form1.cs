// /*
// * PROJECT:    TheCoderForge.Demo.ApplicationInfo
// * NAME:        Form1.cs
// */

using System;
using System.Windows.Forms;

namespace TheCoderForge.Demo.ApplicationInfo
{
    public partial class Form1 : Form
    {
        #region Constructors

        public Form1() { InitializeComponent(); }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            PropertyGridHelper.ResizeDescriptionArea(ref propertyGrid1, 6);
            PropertyGridHelper.SetLabelColumnWidth(ref propertyGrid1, 200);
            MetaData metaData = new MetaData();
            propertyGrid1.SelectedObject = metaData;
        }

     
    }
}