using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutForm.Controls
{
    public partial class SinPanel : UserControl
    {
        public List<TextBox> TextBoxes { private set; get; }
        public SinPanel()
        {
            InitializeComponent();

            List<TextBox> l = new List<TextBox>();
            l.Add(tbA);
            l.Add(tbB);
            l.Add(tbC);

            TextBoxes = l;
        }
    }
}
