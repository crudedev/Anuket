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
    public partial class frmEventList : Form
    {
        List<cEvent> _events;
        List<cNode> _nodes;
        public frmEventList(List<cEvent> events,List<cNode> nodes)
        {
            InitializeComponent();
            _events = events;
            _nodes = nodes;
        }

        private void EventList_Load(object sender, EventArgs e)
        {
            foreach (cEvent item in _events)
            {
                lstEvents.Items.Add(item.datetimeOfEvent.ToString() + item.fileName);
            }

            foreach (cNode item in _nodes)
            {
                lstNodes.Items.Add(item.name);
            }
        }

        private void EventList_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 100, 0));
            pen.Width = 4;
            e.Graphics.DrawLine(pen, 20, 100, 800, 100);

            DateTime start = new DateTime();
            DateTime end = new DateTime();

            Font font = new Font("Arial", 8);
            SolidBrush brush = new SolidBrush(Color.Black);

            foreach (cEvent ev in _events)
            {
                if(start == new DateTime())
                {
                    start = ev.datetimeOfEvent;
                    end = ev.datetimeOfEvent;
                }

                if (ev.datetimeOfEvent < start)
                {
                    start = ev.datetimeOfEvent;
                }

                if(ev.datetimeOfEvent > end)
                {
                    end = ev.datetimeOfEvent;
                }
            }


            TimeSpan t = end.Subtract(start);
            double deltaSeconds = t.TotalSeconds;

            lblstart.Text = "Start: " + start.ToString();
            lblnow.Text = "Now: " + end.ToString();


            int index = 0;

            foreach (var ev in _events)
            {
                index++;
                double width = 700;
                TimeSpan ts = ev.datetimeOfEvent.Subtract(start);
                double seconds = ts.TotalSeconds;

                double pixelpersecond = width / deltaSeconds;

                int xCord = Convert.ToInt32(pixelpersecond * seconds);



                e.Graphics.DrawLine(pen, xCord + 100, 80, xCord + 100, 120);

                e.Graphics.DrawString("Event: " + index.ToString(), font, brush, xCord, 50 - index);



                
            }
           
        }
    }
}
