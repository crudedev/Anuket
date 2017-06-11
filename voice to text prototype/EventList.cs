using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voice_to_text_prototype
{
    public partial class EventList : Form
    {
        List<Event> _events;
        public EventList(List<Event> events)
        {
            InitializeComponent();
            _events = events;
        }

        private void EventList_Load(object sender, EventArgs e)
        {

        }

        private void EventList_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 100, 0));
            pen.Width = 4;
            e.Graphics.DrawLine(pen, 20, 100, 800, 100);
        }
    }
}
